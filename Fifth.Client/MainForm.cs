using Fifth.Client.RemoteServiceManagerReference;
using System;
using System.Linq;
using System.ServiceModel;
using System.Windows.Forms;

namespace Fifth.Client
{
    public partial class MainForm : Form
    {
        private RemoteServiceManagerClient _remoteServiceManagerClient;
        private ServiceInfo _selectedService;
        private ServiceInfo[] _services;


        public MainForm()
        {
            InitializeComponent();
        }


        // UI EVENTS //////////////////////////////////////////////////////////////////////////////
        private void MainForm_Load(object sender, EventArgs e)
        {
            _remoteServiceManagerClient = new RemoteServiceManagerClient("NetTcpBinding_IRemoteServiceManager");
            _services = _remoteServiceManagerClient.GetServices();
            ConfigureGrid();
            RefreshUi();
        }
        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (_remoteServiceManagerClient != null && _remoteServiceManagerClient.State != CommunicationState.Faulted)
            {
                _remoteServiceManagerClient.Close();
            }
        }
        private void servicesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshUi();
        }
        private void startServiceBtn_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
                throw new InvalidOperationException("Service is not selected!");

            try
            {
                UpdateSingleServiceInfo(_remoteServiceManagerClient.StartService(_selectedService.ServiceName));
            }
            catch (Exception ex)
            {
                if (_remoteServiceManagerClient.State == CommunicationState.Faulted)
                {
                    _remoteServiceManagerClient.Abort();
                    _remoteServiceManagerClient = new RemoteServiceManagerClient("NetTcpBinding_IRemoteServiceManager");
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RefreshUi();
            }
        }
        private void stopServiceBtn_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
                throw new InvalidOperationException("Service is not selected!");

            try
            {
                UpdateSingleServiceInfo(_remoteServiceManagerClient.StopService(_selectedService.ServiceName));
            }
            catch (Exception ex)
            {
                if (_remoteServiceManagerClient.State == CommunicationState.Faulted)
                {
                    _remoteServiceManagerClient.Abort();
                    _remoteServiceManagerClient = new RemoteServiceManagerClient("NetTcpBinding_IRemoteServiceManager");
                }
                MessageBox.Show(ex.Message);
            }
            finally
            {
                RefreshUi();
            }
        }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        private void UpdateSingleServiceInfo(ServiceInfo updatedService)
        {
            var selectedService = _services.First(x => x.ServiceName == updatedService.ServiceName);
            selectedService.CanStop = updatedService.CanStop;
            selectedService.DisplayName = updatedService.DisplayName;
            selectedService.ExtensionData = updatedService.ExtensionData;
            selectedService.Status = updatedService.Status;
        }
        private void ConfigureGrid()
        {
            servicesGridView.DataSource = new BindingSource()
            {
                DataSource = _services
            };
            servicesGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            servicesGridView.MultiSelect = false;

            servicesGridView.Columns[0].Visible = false;
        }
        private void RefreshUi()
        {
            if (servicesGridView.SelectedRows.Count != 0)
            {
                _selectedService = servicesGridView.SelectedRows[0].Index >= 0 ? _services[servicesGridView.SelectedRows[0].Index] : null;
            }

            if (_selectedService != null)
            {
                if (_selectedService.CanStop)
                {
                    startServiceBtn.Enabled = false;
                    stopServiceBtn.Enabled = true;
                }
                else
                {
                    startServiceBtn.Enabled = true;
                    stopServiceBtn.Enabled = false;
                }
            }
            else
            {
                startServiceBtn.Enabled = false;
                stopServiceBtn.Enabled = false;
            }
        }
    }
}
