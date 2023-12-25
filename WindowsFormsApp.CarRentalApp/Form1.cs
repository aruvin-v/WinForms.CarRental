using System;
using System.Data.Common;
using System.Windows.Forms;

namespace WindowsFormsApp.CarRentalApp
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                //Storing the inputs in a variable
                string customerName = tbCustomerName.Text;
                var dateRented = dtRented.Value;
                var dateReturned = dtReturned.Value;
                double cost = Convert.ToDouble(tbCost.Text);

                var typeOfCar = cbTypeOfCar.Text;
                var isValid = true;
                var errorMessage = string.Empty;

                //Checking some conditions
                if (string.IsNullOrWhiteSpace(customerName) || string.IsNullOrWhiteSpace(typeOfCar))
                {
                    errorMessage += "Please enter missing data\n\r";
                    isValid = false;
                }
                if (dateRented > dateReturned)
                {
                    errorMessage += "Invalid date selection!\n\r";
                    isValid = false;
                }
                //Printing output in a messasge box
                //if (isValid == true)
                if (isValid)
                {
                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                        $"Cost: {cost}" +
                        $"Date Rented: {dateRented}\n\r" +
                        $"Date Returned: {dateReturned}\n\r" +
                        $"Car Type: {typeOfCar}\n\r" +
                        $"Thank you for Renting!");
                }
                else
                {
                    //Showing all error messages in the Message box
                    MessageBox.Show(errorMessage);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
