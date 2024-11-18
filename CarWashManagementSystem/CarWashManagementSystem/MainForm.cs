using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            loadGrossProfit();
            openChildForm(new Dashboard());

        }

        private void MainForm_Load(object sender, EventArgs e)
        {

        }

        private void btnDashboard_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnDashboard.Height;
            panelSlide.Top = btnDashboard.Top;
            openChildForm(new Dashboard());
        }

        private void btnSetting_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnSetting.Height;
            panelSlide.Top = btnSetting.Top;
            openChildForm(new Setting(this));
        }

        private void btnCustomer_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnCustomer.Height;
            panelSlide.Top = btnCustomer.Top;
            openChildForm(new Customer());
        }

        private void btnService_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnService.Height;
            panelSlide.Top = btnService.Top;
            openChildForm(new Service());
        }

        private void btncash_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btncash.Height;
            panelSlide.Top = btncash.Top;
            openChildForm(new Cash(this));
        }

        private void btnEmployer_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnEmployer.Height;
            panelSlide.Top = btnEmployer.Top;
            openChildForm(new Employer());
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnReport.Height;
            panelSlide.Top = btnReport.Top;
            openChildForm(new Report());
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            panelSlide.Height = btnLogout.Height;
            panelSlide.Top = btnLogout.Top;
            if (MessageBox.Show("Logout Application?", "Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Hide();
                Login login = new Login();
                login.ShowDialog();
            }
        }

        #region method
        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelChild.Controls.Add(childForm);
            panelChild.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        // to extract data for dashboard
        // to show only seven day
        public void loadGrossProfit()
        {
            Report module = new Report();
            lblRevenus.Text = module.extractData("SELECT ISNULL(SUM(price),0) AS total FROM Cash WHERE date >'" + DateTime.Now.AddDays(-7) + "' AND status LIKE 'Sold' ").ToString("#,##0.00");
            lblCostofGood.Text = module.extractData("SELECT ISNULL(SUM(cost),0) AS Cost FROM CostofGood WHERE date > '" + DateTime.Now.AddDays(-7) + "'").ToString("#,##0.00");
            lblGrossProfit.Text = (double.Parse(lblRevenus.Text) - double.Parse(lblCostofGood.Text)).ToString("#,##0.00");

            double revlast7 = module.extractData("SELECT ISNULL(SUM(price),0) AS total FROM Cash WHERE date BETWEEN '" + DateTime.Now.AddDays(-14) + "' AND '" + DateTime.Now.AddDays(-7) + "' AND status LIKE 'Sold' ");
            double coglast7 = module.extractData("SELECT ISNULL(SUM(cost),0) AS Cost FROM CostofGood WHERE date BETWEEN  '" + DateTime.Now.AddDays(-14) + "' AND '" + DateTime.Now.AddDays(-7) + "'");
            double gplast7 = revlast7 - coglast7;


            if (gplast7 > double.Parse(lblGrossProfit.Text))
            {
                lblGrossProfit.ForeColor = Color.Red;
            }
            else
            {
                lblGrossProfit.ForeColor = Color.Green;
            }
        }
        #endregion method
    }
}
