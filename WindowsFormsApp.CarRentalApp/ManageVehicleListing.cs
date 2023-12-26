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
            var cars = carRentalEntities.TypesOfCars
                .Select(x => new { ID = x.Id, CarName = x.Name })
                .ToList();
            gvVehicleList.DataSource = cars;
            gvVehicleList.Columns[0].HeaderText = "ID";
            gvVehicleList.Columns[1].HeaderText = "NAME";
        }

        private void btnAddCar_Click(object sender, EventArgs e)
        {

        }

        private void btnEditCar_Click(object sender, EventArgs e)
        {

        }

        private void btnDeleteCar_Click(object sender, EventArgs e)
        {

        }
    }
}
