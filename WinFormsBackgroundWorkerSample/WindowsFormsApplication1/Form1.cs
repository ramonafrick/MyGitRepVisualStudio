using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication1
{
    public partial class Form1 : Form
    {
        BackgroundWorker worker = new BackgroundWorker();

        public Form1()
        {
            InitializeComponent();

            worker.DoWork += new DoWorkEventHandler(DoWork);

        }

        private void btnStart_Click(object sender, EventArgs e)
        {
            int zahl;
            Int32.TryParse(tbxMaxZahl.Text, out zahl);
            worker.RunWorkerAsync(zahl);
        }


        private void DoWork(object sender, DoWorkEventArgs e)
        {
            try
            {
                for (int i = 0; i <= (int)e.Argument; i++)
                {
                    this.Invoke(new EventHandler(delegate
                        {
                            lblOutput.Text = string.Format("processing {0}\r\n", i.ToString());
                        }));
                    Thread.Sleep(200);
                }
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
