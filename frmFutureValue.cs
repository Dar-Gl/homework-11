using System;
using System.Diagnostics;
using System.Windows.Forms;

namespace FutureValue
{
    public partial class frmFutureValue : Form
    {
        public frmFutureValue()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, EventArgs e)
        {
            try
            {
                decimal monthlyInvestment = Convert.ToDecimal(txtMonthlyInvestment.Text);
                decimal yearlyInterestRate = Convert.ToDecimal(txtInterestRate.Text);
                int years = Convert.ToInt32(txtYears.Text);

                int months = years * 12;
                decimal monthlyInterestRate = yearlyInterestRate / 12 / 100;

                Debug.WriteLine("Monthly investment: " + monthlyInvestment);
                Debug.WriteLine("Yearly interest rate: " + yearlyInterestRate);
                Debug.WriteLine("Months: " + months);

                decimal futureValue = CalculateFutureValue(monthlyInvestment, monthlyInterestRate, months);

                Debug.WriteLine("Future value: " + futureValue);

                txtFutureValue.Text = futureValue.ToString("c");
                txtMonthlyInvestment.Focus();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message + "\n\n" +
                    ex.GetType().ToString() + "\n" +
                    ex.StackTrace, "Exception");
            }
        }

        private decimal CalculateFutureValue(decimal monthlyInvestment, decimal monthlyInterestRate, int months)
        {
            decimal futureValue = 0;

            for (int i = 0; i < months; i++)
            {
                futureValue = (futureValue + monthlyInvestment)
                    * (1 + monthlyInterestRate);

                Debug.WriteLine("The future value for year " +
                    ((i + 1) / 12) + " is " + futureValue);
            }

            return futureValue;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}