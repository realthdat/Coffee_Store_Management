using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using FastReport.DataVisualization.Charting;

namespace GUI
{
    public partial class Dashboard : UserControl
    {

        private BUS_Bill busBill = new BUS_Bill();

        public Dashboard()
        {
            InitializeComponent();
            LoadDashboardData();
        }

        private void LoadDashboardData()
        {
            LoadTotalBillChart();
            LoadTotalPriceChart();
        }

        // Method to load total bill data into the chart
        private void LoadTotalBillChart()
        {
            // Fetching total bill data
            int totalBillsToday = busBill.GetTotalBillsByDate(DateTime.Today);
            int totalBillsAllTime = busBill.GetTotalBillsAllTime();

            // Clear any existing chart series and titles
            chartTotalBills.Series.Clear();
            chartTotalBills.Titles.Clear();

            // Add a title to the chart
            chartTotalBills.Titles.Add("Total Bills");

            // Check if the chart already has a chart area; if not, add one
            if (chartTotalBills.ChartAreas.Count == 0)
            {
                chartTotalBills.ChartAreas.Add(new ChartArea("BillChartArea"));
            }

            // Create a new series for the bill data (Pie chart type)
            Series series = new Series("Bills")
            {
                ChartType = SeriesChartType.Pie,     // Pie chart
                IsValueShownAsLabel = true           // Display values on the chart
            };

            // Add data points for today's bills and all-time bills
            series.Points.AddXY("Today", totalBillsToday);
            series.Points.AddXY("All Time", totalBillsAllTime);

            // Customize chart properties if needed (optional)
            chartTotalBills.ChartAreas[0].AxisX.Title = "Time Period";
            chartTotalBills.ChartAreas[0].AxisY.Title = "Total Bills";

            // Add the series to the chart
            chartTotalBills.Series.Add(series);

            // Refresh the chart to display the updated data
            chartTotalBills.Invalidate();
        }


        private void LoadTotalPriceChart()
        {
            // Fetching total price data
            decimal totalPriceToday = busBill.GetTotalPriceByDate(DateTime.Today);
            decimal totalPriceAllTime = busBill.GetTotalPriceAllTime();

            // Clear any existing chart series and titles
            chartTotalPrice.Series.Clear();
            chartTotalPrice.Titles.Clear();

            // Add a title to the chart
            chartTotalPrice.Titles.Add("Total Income");

            // Check if the chart already has a chart area; if not, add one
            if (chartTotalPrice.ChartAreas.Count == 0)
            {
                chartTotalPrice.ChartAreas.Add(new ChartArea("PriceChartArea"));
            }

            // Create a new series for the price data (Bar/Column chart type)
            Series series = new Series("Prices")
            {
                ChartType = SeriesChartType.Column,  // Bar chart
                IsValueShownAsLabel = true,          // Display values on the chart
                LabelFormat = "C"                    // Format label as currency
            };

            // Add data points for today's prices and all-time prices
            series.Points.AddXY("Today Income", totalPriceToday);
            series.Points.AddXY("All Time", totalPriceAllTime);

            // Customize chart axes (optional)
            chartTotalPrice.ChartAreas[0].AxisX.Title = "";
            chartTotalPrice.ChartAreas[0].AxisY.Title = "U.S Dollar";
            chartTotalPrice.ChartAreas[0].AxisY.LabelStyle.Format = "C"; // Currency format

            // Add the series to the chart
            chartTotalPrice.Series.Add(series);

            // Refresh the chart to display the updated data
            chartTotalPrice.Invalidate();
        }

    }
}
