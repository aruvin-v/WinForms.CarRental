using System;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp.CarRentalApp
{
    public partial class AddRentalRecord : Form
    {
        private readonly CarRentalEntities carRentalEntities;
        public AddRentalRecord()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities();
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
                    var rentalRecord = new CarRentalRecord();
                    rentalRecord.CustomerName = customerName;
                    rentalRecord.DateRented = dateRented;
                    rentalRecord.DateReturned = dateReturned;
                    rentalRecord.Cost = (decimal)cost;
                    rentalRecord.TypeOfCarId = (int)cbTypeOfCar.SelectedValue;
                    //Adding(inserting) the collection of changes to the database and saving it
                    carRentalEntities.CarRentalRecords.Add(rentalRecord);
                    carRentalEntities.SaveChanges();

                    MessageBox.Show($"Customer Name: {customerName}\n\r" +
                        $"Cost: {cost}\n\r" +
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

        private void Form1_Load(object sender, EventArgs e)
        {
            //Getting the cars from TypesOfCars table in db
            //var cars = carRentalEntities.TypesOfCars.ToList();
            var cars = carRentalEntities.TypesOfCars
                .Select(x => new {Id = x.Id, Name = x.Make + " " + x.Model})
                .ToList();

            cbTypeOfCar.DisplayMember = "Name";
            cbTypeOfCar.ValueMember = "Id";
            cbTypeOfCar.DataSource = cars;
        }
    }
}
