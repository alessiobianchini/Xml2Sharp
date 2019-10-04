using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Runtime.InteropServices;
using System.Windows.Forms;

namespace Xml2Sharp
{
    public partial class Form1 : Form
    {
        private string filePath = string.Empty;
        private string fileName = "classes";
        private ClassInfoWriter classInfoWriter;
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            label1.Text += RuntimeInformation.FrameworkDescription;
        }

        /// <summary> 
        /// Every label's Click event is handled by this event handler.
        /// </summary> 
        /// <param name="sender">The label that was clicked.</param>
        /// <param name="e"></param>
        private void Btn_Click(object sender, EventArgs e)
        {
            // File input
            OpenFileDialog fd = new OpenFileDialog();
            fd.FileName = "Select intput file";
            if (fd.ShowDialog() == DialogResult.OK)
            {
                filePath = fd.FileName;
                fileName = Path.GetFileName(filePath);
                this.label2.Text = fileName;
                this.label2.Show();
                Console.WriteLine("File name: " + fileName);
                this.SelectFileButton.Visible = false;
                this.StartConversionButton.Show();
            }
        }
        private void Convert(object sender, EventArgs e)
        {
            Cursor.Current = Cursors.WaitCursor;
            this.StartConversionButton.Visible = false;
            try
            {
                var xml = File.ReadAllText(filePath);
                var classInfo = new Xml2CSharpConverer().Convert(xml);

                if (classInfo != null)
                {
                    classInfoWriter = new ClassInfoWriter(classInfo);
                    this.label2.ForeColor = Color.Green;
                    this.label2.Text += " Converted";
                    this.downloadButton.Show();
                }
                else
                {
                    this.label2.Text += " Conversion Error";
                    this.label2.ForeColor = Color.Red;
                }
            }
            catch
            {
                this.label2.ForeColor = Color.Red;
            }
            this.newConversionButton.Show();
            Cursor.Current = Cursors.Default;
        }
        private void Download(object sender, EventArgs e)
        {
            SaveFileDialog saveFileDialog1 = new SaveFileDialog();
            saveFileDialog1.Filter = "Text files (*.txt)|*.txt|All files (*.*)|*.*";
            saveFileDialog1.Title = "Save File";
            saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            saveFileDialog1.FileName = fileName + ".txt";
            DialogResult result = saveFileDialog1.ShowDialog();

            // If the file name is not an empty string open it for saving.
            if (saveFileDialog1.FileName != "")
            {
                var fs = saveFileDialog1.OpenFile();
                if (result == DialogResult.OK)
                {
                    classInfoWriter.Write(new StreamWriter(fs));
                }
                fs.Close();
            }
        }
        private void NewConversion(object sender, EventArgs e)
        {
            this.downloadButton.Visible = false;
            this.newConversionButton.Visible = false;
            this.label2.Visible = false;
            this.label2.ForeColor = Color.Orange;
            this.SelectFileButton.Show();
        }
    }
}