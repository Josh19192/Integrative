using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using MySql.Data.MySqlClient;
using System.Reflection.PortableExecutable;

namespace Child_vaccine
{
    public partial class Vaccines : Form
    {
       
        public Vaccines()
        {
            InitializeComponent();
       

        }

        private async void Vaccines_Load(object sender, EventArgs e)
        {
            tbxId.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            try
            {
                await FetchDataAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private async Task FetchDataAsync()
        {
            using (HttpClient client = new HttpClient())
            {
                HttpResponseMessage response = await client.GetAsync("http://localhost:4000/vaccines");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var dt = JsonConvert.DeserializeObject<System.Data.DataTable>(responseBody);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvVaccines.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            // Display a confirmation prompt
            DialogResult result = MessageBox.Show("Are you sure you want to add this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // Check if the user clicked Yes
            if (result == DialogResult.Yes)
            {
                // Get data from user input
                string vaccineName = tbxVacName.Text;
                string vaccineBrand = tbxVacbrand.Text;
                string dose = nudDose.Text;
                string dateAdded = dtpAdded.Value.ToString("yyyy-MM-dd"); // Format the date

                // Create JSON object to send to the API
                string json = $"{{ \"vaccine_name\": \"{vaccineName}\", \"vaccine_brand\": \"{vaccineBrand}\", \"dose\": \"{dose}\", \"date_added\": \"{dateAdded}\" }}";

                // Send HTTP POST request to the API
                using (var client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await client.PostAsync("http://localhost:4000/vaccine", content);
                        response.EnsureSuccessStatusCode();

                        // Clear input fields after successful insertion
                        tbxVacName.Text = "";
                        tbxVacbrand.Text = "";
                        nudDose.Value = 0; // Assuming nudDose is a NumericUpDown control
                        dtpAdded.Value = DateTime.Today;

                        // Refresh the DataGridView
                        await FetchDataAsync();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show("Please fill in fields!");
                    }
                }
            }
        }

        private void dgvVaccines_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private async void dgvVaccines_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            btnAdd.Visible = false;
            btnCancel.Visible = true;
            btnDelete.Visible = true;
            btnUpdate.Visible = true;
            // Check if the clicked cell is not a header cell and a valid row index
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dgvVaccines.Rows[e.RowIndex].Cells["id"].Value); // Replace "IdColumn" with the actual name of the column containing IDs

                // Send a request to fetch data by ID from the API
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"http://localhost:4000/vaccine/{id}");
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        var vaccineData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                        // Display data in text boxes
                        tbxId.Text = vaccineData.id.ToString();
                        tbxVacName.Text = vaccineData.vaccine_name.ToString();
                        tbxVacbrand.Text = vaccineData.vaccine_brand.ToString();
                        nudDose.Value = Convert.ToDecimal(vaccineData.dose);
                        dtpAdded.Value = Convert.ToDateTime(vaccineData.date_added);
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            btnAdd.Visible = true;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            tbxVacName.Text = "";
            tbxVacbrand.Text = "";
            nudDose.Value = 0; // Assuming nudDose is a NumericUpDown control
            dtpAdded.Value = DateTime.Today;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Are you sure you want to update this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Get the ID of the vaccine to be updated
                int id = Convert.ToInt32(tbxId.Text);

                // Get the updated data from the text boxes
                string vaccineName = tbxVacName.Text;
                string vaccineBrand = tbxVacbrand.Text;
                string dose = nudDose.Value.ToString();
                string dateAdded = dtpAdded.Value.ToString("yyyy-MM-dd");

                // Create JSON object with updated data
                string json = $"{{ \"vaccine_name\": \"{vaccineName}\", \"vaccine_brand\": \"{vaccineBrand}\", \"dose\": \"{dose}\", \"date_added\": \"{dateAdded}\" }}";

                // Send HTTP PUT request to update the data
                using (HttpClient client = new HttpClient())
                {
                    var content = new StringContent(json, Encoding.UTF8, "application/json");

                    try
                    {
                        var response = await client.PutAsync($"http://localhost:4000/vaccine/{id}", content);
                        response.EnsureSuccessStatusCode();
                        tbxVacName.Text = "";
                        tbxVacbrand.Text = "";
                        nudDose.Value = 0; // Assuming nudDose is a NumericUpDown control
                        dtpAdded.Value = DateTime.Today;
                        // Refresh the DataGridView after update
                        await FetchDataAsync();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show("Please fill in fields!");
                    }
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {

            // Get the ID of the vaccine to be deleted
            int id = Convert.ToInt32(tbxId.Text);

            // Display a confirmation dialog to ensure the user wants to delete
            DialogResult result = MessageBox.Show("Are you sure you want to delete this item?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                // Send HTTP DELETE request to delete the data
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        var response = await client.DeleteAsync($"http://localhost:4000/vaccine/{id}");
                        response.EnsureSuccessStatusCode();

                        MessageBox.Show("Data deleted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Refresh the DataGridView after deletion
                        await FetchDataAsync();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            this.Hide();
            ds.Show();
        }


        private async void tbxSearch_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT * FROM vaccine_tbl WHERE id LIKE '%" + tbxSearch.Text + "%' OR vaccine_name LIKE '%" + tbxSearch.Text + "%' OR vaccine_brand LIKE '%" + tbxSearch.Text + "%' OR dose LIKE '%" + tbxSearch.Text + "%' OR date_added LIKE '%" + tbxSearch.Text + "%'", Info.cnn)) 
                {
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            Info.cnn.Open();
                            adapter.Fill(dataTable);
                            // Bind the DataTable to the DataGridView
                            dgvVaccines.DataSource = dataTable;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show("Error: " + ex.Message);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                Info.cnn.Close();
            }
        }

        private async void btnSearch_Click(object sender, EventArgs e)
        {
            
        }
    }
}
