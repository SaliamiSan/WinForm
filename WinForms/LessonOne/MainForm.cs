using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonOne
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void MainForm_Shown(object sender, EventArgs e)
        {
    //        var result = MessageBox.Show("Hello World!\nHi!", "First Lesson",
    //MessageBoxButtons.YesNo, MessageBoxIcon.Information);

    //        MessageBox.Show("You say " + result.ToString());
        }

        private void MainForm_MouseMove(object sender, MouseEventArgs e)
        {
           
        }

        private void timerForShowingTime_Tick(object sender, EventArgs e)
        {
            var dateTimeNow = DateTime.Now;
            dateTimeNow = dateTimeNow.AddHours(1);
            labelResult.Text = dateTimeNow.ToString();
        }
    }
}
