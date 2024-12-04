using System.Data;
using Microsoft.Data.SqlClient;

namespace Opiskelijat
{
    public partial class Form1 : Form
    {
        private readonly string connectionString;
        public Form1()
        {
            connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Opiskelijat;Integrated Security=True";
            InitializeComponent();
            LoadGroupsData();
            LoadStudentData();
        }

        private void LoadStudentData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT OpiskelijaID, etunimi, sukunimi, ryhmanNimi " +
                        "FROM Opiskelija " +
                        "JOIN Opiskelijaryhma " +
                        "ON Opiskelija.ryhma_id = Opiskelijaryhma.OpiskelijaryhmaID";
                    SqlDataAdapter dataAdapter = new(query, connection);
                    DataTable dataTable = new();
                    dataAdapter.Fill(dataTable);
                    studentGridView.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading student data: " + ex.Message);
            }
        }

        public void LoadGroupsData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    string query = "SELECT OpiskelijaryhmaID, ryhmanNimi FROM Opiskelijaryhma";
                    SqlDataAdapter dataAdapter = new(query, connection);
                    DataTable dataTable = new();
                    dataAdapter.Fill(dataTable);

                    // Set the data source and display/value members
                    groupComboBox.DisplayMember = "ryhmanNimi";
                    groupComboBox.ValueMember = "OpiskelijaryhmaID";
                    groupComboBox.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading group data: " + ex.Message);
            }
        }

        public void DeleteStudentButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text.Trim();
            string lastName = lastNameTextBox.Text.Trim();

            DialogResult result = MessageBox.Show($"Are you sure you want to delete {firstName} {lastName}?", "Confirm Deletion", MessageBoxButtons.YesNo);

            if (result == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        string query = "DELETE FROM Opiskelija WHERE etunimi = @FirstName AND sukunimi = @LastName";
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@FirstName", firstName);
                        command.Parameters.AddWithValue("@LastName", lastName);

                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();

                        if (rowsAffected > 0)
                        {
                            LoadStudentData();
                            MessageBox.Show("Student deleted successfully!");
                        }
                        else
                        {
                            MessageBox.Show("No student found with the given name.");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error deleting student: " + ex.Message);
                }
            }
        }


        public void AddStudentButton_Click(object sender, EventArgs e)
        {
            string firstName = firstNameTextBox.Text;
            string lastName = lastNameTextBox.Text;
            int groupId = (int)groupComboBox.SelectedValue;

            try
            {
                using (SqlConnection connection = new(connectionString))
                {
                    string query = "INSERT INTO Opiskelija (etunimi, sukunimi, ryhma_id) VALUES (@FirstName, @LastName, @GroupId)";
                    SqlCommand command = new(query, connection);
                    command.Parameters.AddWithValue("@FirstName", firstName);
                    command.Parameters.AddWithValue("@LastName", lastName);
                    command.Parameters.AddWithValue("@GroupId", groupId);

                    connection.Open();
                    command.ExecuteNonQuery();  // Execute the insert command
                }

                // Reload student data to reflect the added student
                LoadStudentData();
                MessageBox.Show("Student added successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding student: " + ex.Message);
            }
        }

    }
}