using System;
using System.IO;
using System.Text;
using System.Windows.Forms;

namespace Third
{
    public partial class MainForm : Form
    {
        private const String FILE_EXTENSION_FILTER = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
        private String _filePath;


        public MainForm()
        {
            InitializeComponent();
        }


        // UI EVENTS //////////////////////////////////////////////////////////////////////////////
        private void openToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var openDialog = new OpenFileDialog();
            openDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            openDialog.Filter = FILE_EXTENSION_FILTER;
            openDialog.Title = "Please select a file to edit.";

            if (openDialog.ShowDialog() == DialogResult.OK)
            {
                _filePath = openDialog.FileName;
                richTextBox.Text = ReadFile();
            }
        }
        private void saveToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (_filePath == null)
            {
                var saveDialog = new SaveFileDialog();
                saveDialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                saveDialog.Filter = FILE_EXTENSION_FILTER;
                saveDialog.Title = "Please select a location.";

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    _filePath = saveDialog.FileName;
                }
                else
                {
                    return;
                }
            }

            ReWriteFile(richTextBox.Text);
        }
        private void toApperToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = richTextBox.Text.ToUpper();
        }
        private void toLowerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox.Text = richTextBox.Text.ToLower();
        }
        private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }


        // FUNCTIONS //////////////////////////////////////////////////////////////////////////////
        private String ReadFile()
        {
            using (var stream = new FileStream(_filePath, FileMode.OpenOrCreate, FileAccess.Read))
            {
                using (var reader = new StreamReader(stream, Encoding.Default))
                {
                    return reader.ReadToEnd();
                }
            }
        }
        private void ReWriteFile(String text)
        {
            using (var stream = new FileStream(_filePath, FileMode.Create, FileAccess.Write))
            {
                using (var reader = new StreamWriter(stream, Encoding.Default))
                {
                    reader.Write(text);
                }
            }
        }
    }
}