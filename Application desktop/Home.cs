using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Application_desktop
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();

            MainMenuStrip menuStrip = new MainMenuStrip();
            //Ajout du menu strip
            Controls.Add(menuStrip);
        }
    }
}
