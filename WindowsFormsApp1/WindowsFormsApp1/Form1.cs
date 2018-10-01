using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();

            
        }

        public void printPDFWithAcrobat()
        {
            string Filepath = @"C:\Users\2908\Downloads\Random.pdf";

            using (PrintDialog Dialog = new PrintDialog())
            {
                Dialog.ShowDialog();
                MessageBox.Show("This gets hit first");
                ProcessStartInfo printProcessInfo = new ProcessStartInfo()
                {
                    Verb = "print",
                    CreateNoWindow = true,
                    FileName = Filepath,
                    WindowStyle = ProcessWindowStyle.Hidden
                };
                MessageBox.Show("This gets hit second");
                Process printProcess = new Process();
                MessageBox.Show("This gets hit third");
                printProcess.StartInfo = printProcessInfo;
                MessageBox.Show("This gets hit fourth");
                try
                {
                    printProcess.Start(); // First error hits here !!!
                    MessageBox.Show("Got here");
                    printProcess.WaitForInputIdle();
                    MessageBox.Show("Looks like it will work");
                    Thread.Sleep(3000);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                

                if (false == printProcess.CloseMainWindow()) // Second error hits here !!!
                {
                    printProcess.Kill();
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                printPDFWithAcrobat(); // Third error hits here
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
