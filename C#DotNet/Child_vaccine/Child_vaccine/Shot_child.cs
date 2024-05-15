using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Child_vaccine
{
    public partial class Shot_child : Form
    {
        public Shot_child()
        {
            InitializeComponent();
        }


        private async void Shot_child_Load(object sender, EventArgs e)
        {
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



            tbxChildId.Visible = false;
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
                HttpResponseMessage response = await client.GetAsync("http://localhost:4000/children");
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                var dt = JsonConvert.DeserializeObject<System.Data.DataTable>(responseBody);

                if (dt != null && dt.Rows.Count > 0)
                {
                    dgvChildren.DataSource = dt;
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }

        private async void dgvChildren_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if the clicked cell is not a header cell and a valid row index
            if (e.RowIndex >= 0 && e.ColumnIndex >= 0)
            {
                // Get the ID of the selected row
                int id = Convert.ToInt32(dgvChildren.Rows[e.RowIndex].Cells["id"].Value); // Replace "id" with the actual name of the column containing IDs

                // Send a request to fetch data by ID from the API
                using (HttpClient client = new HttpClient())
                {
                    try
                    {
                        HttpResponseMessage response = await client.GetAsync($"http://localhost:4000/child/{id}");
                        response.EnsureSuccessStatusCode();

                        string responseBody = await response.Content.ReadAsStringAsync();

                        // Deserialize the JSON response
                        var childData = JsonConvert.DeserializeObject<dynamic>(responseBody);

                        // Display data in text boxes
                        tbxChildId.Text = childData.id.ToString();
                        tbxChildName.Text = childData.first_name.ToString() + " " + childData.last_name.ToString();


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
            tbxChildId.Text = "";
            tbxChildName.Text = "Child Name";
            tbxRemarks.Text = "";
            cbxVacName.Text = "";
            cbxDoseNo.Text = "";
            dtpShotDate.Value = DateTime.Today;


        }



        private async void cbxDoseNo_SelectedIndexChanged(object sender, EventArgs e)
        {


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

        private async void btnAdd_Click(object sender, EventArgs e)
        {

            if (tbxChildName.Text == "Child Name" || tbxRemarks.Text == "" || cbxDoseNo.Text == "")
            {
                MessageBox.Show("Please fill in fields!");
            }
            else
            {

                // Display a confirmation prompt
                DialogResult result = MessageBox.Show("Are you sure you want to add this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked Yes
                if (result == DialogResult.Yes)
                {
                    // Gather data from form controls
                    string childId = tbxChildId.Text;
                    string vacIdd = vacId.ToString(); // Assign vacId here
                    string doseNo = cbxDoseNo.Text;
                    DateTime shotDate = dtpShotDate.Value;
                    string remarkss = tbxRemarks.Text;

                    // Create JSON object to send to the API
                    string json = $"{{ \"child_id\": \"{childId}\", \"vaccine_id\": \"{vacIdd}\", \"dose_no\": \"{doseNo}\", \"shot_date\": \"{shotDate}\", \"remarks\": \"{remarkss}\" }}";

                    // Send HTTP POST request to the API
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        try
                        {
                            var response = await client.PostAsync("http://localhost:4000/shot", content);
                            response.EnsureSuccessStatusCode();
                            Shot_records sr = new Shot_records();
                            this.Hide();
                            sr.Show();

                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show("Please fill in fields!");
                        }
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
    }
}
