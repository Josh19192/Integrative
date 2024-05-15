using MySql.Data.MySqlClient;
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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Child_vaccine
{
    public partial class Children : Form
    {
        public Children()
        {
            InitializeComponent();
        }

        private void clearTexts()
        {
            tbxFName.Text = "";
            tbxMName.Text = "";
            tbxLName.Text = "";
            cbxSex.Text = "";
            dtpBDate.Value = DateTime.Today;
            tbxPBirth.Text = "";
            tbxBMethod.Text = "";
            cbxBType.Text = "";
            tbxBrgy.Text = "";
            tbxPurok.Text = "";
            tbxMFName.Text = "";
            tbxMMName.Text = "";
            tbxMLName.Text = "";
            cbxMBType.Text = "";
            tbxMCitizen.Text = "";
            tbxMOccupation.Text = "";
            tbxFFName.Text = "";
            tbxFMName.Text = "";
            tbxFLName.Text = "";
            cbxFBType.Text = "";
            tbxFCitizen.Text = "";
            tbxFOccupation.Text = "";
        }

        private async void Children_Load(object sender, EventArgs e)
        {
            tbxId.Visible = false;
            btnUpdate.Visible = false;
            btnDelete.Visible = false;
            btnCancel.Visible = false;
            dtpBDate.Format = DateTimePickerFormat.Custom;
            dtpBDate.CustomFormat = "yyyy-MM-dd HH:mm:ss"; // Example format: "yyyy-MM-dd HH:mm:ss"
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

                var searchResults = JsonConvert.DeserializeObject<List<ChildRecord>>(responseBody);

                if (searchResults != null && searchResults.Count > 0)
                {
                    dgvChildren.DataSource = searchResults;
                }
                else
                {
                    MessageBox.Show("No data found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
        }


        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxFName.Text == "" || tbxMName.Text == "" || tbxLName.Text == "" || cbxSex.Text == "" || tbxPBirth.Text == "" || tbxBMethod.Text == "" || cbxBType.Text == "" || tbxBrgy.Text == "" || tbxPurok.Text == "")
            {
                MessageBox.Show("Please fill in important data!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to add this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked Yes
                if (result == DialogResult.Yes)
                {
                    // Get child information from input fields
                    string firstName = tbxFName.Text;
                    string middleName = tbxMName.Text;
                    string lastName = tbxLName.Text;
                    string sex = cbxSex.Text;
                    string birthdate = dtpBDate.Value.ToString("yyyy-MM-dd");
                    string placeOfBirth = tbxPBirth.Text;
                    string birthMethod = tbxBMethod.Text;
                    string childBloodType = cbxBType.Text;
                    string barangay = tbxBrgy.Text;
                    string purok = tbxPurok.Text;
                    string motherFirstName = tbxMFName.Text;
                    string motherMiddleName = tbxMMName.Text;
                    string motherLastName = tbxMLName.Text;
                    string motherBloodType = cbxMBType.Text;
                    string motherCitizenship = tbxMCitizen.Text;
                    string motherOccupation = tbxMOccupation.Text;
                    string fatherFirstName = tbxFFName.Text;
                    string fatherMiddleName = tbxFMName.Text;
                    string fatherLastName = tbxFLName.Text;
                    string fatherBloodType = cbxFBType.Text;
                    string fatherCitizenship = tbxFCitizen.Text;
                    string fatherOccupation = tbxFOccupation.Text;

                    // Create JSON object to send to the API
                    string json = $"{{ \"first_name\": \"{firstName}\", \"middle_name\": \"{middleName}\", \"last_name\": \"{lastName}\", \"sex\": \"{sex}\", \"birthdate\": \"{birthdate}\", \"place_of_birth\": \"{placeOfBirth}\", \"birth_method\": \"{birthMethod}\", \"child_blood_type\": \"{childBloodType}\", \"barangay\": \"{barangay}\", \"purok\": \"{purok}\", \"mother_fname\": \"{motherFirstName}\", \"mother_mname\": \"{motherMiddleName}\", \"mother_lname\": \"{motherLastName}\", \"mother_blood_type\": \"{motherBloodType}\", \"mother_citizenship\": \"{motherCitizenship}\", \"mother_occupation\": \"{motherOccupation}\", \"father_fname\": \"{fatherFirstName}\", \"father_mname\": \"{fatherMiddleName}\", \"father_lname\": \"{fatherLastName}\", \"father_blood_type\": \"{fatherBloodType}\", \"father_citizenship\": \"{fatherCitizenship}\", \"father_occupation\": \"{fatherOccupation}\" }}";

                    // Send HTTP POST request to the API
                    using (HttpClient client = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        try
                        {
                            var response = await client.PostAsync("http://localhost:4000/child", content);
                            response.EnsureSuccessStatusCode();

                            MessageBox.Show("Data inserted successfully", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            // Clear input fields after successful insertion
                            clearTexts();
                            await FetchDataAsync();
                            // Refresh the DataGridView if needed
                            // Call a method to refresh the DataGridView
                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

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
                        tbxId.Text = childData.id.ToString();
                        tbxFName.Text = childData.first_name.ToString();
                        tbxMName.Text = childData.middle_name.ToString();
                        tbxLName.Text = childData.last_name.ToString();
                        cbxSex.Text = childData.sex.ToString();
                        dtpBDate.Value = DateTime.Parse(childData.birthdate.ToString());
                        tbxPBirth.Text = childData.place_of_birth.ToString();
                        tbxBMethod.Text = childData.birth_method.ToString();
                        cbxBType.Text = childData.child_blood_type.ToString();
                        tbxBrgy.Text = childData.barangay.ToString();
                        tbxPurok.Text = childData.purok.ToString();
                        tbxMFName.Text = childData.mother_fname.ToString();
                        tbxMMName.Text = childData.mother_mname.ToString();
                        tbxMLName.Text = childData.mother_lname.ToString();
                        cbxMBType.Text = childData.mother_blood_type.ToString();
                        tbxMCitizen.Text = childData.mother_citizenship.ToString();
                        tbxMOccupation.Text = childData.mother_occupation.ToString();
                        tbxFFName.Text = childData.father_fname.ToString();
                        tbxFMName.Text = childData.father_mname.ToString();
                        tbxFLName.Text = childData.father_lname.ToString();
                        cbxFBType.Text = childData.father_blood_type.ToString();
                        tbxFCitizen.Text = childData.father_citizenship.ToString();
                        tbxFOccupation.Text = childData.father_occupation.ToString();

                        // Show necessary buttons
                        btnAdd.Visible = false;
                        btnCancel.Visible = true;
                        btnDelete.Visible = true;
                        btnUpdate.Visible = true;
                    }
                    catch (HttpRequestException ex)
                    {
                        MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private async void btnUpdate_Click(object sender, EventArgs e)
        {
            if (tbxFName.Text == "" || tbxMName.Text == "" || tbxLName.Text == "" || cbxSex.Text == "" || tbxPBirth.Text == "" || tbxBMethod.Text == "" || cbxBType.Text == "" || tbxBrgy.Text == "" || tbxPurok.Text == "")
            {
                MessageBox.Show("Please fill in important data!");
            }
            else
            {
                DialogResult result = MessageBox.Show("Are you sure you want to update this data?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // Check if the user clicked Yes
                if (result == DialogResult.Yes)
                {
                    // Get the ID of the child from the textbox
                    int id = Convert.ToInt32(tbxId.Text);

                    // Get data from textboxes
                    string firstName = tbxFName.Text;
                    string middleName = tbxMName.Text;
                    string lastName = tbxLName.Text;
                    string sex = cbxSex.Text;
                    string birthdate = dtpBDate.Value.ToString("yyyy-MM-dd");
                    string placeOfBirth = tbxPBirth.Text;
                    string birthMethod = tbxBMethod.Text;
                    string childBloodType = cbxBType.Text;
                    string barangay = tbxBrgy.Text;
                    string purok = tbxPurok.Text;
                    string motherFirstName = tbxMFName.Text;
                    string motherMiddleName = tbxMMName.Text;
                    string motherLastName = tbxMLName.Text;
                    string motherBloodType = cbxMBType.Text;
                    string motherCitizenship = tbxMCitizen.Text;
                    string motherOccupation = tbxMOccupation.Text;
                    string fatherFirstName = tbxFFName.Text;
                    string fatherMiddleName = tbxFMName.Text;
                    string fatherLastName = tbxFLName.Text;
                    string fatherBloodType = cbxFBType.Text;
                    string fatherCitizenship = tbxFCitizen.Text;
                    string fatherOccupation = tbxFOccupation.Text;

                    // Create JSON object to send to the API
                    string json = $"{{ \"first_name\": \"{firstName}\", \"middle_name\": \"{middleName}\", \"last_name\": \"{lastName}\", \"sex\": \"{sex}\", \"birthdate\": \"{birthdate}\", \"place_of_birth\": \"{placeOfBirth}\", \"birth_method\": \"{birthMethod}\", \"child_blood_type\": \"{childBloodType}\", \"barangay\": \"{barangay}\", \"purok\": \"{purok}\", \"mother_fname\": \"{motherFirstName}\", \"mother_mname\": \"{motherMiddleName}\", \"mother_lname\": \"{motherLastName}\", \"mother_blood_type\": \"{motherBloodType}\", \"mother_citizenship\": \"{motherCitizenship}\", \"mother_occupation\": \"{motherOccupation}\", \"father_fname\": \"{fatherFirstName}\", \"father_mname\": \"{fatherMiddleName}\", \"father_lname\": \"{fatherLastName}\", \"father_blood_type\": \"{fatherBloodType}\", \"father_citizenship\": \"{fatherCitizenship}\", \"father_occupation\": \"{fatherOccupation}\" }}";

                    // Send HTTP PUT request to the API
                    using (var client = new HttpClient())
                    {
                        var content = new StringContent(json, Encoding.UTF8, "application/json");

                        try
                        {
                            var response = await client.PutAsync($"http://localhost:4000/child/{id}", content);
                            response.EnsureSuccessStatusCode();



                            // Clear the textboxes
                            clearTexts();

                            // Refresh the data in the DataGridView
                            await FetchDataAsync();
                        }
                        catch (HttpRequestException ex)
                        {
                            MessageBox.Show($"Error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
        }

        private async void btnDelete_Click(object sender, EventArgs e)
        {
            // Prompt the user for confirmation
            DialogResult result = MessageBox.Show("Are you sure you want to delete this record?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            // If the user confirms the deletion
            if (result == DialogResult.Yes)
            {
                // Get the ID of the child from the textbox
                int id = Convert.ToInt32(tbxId.Text);

                // Send HTTP DELETE request to the API
                using (var client = new HttpClient())
                {
                    try
                    {
                        var response = await client.DeleteAsync($"http://localhost:4000/child/{id}");
                        response.EnsureSuccessStatusCode();


                        // Clear the textboxes
                        clearTexts();

                        // Refresh the data in the DataGridView
                        await FetchDataAsync();
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
            clearTexts();

        }

        private void button1_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            this.Hide();
            ds.Show();
        }

        private async void textBox19_TextChanged(object sender, EventArgs e)
        {
            try
            {
                using (MySqlCommand cmd = new MySqlCommand("SELECT id, first_name, middle_name, last_name, sex, birthdate, child_blood_type, barangay, purok " +
                                                "FROM child_info " +
                                                "WHERE id LIKE @searchText OR first_name LIKE @searchText OR middle_name LIKE @searchText OR last_name LIKE @searchText OR sex LIKE @searchText OR birthdate LIKE @searchText OR child_blood_type LIKE @searchText OR barangay LIKE @searchText OR purok LIKE @searchText", Info.cnn))
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
                            dgvChildren.DataSource = dataTable;
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

        private async void tbxSearch_KeyDown(object sender, KeyEventArgs e)
        {
            

        }

        private void dgvChildren_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public class ChildRecord
        {
            public int id { get; set; }
            public string first_name { get; set; }
            public string middle_name { get; set; }
            public string last_name { get; set; }
            public string sex { get; set; }
            public string birthdate { get; set; }
            public string child_blood_type { get; set; }
            public string barangay { get; set; }
            public string purok { get; set; }
        }
    }
}
