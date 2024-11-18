using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace CarWashManagementSystem
{
    public partial class Dashboard : Form
    {
        SqlCommand cm = new SqlCommand();
        dbConnect dbcon = new dbConnect();
        SqlDataReader dr;
        string title = "Car Wash Management System";
        public Dashboard()
        {
            InitializeComponent();
            LoadRevenueChart();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {

        }

        public void LoadRevenueChart()
        {
            try
            {
                // Clear old data
                chartRevenue.Series.Clear();

                // Thêm series cho doanh thu
                Series revenueSeries = new Series("Revenue");
                revenueSeries.ChartType = SeriesChartType.Line; // Dạng biểu đồ (Line, Column, etc.)
                revenueSeries.Color = System.Drawing.Color.Green; // Màu cho Revenue
                chartRevenue.Series.Add(revenueSeries);

                // Thêm series cho Cost of Goods Sold
                Series costSeries = new Series("Cost of Goods Sold");
                costSeries.ChartType = SeriesChartType.Line; // Dạng biểu đồ (Line, Column, etc.)
                costSeries.Color = System.Drawing.Color.Red; // Màu cho CoGS
                chartRevenue.Series.Add(costSeries);

                // Truy vấn dữ liệu doanh thu theo ngày
                cm = new SqlCommand("SELECT date, ISNULL(SUM(price), 0) AS total FROM Cash WHERE status = 'Sold' GROUP BY date ORDER BY date", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();

                // Thêm dữ liệu vào biểu đồ doanh thu
                while (dr.Read())
                {
                    string date = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                    double totalRevenue = double.Parse(dr[1].ToString());

                    // Thêm điểm dữ liệu vào biểu đồ doanh thu
                    revenueSeries.Points.AddXY(date, totalRevenue);
                }
                dr.Close();

                // Truy vấn dữ liệu Cost of Goods Sold theo ngày
                cm = new SqlCommand("SELECT date, ISNULL(SUM(cost), 0) AS total FROM CostofGood GROUP BY date ORDER BY date", dbcon.connect());
                dbcon.open();
                dr = cm.ExecuteReader();

                // Thêm dữ liệu vào biểu đồ Cost of Goods Sold
                while (dr.Read())
                {
                    string date = DateTime.Parse(dr[0].ToString()).ToShortDateString();
                    double totalCost = double.Parse(dr[1].ToString());

                    // Thêm điểm dữ liệu vào biểu đồ Cost of Goods Sold
                    costSeries.Points.AddXY(date, totalCost);
                }
                dr.Close();

                dbcon.close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, title);
            }
        }

        private void dtFromDashboard_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueChart();
        }

        private void dtToDashboard_ValueChanged(object sender, EventArgs e)
        {
            LoadRevenueChart();
        }
    }
}
