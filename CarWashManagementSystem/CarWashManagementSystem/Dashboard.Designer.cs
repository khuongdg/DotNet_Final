namespace CarWashManagementSystem
{
    partial class Dashboard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chartRevenue = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.dtToDashboard = new System.Windows.Forms.DateTimePicker();
            this.label2 = new System.Windows.Forms.Label();
            this.dtFromDashboard = new System.Windows.Forms.DateTimePicker();
            this.label1 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).BeginInit();
            this.SuspendLayout();
            // 
            // chartRevenue
            // 
            chartArea1.Name = "ChartArea1";
            this.chartRevenue.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            this.chartRevenue.Legends.Add(legend1);
            this.chartRevenue.Location = new System.Drawing.Point(120, 42);
            this.chartRevenue.Name = "chartRevenue";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            this.chartRevenue.Series.Add(series1);
            this.chartRevenue.Size = new System.Drawing.Size(785, 375);
            this.chartRevenue.TabIndex = 0;
            this.chartRevenue.Text = "chart1";
            // 
            // dtToDashboard
            // 
            this.dtToDashboard.CustomFormat = "dd/MM/yyyy";
            this.dtToDashboard.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtToDashboard.Location = new System.Drawing.Point(288, 6);
            this.dtToDashboard.Name = "dtToDashboard";
            this.dtToDashboard.Size = new System.Drawing.Size(116, 30);
            this.dtToDashboard.TabIndex = 7;
            this.dtToDashboard.ValueChanged += new System.EventHandler(this.dtToDashboard_ValueChanged);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(250, 9);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(40, 21);
            this.label2.TabIndex = 6;
            this.label2.Text = "To :";
            // 
            // dtFromDashboard
            // 
            this.dtFromDashboard.CustomFormat = "dd/MM/yyyy";
            this.dtFromDashboard.Format = System.Windows.Forms.DateTimePickerFormat.Custom;
            this.dtFromDashboard.Location = new System.Drawing.Point(128, 6);
            this.dtFromDashboard.Name = "dtFromDashboard";
            this.dtFromDashboard.Size = new System.Drawing.Size(116, 30);
            this.dtFromDashboard.TabIndex = 5;
            this.dtFromDashboard.ValueChanged += new System.EventHandler(this.dtFromDashboard_ValueChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 9);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(133, 21);
            this.label1.TabIndex = 4;
            this.label1.Text = "Filter By : From";
            // 
            // Dashboard
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(967, 458);
            this.Controls.Add(this.dtToDashboard);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.dtFromDashboard);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.chartRevenue);
            this.Font = new System.Drawing.Font("Century Gothic", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Dashboard";
            this.Text = "Dashboard";
            this.Load += new System.EventHandler(this.Dashboard_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chartRevenue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chartRevenue;
        private System.Windows.Forms.DateTimePicker dtToDashboard;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DateTimePicker dtFromDashboard;
        private System.Windows.Forms.Label label1;
    }
}