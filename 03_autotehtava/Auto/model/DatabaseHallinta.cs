using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;




namespace Autokauppa.model
{
    public class DatabaseHallinta
    {
        string yhteysTiedot;
        SqlConnection dbYhteys;

        public DatabaseHallinta()
        {
            yhteysTiedot = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Autotietokanta;Integrated Security=True";
            dbYhteys = new SqlConnection();
        }

        public bool connectDatabase()
        {
            dbYhteys.ConnectionString = yhteysTiedot;

            try
            {
                dbYhteys.Open();
                return true;
            }
            catch (Exception e)
            {
                Console.WriteLine("Virheilmoitukset:" + e);
                dbYhteys.Close();
                return false;

            }

        }

        public void disconnectDatabase()
        {
            dbYhteys.Close();
        }

        public bool saveAutoIntoDatabase(Auto newAuto)
        {
            try
            {
                string query = "INSERT INTO Auto (Hinta, RekisteriPaivamaara, MoottorinTilavuus, Mittarilukema, MerkkiID, MalliID, VariID,  PolttoaineID) " +
                               "VALUES (@Hinta, @RekisteriPaivamaara, @MoottorinTilavuus, @Mittarilukema, @MerkkiID, @MalliID, @VariID, @PolttoaineID)";

                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Hinta", newAuto.Hinta);
                        cmd.Parameters.AddWithValue("@RekisteriPaivamaara", newAuto.RekisteriPaivamaara);
                        cmd.Parameters.AddWithValue("@MoottorinTilavuus", newAuto.MoottorinTilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", newAuto.Mittarilukema);
                        cmd.Parameters.AddWithValue("@MerkkiID", newAuto.MerkkiID);
                        cmd.Parameters.AddWithValue("@MalliID", newAuto.MalliID);
                        cmd.Parameters.AddWithValue("@VariID", newAuto.VariID);
                        cmd.Parameters.AddWithValue("@PolttoaineID", newAuto.PolttoaineID);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the car: " + ex.Message);
                return false;
            }
        }


        public List<Merkki> getAllAutoMakersFromDatabase()
        {
            List<Merkki> autoMakers = new List<Merkki>();
            try
            {
                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    string query = "SELECT ID, merkki FROM Merkki";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        autoMakers.Add(new Merkki
                        {
                            ID = reader.GetInt32(0),
                            merkki = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return autoMakers;
        }

        public List<Malli> getAutoModelsByMakerId(int makerId)
        {
            List<Malli> autoModels = new List<Malli>();
            try
            {
                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    string query = "SELECT ID, Nimi, MerkkiID FROM Malli WHERE MerkkiID = @makerId";
                    SqlCommand command = new SqlCommand(query, connection);
                    command.Parameters.AddWithValue("@makerId", makerId);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        autoModels.Add(new Malli
                        {
                            ID = reader.GetInt32(0),
                            Nimi = reader.GetString(1),
                            MerkkiID = reader.GetInt32(2)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return autoModels;
        }

        public List<Polttoaine> GetPolttoaine()
        {
            List<Polttoaine> polttoaineet = new List<Polttoaine>();
            try
            {
                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    string query = "SELECT ID, Nimi FROM Polttoaine";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        polttoaineet.Add(new Polttoaine
                        {
                            ID = reader.GetInt32(0),
                            Nimi = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return polttoaineet;
        }

        public List<Vari> GetVari()
        {
            List<Vari> variList = new List<Vari>();
            try
            {
                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    string query = "SELECT ID, Nimi FROM Vari";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        variList.Add(new Vari
                        {
                            ID = reader.GetInt32(0),
                            Nimi = reader.GetString(1)
                        });
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return variList;
        }

        // In DatabaseHallinta.cs
        public bool DeleteRecordFromDatabase(Auto deleteRecord)
        {
            try
            {
                string query = "INSERT INTO Auto (Hinta, RekisteriPaivamaara, MoottorinTilavuus, Mittarilukema, MerkkiID, MalliID, VariID,  PolttoaineID) " +
                               "VALUES (@Hinta, @RekisteriPaivamaara, @MoottorinTilavuus, @Mittarilukema, @MerkkiID, @MalliID, @VariID, @PolttoaineID)";

                using (SqlConnection connection = new SqlConnection(yhteysTiedot))
                {
                    connection.Open();
                    using (SqlCommand cmd = new SqlCommand(query, connection))
                    {
                        cmd.Parameters.AddWithValue("@Hinta", deleteRecord.Hinta);
                        cmd.Parameters.AddWithValue("@RekisteriPaivamaara", deleteRecord.RekisteriPaivamaara);
                        cmd.Parameters.AddWithValue("@MoottorinTilavuus", deleteRecord.MoottorinTilavuus);
                        cmd.Parameters.AddWithValue("@Mittarilukema", deleteRecord.Mittarilukema);
                        cmd.Parameters.AddWithValue("@MerkkiID", deleteRecord.MerkkiID);
                        cmd.Parameters.AddWithValue("@MalliID", deleteRecord.MalliID);
                        cmd.Parameters.AddWithValue("@VariID", deleteRecord.VariID);
                        cmd.Parameters.AddWithValue("@PolttoaineID", deleteRecord.PolttoaineID);

                        int result = cmd.ExecuteNonQuery();
                        return result > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving the car: " + ex.Message);
                return false;
            }
        }

        public List<Auto> GetCarsByBrandFromDatabase(string brand)
        {
            List<Auto> cars = new List<Auto>();

            string query = "SELECT * FROM Auto WHERE Merkki = @merkki";
            using (SqlConnection connection = new SqlConnection(yhteysTiedot))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@merkki", brand);

                connection.Open();
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
                        cars.Add(car);
                    }
                }
            }

            return cars;
        }

        // Get all cars by price from the database
        public List<Auto> GetCarsByPriceFromDatabase(decimal price)
        {
            List<Auto> cars = new List<Auto>();

            string query = "SELECT * FROM Auto WHERE Hinta <= @Hinta";
            using (SqlConnection connection = new SqlConnection(yhteysTiedot))
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.AddWithValue("@Hinta", price);

                connection.Open();
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
                        cars.Add(car);
                    }
                }
            }

            return cars;
        }
    }
}


