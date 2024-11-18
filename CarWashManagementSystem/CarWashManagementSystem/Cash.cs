using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarWashManagementSystem
{
    public partial class Cash : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public int customerId = 0, vehicleTypeId = 0;
        public string carno, carmodel;
        MainForm main;
        public Cash(MainForm mainForm)
        {
            InitializeComponent();
            getTransno();
            loadCash();
            main = mainForm;
        }

        public Cash()
        {
        }

        //private void btnAddCustomer_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new CashCustomer(this));
        //    btnAddService.Enabled = true;
        //}

        //private void btnAddService_Click(object sender, EventArgs e)
        //{
        //    openChildForm(new CashService(this));
        //    btnAddCustomer.Enabled = false;
        //}

        //private void btnCash_Click(object sender, EventArgs e)
        //{

        //}

        private void btnAddCustomer_Click(object sender, EventArgs e)
        {
            openChildForm(new CashCustomer(this));
            btnAddService.Enabled = true;
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            openChildForm(new CashService(this));
            btnAddCustomer.Enabled = false;
        }

        private void btnCash_Click(object sender, EventArgs e)
        {
            SettlePayment module = new SettlePayment(this);
            module.txtSale.Text = lblTotal.Text;
            module.ShowDialog();
            main.loadGrossProfit();
        }

        // create a function any form to the panelChild on the mainform

        private Form activeForm = null;
        public void openChildForm(Form childForm)
        {
            if (activeForm != null)
                activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelCash.Height = 200;
            panelCash.Controls.Add(childForm);
            panelCash.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        //{
        //    string colName = dgvCash.Columns[e.ColumnIndex].Name;
        //    if (colName == "Delete") // if you want to delete the record to click the delete icon on the datagridview
        //    {
        //        try
        //        {
        //            if (MessageBox.Show("Are you sure you want to cancle this service?", "Cancel Services", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
        //            {
        //                cm = new SqlCommand("DELETE FROM Cash WHERE id LIKE'" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
        //                dbcon.open();
        //                cm.ExecuteNonQuery();
        //                dbcon.close();
        //                MessageBox.Show("Service has been successfully Canceled!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show(ex.Message, title);
        //        }
        //    }
        //    loadCash();
        //}

        private void dgvCash_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            string colName = dgvCash.Columns[e.ColumnIndex].Name;
            if (colName == "Delete") // if you want to delete the record to click the delete icon on the datagridview
            {
                try
                {
                    if (MessageBox.Show("Are you sure you want to cancle this service?", "Cancel Services", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                    {
                        cm = new SqlCommand("DELETE FROM Cash WHERE id LIKE'" + dgvCash.Rows[e.RowIndex].Cells[1].Value.ToString() + "'", dbcon.connect());
                        dbcon.open();
                        cm.ExecuteNonQuery();
                        dbcon.close();
                        MessageBox.Show("Service has been successfully Canceled!", title, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, title);
                }
            }
            loadCash();
        }

        // Create a function for transatoin generator depend on date

        public void getTransno()
        {
            try
            {
                string sdate = DateTime.Now.ToString("yyyyMMdd");
                int count;
                string transno;


                dbcon.open();
                cm = new SqlCommand("SELECT TOP 1 transno FROM Cash WHERE transno LIKE '" + sdate + "%' ORDER BY id DESC", dbcon.connect());
                dr = cm.ExecuteReader();
                dr.Read();

                if (dr.HasRows)
                {
                    transno = dr[0].ToString();
                    count = int.Parse(transno.Substring(8, 4));
                    lblTransno.Text = sdate + (count + 1);
                }
                else
                {
                    transno = sdate + "1001";
                    lblTransno.Text = transno;
                }

                dbcon.close();
                dr.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        public void loadCash()
        {
            int i = 0;
            double total = 0;
            double price = 0;
            dgvCash.Rows.Clear();
            cm = new SqlCommand("SELECT ca.id,ca.transno,cu.name,cu.carno,cu.carmodel,v.name,v.class,s.name,ca.price,ca.date FROM Cash AS Ca " +
                "LEFT JOIN Customer AS Cu ON CA.cid = Cu.id LEFT JOIN Service AS s ON CA.sid = s.id LEFT JOIN VehicleType AS v ON Ca.vid = v.id WHERE status LIKE 'Pending' AND Ca.transno='"+lblTransno.Text+"'", dbcon.connect());
            dbcon.open();
            dr = cm.ExecuteReader();
            while (dr.Read())
            {
                i++;
                price = int.Parse(dr[6].ToString()) * double.Parse(dr[8].ToString());
                dgvCash.Rows.Add(i, dr[0].ToString(), dr[1].ToString(), dr[2].ToString(), dr[3].ToString(), dr[4].ToString(), dr[5].ToString(), dr[6].ToString(), dr[7].ToString(), price, dr[9].ToString());
                total += price;
                carno = dr[3].ToString();
                carmodel = dr[4].ToString();
            }

            dr.Close();
            dbcon.close();
            lblTotal.Text = total.ToString("#,##0.00");
        }

        private void lblTotal_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lblTransno_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panelCash_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void btnPrintReceipt_Click(object sender, EventArgs e)
        {
            if (dgvCash.CurrentRow != null)
            {
                // Lấy thông tin từ dòng được chọn
                string transactionNo = dgvCash.CurrentRow.Cells["TransactionNoColumn"].Value.ToString();
                string customerName = dgvCash.CurrentRow.Cells["CustomerNameColumn"].Value.ToString();
                string date = DateTime.Now.ToString("MM/dd/yyyy HH:mm:ss");

                // Tạo nội dung hóa đơn
                string receiptContent = generateReceiptContent(transactionNo, customerName, date);

                // Hiển thị hộp thoại in
                PrintDocument printDocument = new PrintDocument();
                printDocument.PrintPage += (s, ev) =>
                {
                    // Tạo font chữ đậm cho tiêu đề
                    Font boldFont = new Font("Courier New", 14, FontStyle.Bold);
                    Font regularFont = new Font("Courier New", 12, FontStyle.Regular);

                    // Vẽ tiêu đề đậm
                    ev.Graphics.DrawString("    CAR WASH MANAGEMENT SYSTEM         ", boldFont, Brushes.Black, new PointF(10, 10));

                    // Tạo khoảng trắng sau tiêu đề
                    int spaceHeight = 125; // Khoảng cách giữa tiêu đề và phần còn lại, điều chỉnh ở đây
                    ev.Graphics.DrawString(new string(' ', spaceHeight), regularFont, Brushes.Black, new PointF(10, 40));

                    // Sử dụng font chữ thường cho phần còn lại
                    ev.Graphics.DrawString(receiptContent, regularFont, Brushes.Black, new PointF(10, 40));
                };

                PrintDialog printDialog = new PrintDialog();
                printDialog.Document = printDocument;

                if (printDialog.ShowDialog() == DialogResult.OK)
                {
                    printDocument.Print(); // In hóa đơn
                }
            }
            else
            {
                MessageBox.Show("Please select a transaction to print the receipt!", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private string generateReceiptContent(string transactionNo, string customerName, string date)
        {
            StringBuilder sb = new StringBuilder();

            // Thêm tiêu đề và khoảng cách
            sb.AppendLine($"Transaction No: {transactionNo}");
            sb.AppendLine($"Customer Name : {customerName}");
            sb.AppendLine($"Date          : {date}");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine("Service Name                       Price");
            sb.AppendLine("----------------------------------------");

            // Duyệt qua DataGridView và thêm dịch vụ vào hóa đơn
            foreach (DataGridViewRow row in dgvCash.Rows)
            {
                if (row.Cells["ServiceNameColumn"].Value != null && row.Cells["PriceColumn"].Value != null)
                {
                    string serviceName = row.Cells["ServiceNameColumn"].Value.ToString();
                    string price = row.Cells["PriceColumn"].Value.ToString();

                    // Đảm bảo căn chỉnh các cột một cách đẹp mắt
                    sb.AppendLine($"{serviceName.PadRight(30)} {price.PadLeft(10)}");
                }
            }

            // Thêm khoảng cách giữa các phần
            sb.AppendLine("                                         ");
            sb.AppendLine("                                         ");
            sb.AppendLine("                                         ");
            sb.AppendLine("----------------------------------------");
            sb.AppendLine($"Total: {lblTotal.Text.PadLeft(33)}");
            sb.AppendLine("                                         ");
            sb.AppendLine("                                         ");
            sb.AppendLine("-------THANK YOU FOR YOUR CHOICE!--------");

            return sb.ToString();
        }


        private void panelCash_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        
    }
}
