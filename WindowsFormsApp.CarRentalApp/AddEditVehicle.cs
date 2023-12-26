using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp.CarRentalApp
{
    public partial class AddEditVehicle : Form
    {
        private bool isEditMode;
        private readonly CarRentalEntities carRentalEntities = new CarRentalEntities();
        public AddEditVehicle()
        {
            InitializeComponent();
            lblTitle.Text = "Add New Vehicle";
            isEditMode = false;
        }
        public AddEditVehicle(TypesOfCar carToEdit)
        {
            InitializeComponent();
            lblTitle.Text = "Edit Vehicle";
            isEditMode = true;
            PopulateVehicles(carToEdit);
        }

        private void PopulateVehicles(TypesOfCar car)
        {
            lblId.Text = car.Id.ToString();
            tbMake.Text = car.Make;
            tbModel.Text = car.Model;
            tbVIN.Text = car.VIN;
            tbYear.Text = car.Year.ToString();
            tbLicense.Text = car.LicensePlateNumber;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (isEditMode)
            {
                //Edit code here
                var id = int.Parse(lblId.Text);
                var car = carRentalEntities.TypesOfCars.FirstOrDefault(x => x.Id == id);
                car.Make = tbMake.Text;
                car.Model = tbModel.Text;
                car.VIN = tbVIN.Text;
                car.Year = int.Parse(tbYear.Text);
                car.LicensePlateNumber = tbLicense.Text;

                carRentalEntities.SaveChanges();
            }
            else
            {
                var newCar = new TypesOfCar
                {
                    LicensePlateNumber = tbLicense.Text,
                    Model = tbModel.Text,
                    Make = tbMake.Text,
                    VIN = tbVIN.Text,
                    Year = int.Parse(tbYear.Text)
                };
                carRentalEntities.TypesOfCars.Add(newCar);
                carRentalEntities.SaveChanges();
            };
            
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
