using System;
using System.ServiceProcess;
using System.Windows.Forms;

namespace Fourth
{
    public partial class MainForm : Form
    {
        private const Int32 TIMEOUT = 5000;
        private ServiceController[] _services;
        private ServiceController _selectedService;


        public MainForm()
        {
            InitializeComponent();
        }


        // UI EVENTS //////////////////////////////////////////////////////////////////////////////
        private void MainForm_Load(object sender, EventArgs e)
        {
            UpdateServices();
        }
        private void servicesGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            RefreshUi();
        }
        private void startServiceBtn_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
                throw new InvalidOperationException("Service is not selected!");

            var service = new ServiceController(_selectedService.ServiceName);
            try
            {
                service.Start();
                service.WaitForStatus(ServiceControllerStatus.Running, TimeSpan.FromMilliseconds(TIMEOUT));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateServices();
            }
        }
        private void stopServiceBtn_Click(object sender, EventArgs e)
        {
            if (_selectedService == null)
                throw new InvalidOperationException("Service is not selected!");

            var service = new ServiceController(_selectedService.ServiceName);
            try
            {
                service.Stop();
                service.WaitForStatus(ServiceControllerStatus.Stopped, TimeSpan.FromMilliseconds(TIMEOUT));
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                UpdateServices();
            }
        }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        private void UpdateServices()
        {
            _services = ServiceController.GetServices();
            ConfigureGrid();
            RefreshUi();
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
            servicesGridView.Columns[1].Visible = false;
            servicesGridView.Columns[2].Visible = false;
            servicesGridView.Columns[6].Visible = false;
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
