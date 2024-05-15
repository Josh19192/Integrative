using MySql.Data.MySqlClient;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace Child_vaccine
{
    public partial class Shot_records : Form
    {
        public Shot_records()
        {
            InitializeComponent();
        }

        private async void Shot_records_Load(object sender, EventArgs e)
        {
            tbxChildId.Visible = false;
            tbxId.Visible = false;
            // Assuming this code is in the event handler for cbxVacName.SelectedIndexChanged event
            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:4000/vaccines");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    dynamic vaccines = JsonConvert.DeserializeObject(responseBody);

                    // Extract vaccine names and populate the ComboBox
                    foreach (var vaccine in vaccines)
                    {
                        cbxVacName.Items.Add(vaccine.vaccine_name.ToString());
                    }


                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }




            dtpShotDate.Format = DateTimePickerFormat.Custom;
            dtpShotDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"; // Example format: "yyyy-MM-dd HH:mm:ss"
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
                HttpResponseMessage response = await client.GetAsync("http://localhost:4000/shot_recs");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var dt = JsonConvert.DeserializeObject<System.Data.DataTable>(responseBody);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvRecords.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }
        int childId = 0;
        private async void dgvRecords_CellClick(object sender, DataGridViewCellEventArgs e)
        {


            // Check if the clicked cell is not a header cell and a valid row index
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dgvRecords.Rows[e.RowIndex].Cells["id"].Value); // Replace "IdColumn" with the actual name of the column containing IDs

                // Send a request to fetch data by ID from the API
                using (HttpClient client = new HttpClient())
                {
                    try
                    {


                        HttpResponseMessage response = await client.GetAsync($"http://localhost:4000/shot_rec/{id}");
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        var recData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                        // Display data in text boxes
                        tbxId.Text = recData.id.ToString();
                        tbxChildName.Text = recData.child_name.ToString();
                        cbxVacName.Text = recData.vaccine_name.ToString();
                        cbxDoseNo.Text = recData.dose_no.ToString();
                        dtpShotDate.Value = Convert.ToDateTime(recData.shot_date);
                        tbxRemarks.Text = recData.remarks.ToString();
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            this.Hide();
            ds.Show();
        }

        private async void textBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT sr.id, CONCAT(c.first_name, ' ', c.last_name) AS child_name, v.vaccine_name, sr.dose_no, sr.shot_date, sr.remarks " +
                                                            "FROM shot_records sr " +
                                                            "INNER JOIN child_info c ON sr.child_id = c.id " +
                                                            "INNER JOIN vaccine_tbl v ON sr.vaccine_id = v.id " +
                                                            "WHERE sr.id LIKE @searchText OR CONCAT(c.first_name, ' ', c.last_name) LIKE @searchText OR v.vaccine_name LIKE @searchText OR sr.dose_no LIKE @searchText OR sr.shot_date LIKE @searchText", Info.cnn))
                {
                    // Add parameters to prevent SQL injection
                    cmd.Parameters.AddWithValue("@searchText", "%" + tbxSearch.Text + "%");

                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(cmd))
                    {
                        DataTable dataTable = new DataTable();
                        try
                        {
                            Info.cnn.Open();
                            adapter.Fill(dataTable);
                            // Bind the DataTable to the DataGridView
                            dgvRecords.DataSource = dataTable;
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
        int vacId = 0;
        private async void cbxVacName_SelectedIndexChanged(object sender, EventArgs e)
        {
            cbxDoseNo.Items.Clear();

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    HttpResponseMessage response = await client.GetAsync("http://localhost:4000/vaccines");
                    response.EnsureSuccessStatusCode();

                    string responseBody = await response.Content.ReadAsStringAsync();

                    // Deserialize the JSON response
                    dynamic vaccines = JsonConvert.DeserializeObject(responseBody);

                    string selectedVaccine = cbxVacName.SelectedItem.ToString();

                    // Find the selected vaccine in the JSON response
                    foreach (var vaccine in vaccines)
                    {
                        if (vaccine.vaccine_name.ToString() == selectedVaccine)
                        {
                            vacId = vaccine.id;


                            // Add the doses to cbxDose
                            for (int i = 1; i <= Convert.ToInt32(vaccine.dose); i++)
                            {

                                cbxDoseNo.Items.Add(i);
                            }

                            break; // Exit the loop once the selected vaccine is found
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            tbxId.Text = "";
            tbxChildName.Text = "Child Name";
            tbxRemarks.Text = "";
            cbxVacName.Text = "";
            cbxDoseNo.Text = "";
            dtpShotDate.Value = DateTime.Today;
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (cbxDoseNo.Text == "" || cbxVacName.Text == "" || tbxRemarks.Text == "")
            {
                MessageBox.Show("No record selected to be update");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked Yes
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the ID of the record to be updated
                        int id = Convert.ToInt32(tbxId.Text);

                        // Prepare the updated data
                        var updatedData = new
                        {
                            vaccine_id = vacId, // Assuming vacId is a variable holding the vaccine ID
                            dose_no = cbxDoseNo.Text,
                            shot_date = dtpShotDate.Value.ToString("yyyy-MM-dd"), // Convert DateTime to string in the format MySQL expects
                            remarks = tbxRemarks.Text
                        };

                        // Serialize the updated data to JSON
                        var json = JsonConvert.SerializeObject(updatedData);

                        // Create HttpClient instance
                        using (HttpClient client = new HttpClient())
                        {
                            // Set the content type header
                            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                            // Create HttpContent for the JSON data
                            HttpContent content = new StringContent(json, Encoding.UTF8, "application/json");

                            // Send PUT request to the API endpoint
                            HttpResponseMessage response = await client.PutAsync($"http://localhost:4000/shot_rec/{id}", content);

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                try
                                {
                                    await FetchDataAsync();
                                }
                                catch (Exception ex)
                                {
                                    MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                            else
                            {
                                MessageBox.Show("Failed to update record: " + response.ReasonPhrase);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {

        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            if (cbxDoseNo.Text == "" || cbxVacName.Text == "" || tbxRemarks.Text == "")
            {
                MessageBox.Show("No record selected to be delete");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked Yes
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Get the ID of the record to be deleted
                        int id = Convert.ToInt32(tbxId.Text);

                        // Create HttpClient instance
                        using (HttpClient client = new HttpClient())
                        {
                            // Send DELETE request to the API endpoint
                            HttpResponseMessage response = await client.DeleteAsync($"http://localhost:4000/shot_rec/{id}");

                            // Check if the request was successful
                            if (response.IsSuccessStatusCode)
                            {
                                // Clear text boxes or update UI as needed
                                tbxId.Text = "";
                                cbxDoseNo.Text = "";
                                cbxVacName.Text = "";
                                tbxRemarks.Text = "";
                                await FetchDataAsync();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete record: " + response.ReasonPhrase);
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message);
                    }
                }
            }
        }
    }
}
