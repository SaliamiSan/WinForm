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
        Dictionary<string, string> DefaultValue = new Dictionary<string, string>();

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

            foreach(var c in this.Controls)
            {
                var textBox = c as TextBox;
                if (textBox !=null)
                {
                    DefaultValue.Add(textBox.Name, textBox.Text);
                }
            }
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

        private void toolStripMenuItem2_Click(object sender, EventArgs e)
        {
            var form = CityEditor.GetEditorForNewCity();
            form.OnUserClickOk += form_OnUserClickOk;
            
            if(form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                var city = form.GetCity();
                listBoxCities.Items.Add(city);
            }
            form.OnUserClickOk -= form_OnUserClickOk;
        }

        void form_OnUserClickOk(object sender, EventArgs e)
        {
            MessageBox.Show((sender as CityEditor).GetCity().Name);
        }

        private void listBoxCities_DoubleClick(object sender, EventArgs e)
        {
            var city = listBoxCities.SelectedItem as City;
            if (city != null)
            {
                var form = CityEditor.GetEditorForCity(city);
                if (form.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    //var city = form.GetCity();
                    MessageBox.Show(form.GetCity().Name);
                }
            }
        }

        private void printPreviewToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunChangeColorProcess();
        }

        protected void RunChangeColorProcess()
        {
            if(colorDialogMain.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                this.BackColor = colorDialogMain.Color;
            }
        }

        private void dynamicToolStripMenuItem_DropDownOpening(object sender, EventArgs e)
        {
            var toolStrip = (ToolStripMenuItem)sender;
            var toopStripItem = new ToolStripMenuItem();
            toopStripItem.Text = "New item";
            toopStripItem.Click += (x, y) =>
            {
                MessageBox.Show("New item was clicked");
            };
            toolStrip.DropDownItems.Add(toopStripItem);
        }

        private void viewHeloToolStripMenuItem_Click(object sender, EventArgs e)
        {
            RunChangeColorProcess();
            MessageBox.Show("Мы успешно изменили цвет формы благодаря контекстному меню");
        }

        private void toolStripContainer1_TopToolStripPanel_Click(object sender, EventArgs e)
        {

        }

        private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        {
            foreach (var c in this.Controls)
            {
                var textBox = c as TextBox;
                if (textBox != null)
                {
                    if (DefaultValue.ContainsKey(textBox.Name))
                    {
                        textBox.Text = DefaultValue[textBox.Name];
                    }
                }
            }
        }


    }

    public class City
    {
        public int Id { get; set; }

        public string Name { get; set; }


        public static void CalcBalance(){}
    }
}
