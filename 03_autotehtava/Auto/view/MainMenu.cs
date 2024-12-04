using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using Autokauppa.controller;
using Autokauppa.model;



namespace Autokauppa.view
{
    public partial class MainMenu : Form
    {
        private List<Auto> autoList;
        private Dictionary<decimal, List<Auto>> groupedCarsByPrice;
        private decimal currentPrice;
        KaupanLogiikka registerHandler;
        private List<Auto> filteredCarsByBrand = new List<Auto>();


        public MainMenu()
        {
            registerHandler = new KaupanLogiikka();
            InitializeComponent();
            LoadAutoMakers();
            SearchForPolttoaine();
            SearchForVari();
            LoadCars();
            DisplayCarsByPrice(groupedCarsByPrice[currentPrice]);
            AddLabels();
        }

        private void AddLabels()
        {
            // Create new labels for each field
            Label lblID = new Label();
            Label lblHinta = new Label();
            Label lblRekisteriPaivamaara = new Label();
            Label lblMoottorinTilavuus = new Label();
            Label lblMittarilukema = new Label();

            // Set properties for each label
            lblID.Text = "ID";
            lblHinta.Text = "Hinta";
            lblRekisteriPaivamaara.Text = "Rekisteri Paivamaara";
            lblMoottorinTilavuus.Text = "Moottorin Tilavuus";
            lblMittarilukema.Text = "Mittarilukema";

            // Adjust the location of the labels so they are above the textboxes
            lblID.Location = new Point(15, 20);
            lblHinta.Location = new Point(15, 60);
            lblRekisteriPaivamaara.Location = new Point(15, 100);
            lblMoottorinTilavuus.Location = new Point(15, 140);
            lblMittarilukema.Location = new Point(15, 180);

            // Optionally, set other properties such as size or font
            lblID.AutoSize = true;
            lblHinta.AutoSize = true;
            lblRekisteriPaivamaara.AutoSize = true;
            lblMoottorinTilavuus.AutoSize = true;
            lblMittarilukema.AutoSize = true;

            // Add the labels to the GroupBox instead of the Form
            this.gbAuto.Controls.Add(lblID);
            this.gbAuto.Controls.Add(lblHinta);
            this.gbAuto.Controls.Add(lblRekisteriPaivamaara);
            this.gbAuto.Controls.Add(lblMoottorinTilavuus);
            this.gbAuto.Controls.Add(lblMittarilukema);

            // Refresh the form to ensure the labels are displayed
            this.Refresh();
        }

        private void testaaTietokantaaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            KaupanLogiikka kaupanLogiikka = new KaupanLogiikka();
            bool connectionSuccess = kaupanLogiikka.TestDatabaseConnection();

            if (connectionSuccess)
            {
                MessageBox.Show("Yhteys tietokantaan onnistui.");
            }
            else
            {
                MessageBox.Show("Tietokannan yhteys epäonnistui.");
            }
        }

        private void btnLisaa_Click(object sender, EventArgs e)
        {
            try
            {
                Auto newAuto = new Auto()
                {

                    Hinta = Convert.ToDecimal(tbHinta.Text),
                    RekisteriPaivamaara = dtpPaiva.Value,
                    MoottorinTilavuus = Convert.ToDecimal(tbTilavuus.Text),
                    Mittarilukema = Convert.ToInt32(tbMittarilukema.Text),
                    MerkkiID = Convert.ToInt32(cbMerkki.SelectedValue),
                    MalliID = Convert.ToInt32(cbMalli.SelectedValue),
                    VariID = Convert.ToInt32(cbVari.SelectedValue),
                    PolttoaineID = Convert.ToInt32(cbPolttoaine.SelectedValue)
                };

                // Now, calling the save method for the Auto object
                bool isSaved = registerHandler.saveAuto(newAuto);
                if (isSaved)
                {
                    MessageBox.Show("Auto inserted successfully!");
                }
                else
                {
                    MessageBox.Show("There was an error saving the car.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }


        public void exitToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            // Confirm the user wants to exit
            var result = MessageBox.Show("Oletko varma, että haluat poistua?", "Poistu", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();//close the current form
            }
        }


        // this method clears the fields of the form
        public void btnUusitietue_Click(object sender, EventArgs e)
        {
            // Clear the text fields
            tbHinta.Text = string.Empty;
            tbMittarilukema.Text = string.Empty;
            tbTilavuus.Text = string.Empty;
            tbId.Text = string.Empty;

            // Check if ComboBoxes are populated before resetting the index
            // Reset ComboBoxes and clear their text
            cbMerkki.SelectedIndex = -1;
            cbMerkki.Text = string.Empty;

            cbMalli.SelectedIndex = -1;
            cbMalli.Text = string.Empty;

            cbVari.SelectedIndex = -1;
            cbVari.Text = string.Empty;

            cbPolttoaine.SelectedIndex = -1;
            cbPolttoaine.Text = string.Empty;

            // Reset the DateTimePicker to today's date
            dtpPaiva.Value = DateTime.Today;
        }

        public void btnTallenna_Click(object sender, EventArgs e)
        {
            try
            {

                int selectedMerkkiId = (int)cbMerkki.SelectedValue;
                int selectedMalliId = (int)cbMalli.SelectedValue;
                int selectedFuelTypeId = (int)cbPolttoaine.SelectedValue;
                int selectedColorId = (int)cbVari.SelectedValue;

                Auto newAuto = new Auto()
                {
                    Hinta = Convert.ToDecimal(tbHinta.Text),
                    RekisteriPaivamaara = dtpPaiva.Value,
                    MoottorinTilavuus = Convert.ToDecimal(tbTilavuus.Text),
                    Mittarilukema = Convert.ToInt32(tbMittarilukema.Text),
                    MerkkiID = selectedMerkkiId,
                    MalliID = selectedMalliId,
                    VariID = selectedColorId,
                    PolttoaineID = selectedFuelTypeId
                };

                // Now, calling the save method for the Auto object
                bool isSaved = registerHandler.saveAuto(newAuto);
                if (isSaved)
                {
                    MessageBox.Show("Record added successfully!");
                }
                else
                {
                    MessageBox.Show("There was an error saving the Auto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void LoadAutoMakers()
        {
            DatabaseHallinta dbHandler = new DatabaseHallinta();
            List<Merkki> makers = dbHandler.getAllAutoMakersFromDatabase();

            cbMerkki.DisplayMember = "merkki";
            cbMerkki.ValueMember = "ID";
            cbMerkki.DataSource = makers;
        }

        public void cbMerkki_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbMerkki.SelectedItem != null)
            {
                int selectedMakerId = (int)cbMerkki.SelectedValue;
                DatabaseHallinta dbHandler = new DatabaseHallinta();
                List<Malli> models = dbHandler.getAutoModelsByMakerId(selectedMakerId);

                cbMalli.DisplayMember = "Nimi";
                cbMalli.ValueMember = "ID";
                cbMalli.DataSource = models;
            }
        }

        public void SearchForPolttoaine()
        {
            DatabaseHallinta dbHandler = new DatabaseHallinta();
            List<Polttoaine> polttoaineet = dbHandler.GetPolttoaine();

            cbPolttoaine.DisplayMember = "Nimi"; // Display the name of the fuel
            cbPolttoaine.ValueMember = "ID"; // Store the ID as the value
            cbPolttoaine.DataSource = polttoaineet;
        }

        public void SearchForVari()
        {
            DatabaseHallinta dbHandler = new DatabaseHallinta();
            List<Vari> variList = dbHandler.GetVari();

            cbVari.DisplayMember = "Nimi"; // Display the color name
            cbVari.ValueMember = "ID"; // Store the ID as the value
            cbVari.DataSource = variList;
        }

        public void cbPolttoaine_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (cbPolttoaine.SelectedItem != null)
            {
                // get the selected item and perform actions based on it
                var selectedFuelType = cbPolttoaine.SelectedItem as Polttoaine;
                if (selectedFuelType != null)
                {
                    Console.WriteLine($"Selected Fuel Type: {selectedFuelType.Nimi}");
                }
            }
        }

        public void cbVari_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbVari.SelectedItem != null)
            {
                var selectedColor = cbVari.SelectedItem as Vari;
                if (selectedColor != null)
                {
                    Console.WriteLine($"Selected Color: {selectedColor.Nimi}");
                }
            }
        }

        private void btnPoista_Click(object sender, EventArgs e)
        {
            try
            {

                int selectedMerkkiId = (int)cbMerkki.SelectedValue;
                int selectedMalliId = (int)cbMalli.SelectedValue;
                int selectedFuelTypeId = (int)cbPolttoaine.SelectedValue;
                int selectedColorId = (int)cbVari.SelectedValue;

                Auto deleteAuto = new Auto()
                {
                    Hinta = Convert.ToDecimal(tbHinta.Text),
                    RekisteriPaivamaara = dtpPaiva.Value,
                    MoottorinTilavuus = Convert.ToDecimal(tbTilavuus.Text),
                    Mittarilukema = Convert.ToInt32(tbMittarilukema.Text),
                    MerkkiID = selectedMerkkiId,
                    MalliID = selectedMalliId,
                    VariID = selectedColorId,
                    PolttoaineID = selectedFuelTypeId
                };

                // Now, calling the save method for the Auto object
                bool isDeleted = registerHandler.deleteAuto(deleteAuto);
                if (isDeleted)
                {
                    MessageBox.Show("Record deleted successfully!");
                    btnUusitietue_Click(sender, e); // clears all the fields of the form
                }
                else
                {
                    MessageBox.Show("There was an error deleting the Auto.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        public void btnSeuraava_Click(object sender, EventArgs e)
        {
            var sortedPrices = groupedCarsByPrice.Keys.OrderBy(p => p).ToList();
            var currentPriceIndex = sortedPrices.IndexOf(currentPrice);

            if (currentPriceIndex < sortedPrices.Count - 1)
            {
                currentPrice = sortedPrices[currentPriceIndex + 1];
                DisplayCarsByPrice(groupedCarsByPrice[currentPrice]);
            }
            else
            {
                MessageBox.Show("You have reached the most expensive cars.");
            }
        }

        public void btnEdellinen_Click(object sender, EventArgs e)
        {
            var sortedPrices = groupedCarsByPrice.Keys.OrderBy(p => p).ToList();
            var currentPriceIndex = sortedPrices.IndexOf(currentPrice);

            if (currentPriceIndex > 0)
            {
                currentPrice = sortedPrices[currentPriceIndex - 1];
                DisplayCarsByPrice(groupedCarsByPrice[currentPrice]);
            }
            else
            {
                MessageBox.Show("You are at the cheapest cars.");
            }
        }

        // Load cars from the database
        public void LoadCars()
        {
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autotietokanta;Integrated Security=True";
            autoList = new List<Auto>();
            groupedCarsByPrice = new Dictionary<decimal, List<Auto>>();

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    string query = "SELECT ID, Hinta, RekisteriPaivamaara, MoottorinTilavuus, Mittarilukema, MerkkiID, MalliID, VariID, PolttoaineID FROM Auto";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                Auto car = new Auto
                                {
                                    ID = reader.GetInt32(0),
                                    Hinta = reader.GetDecimal(1),
                                    RekisteriPaivamaara = reader.GetDateTime(2),
                                    MoottorinTilavuus = reader.GetDecimal(3),
                                    Mittarilukema = reader.GetInt32(4),
                                    MerkkiID = reader.GetInt32(5),
                                    MalliID = reader.GetInt32(6),
                                    VariID = reader.GetInt32(7),
                                    PolttoaineID = reader.GetInt32(8)
                                };
                                autoList.Add(car);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error: {ex.Message}");
                }
            }

            // Group cars by price
            groupedCarsByPrice = autoList.GroupBy(a => a.Hinta)
                .ToDictionary(g => g.Key, g => g.ToList());

            // Sort cars by price in ascending order
            var sortedPrices = groupedCarsByPrice.Keys.OrderBy(p => p).ToList();

            currentPrice = sortedPrices.First();  // Start with the lowest price
            DisplayCarsByPrice(groupedCarsByPrice[currentPrice]); // Pass the correct List<Auto>
        }


        // Display the car in the form fields
        public void DisplayCarsByPrice(List<Auto> cars)
        {
            DatabaseHallinta dbHandler = new DatabaseHallinta();

            // Fetch all makers (brands) at once
            var makers = dbHandler.getAllAutoMakersFromDatabase();

            // Add columns to DataGridView
            dgvCars.Columns.Clear();
            dgvCars.Columns.Add("ID", "ID");
            dgvCars.Columns.Add("Hinta", "Hinta");
            dgvCars.Columns.Add("Merkki", "Merkki");
            dgvCars.Columns.Add("Malli", "Malli");

            // Loop through cars and add then to the DataGridView
            foreach (var car in cars)
            {
                // Get the maker and model names based on car's MerkkiID and MalliID
                var maker = makers.FirstOrDefault(m => m.ID == car.MerkkiID);
                var model = maker != null ? dbHandler.getAutoModelsByMakerId(maker.ID).FirstOrDefault(m => m.ID == car.MalliID) : null;

                // Add row to DataGridView with the car's details
                dgvCars.Rows.Add(car.ID, car.Hinta, maker?.merkki ?? "Unknown", model?.Nimi ?? "Unknown");
            }
        }


        public void btnSearchByBrand_Click(object sender, EventArgs e)
        {
            string brandText = txtBrand.Text.Trim();  // Get the brand name from the TextBox.

            if (string.IsNullOrEmpty(brandText))
            {
                MessageBox.Show("Please enter a valid brand name.");
                return;
            }

            // Find the selected brands by name
            var dbHandler = new DatabaseHallinta();
            var makers = dbHandler.getAllAutoMakersFromDatabase();  // Get all available brands.

            // Find the brand IDs that match the entered name
            var matchingBrandIds = makers
                .Where(m => m.merkki.Contains(brandText, StringComparison.OrdinalIgnoreCase))
                .Select(m => m.ID)
                .ToList();

            if (!matchingBrandIds.Any())  // If no brands matched, show an error
            {
                MessageBox.Show("No brands match your search.");
                return;
            }

            // Filter the cars by those brand IDs
            filteredCarsByBrand = autoList
                .Where(car => matchingBrandIds.Contains(car.MerkkiID))
                .ToList();

            if (filteredCarsByBrand.Count == 0)
            {
                MessageBox.Show("No cars found for the selected brand.");
                return;
            }

            // Display the filtered cars in the DataGridView
            DisplayCarsByPrice(filteredCarsByBrand);
        }

        public void btnSearchByPrice_Click(object sender, EventArgs e)
        {
            string priceText = txtPrice.Text.Trim();

            // Check if the input is empty
            if (string.IsNullOrEmpty(priceText))
            {
                MessageBox.Show("Please enter a valid price.");
                return;
            }

            // Trying to parse the price value from the TextBox
            decimal price;
            bool isValidPrice = Decimal.TryParse(priceText, out price);

            // Check if the parsing was successful
            if (!isValidPrice)
            {
                MessageBox.Show("Invalid price format. Please enter a valid decimal number.");
                return;
            }

            // If no brand search has been done yet, use all cars
            List<Auto> carsToFilter = filteredCarsByBrand.Count > 0 ? filteredCarsByBrand : autoList;

            // Filter cars by price
            List<Auto> filteredCarsByPrice = carsToFilter
                .Where(car => car.Hinta <= price)
                .ToList();

            // Check if any cars match the price criteria
            if (filteredCarsByPrice.Count == 0)
            {
                MessageBox.Show("No cars found under the specified price.");
                return;
            }

            // Display the filtered cars in the DataGridView
            DisplayCarsByPrice(filteredCarsByPrice);
        }

    }
}
