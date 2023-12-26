using System;
using System.Data;
using System.Linq;
using System.Windows.Forms;

namespace WindowsFormsApp.CarRentalApp
{
    public partial class ManageVehicleListing : Form
    {
        private readonly CarRentalEntities carRentalEntities;
        public ManageVehicleListing()
        {
            InitializeComponent();
            carRentalEntities = new CarRentalEntities();
        }

        private void ManageVehicleListing_Load(object sender, EventArgs e)
        {
            //var cars = carRentalEntities.TypesOfCars.ToList();
            //SELECT Id AS ID, Name AS CarName FROM TypesOfCar
            //var cars = carRentalEntities.TypesOfCars
            //    .Select(x => new { ID = x.Id, CarName = x.Make })
            //    .ToList();
            var cars = carRentalEntities.TypesOfCars
                .Select(x => new
                {
                    Make = x.Make,
                    Model = x.Model,
                    VIN = x.VIN,
                    Year = x.Year,
                    LicensePlateNumber = x.LicensePlateNumber,
                    x.Id
                })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[4].HeaderText = "License Plate Number";
            gvVehicleList.Columns[5].Visible = false;
            //gvVehicleList.Columns[0].HeaderText = "ID";
            //gvVehicleList.Columns[1].HeaderText = "NAME";
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {
            var addEditVehicle = new AddEditVehicle();
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {
            //get Id of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            //Query the database for the record
            var car = carRentalEntities.TypesOfCars.FirstOrDefault(q => q.Id == id);

            //launch AddEditVehicle windoe with data
            var addEditVehicle = new AddEditVehicle(car);
            addEditVehicle.MdiParent = this.MdiParent;
            addEditVehicle.Show();
        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {
            //get Id of selected row
            var id = (int)gvVehicleList.SelectedRows[0].Cells["Id"].Value;

            //Query the database for the record
            var car = carRentalEntities.TypesOfCars.FirstOrDefault(q => q.Id == id);

            //delete vehicle from table
            carRentalEntities.TypesOfCars.Remove(car);
            carRentalEntities.SaveChanges();

            gvVehicleList.Refresh();
        }
    }
}
