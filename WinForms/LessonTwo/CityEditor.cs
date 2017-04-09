using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LessonTwo
{
    public partial class CityEditor : Form
    {
        public event EventHandler OnUserClickOk;

        protected City CurrentCity = null;

        private CityEditor(): this(new City())
        {
            
        }

        private CityEditor(City city)
        {
            InitializeComponent();
            CurrentCity = city;
            this.CityName.Text = city.Name;
        }

        public static CityEditor GetEditorForNewCity()
        {
            return new CityEditor();
        }

        public static CityEditor GetEditorForCity(City city)
        {
            return new CityEditor(city);
        }

        public City GetCity()
        {
            CurrentCity.Name = this.CityName.Text;
            return CurrentCity;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (OnUserClickOk != null)
            {
                OnUserClickOk(this, EventArgs.Empty);
            }
        }
    }
}
