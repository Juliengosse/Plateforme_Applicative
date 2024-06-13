using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application_desktop
{
    internal class MainMenuStrip : MenuStrip
    {
        public MainMenuStrip() {

            Name = "MainMenuStrip";
            Dock = DockStyle.Top;
            BackColor = Color.Black;
            ForeColor = Color.White;

            createMenuStrip();
        }

        //Creation du menu strip
        public void createMenuStrip()
        {
            ToolStripMenuItem home = new ToolStripMenuItem("Accueil");

            ToolStripMenuItem dashboardDropDownMenu = new ToolStripMenuItem("Tableau de bord");

            ToolStripMenuItem studentDashboard = new ToolStripMenuItem("Tableau de bord élèves", null, null, Keys.Control | Keys.D);
            ToolStripMenuItem classDashboard = new ToolStripMenuItem("Tableau de bord groupes", null, null, Keys.Control | Keys.F);

            dashboardDropDownMenu.DropDownItems.AddRange(new ToolStripDropDownItem[] { studentDashboard, classDashboard });

            Items.Add(home);
            Items.Add(dashboardDropDownMenu);

            studentDashboard.Click += (sender, e) => { studentDashboardClick();  };
            classDashboard.Click += (sender, e) => { classDashboardClick(); };
            home.Click += (sender, e) => { homeClick(); };
        }

        //Action pour aller vers le dashboard élève
        public void studentDashboardClick()
        {
            Form parentForm = this.FindForm();
            parentForm.Close();

            StudentList listStudent = new StudentList();
            listStudent.Show();
        }

        //Action pour aller vers le dashboard classe
        public void classDashboardClick()
        {
            Form parentForm = this.FindForm();
            parentForm.Close();

            GroupList listClass = new GroupList();
            listClass.Show();
        }

        //Action pour retourner à l'accueil
        public void homeClick()
        {
            Form parentForm = this.FindForm();
            parentForm.Close();

            Login home = new Login();
            home.Show();
        }
    }
}
