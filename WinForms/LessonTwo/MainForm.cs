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

namespace LessonTwo
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();


        }

        private void Form1_Load(object sender, EventArgs e)
        {
            listBoxCities.Items.Add(new City() {Id = 1, Name="Minsk" });
            listBoxCities.Items.Add(new City() { Id = 1, Name = "Brest" });
            listBoxCities.Items.Add(new City() { Id = 1, Name = "Gomel" });

            var worker = new BackgroundWorker();
            worker.DoWork += worker_DoWork;
            worker.RunWorkerAsync();
        }

        void worker_DoWork(object sender, DoWorkEventArgs e)
        {
            for (var i = 1; i < 11; i++)
            {
                this.Invoke((MethodInvoker)delegate { 
                progressBarMain.Value += 10;
                });
               Thread.Sleep(1000);
            }
 
            //MessageBox.Show("Hello from another thread!");
        }
        private void listBoxCities_SelectedIndexChanged(object sender, EventArgs e)
        {
            City.CalcBalance();
            var list = new List<string>();
            foreach (City i in listBoxCities.SelectedItems)
            {
                list.Add(i.Name);
            }
            toolStripStatusLabelCities.Text = string.Format("Мы едим в {0}", string.Join(",", list));
        }

        private void hScrollBarForProgress_ValueChanged(object sender, EventArgs e)
        {
            this.BackColor = Color.FromArgb(hScrollBarR.Value,
                hScrollBarGreen.Value, hScrollBarBlue.Value);
            City.CalcBalance();
        }
    }

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public static void CalcBalance(){}
    }
}
