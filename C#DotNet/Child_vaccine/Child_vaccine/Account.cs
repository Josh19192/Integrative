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
    public partial class Account : Form
    {
        public Account()
        {
            InitializeComponent();
        }

        private async void btnAdd_Click(object sender, EventArgs e)
        {
            if (tbxPassword.Text == "" || tbxUsername.Text == "" || tbxCon.Text == "")
            {
                MessageBox.Show("Please fill in fields");
            }
            else
            {
                try
                {
                    if (tbxPassword.Text != tbxCon.Text)
                    {
                        MessageBox.Show("Password dont match!");
                    }
                    else
                    {
                        // Gather data from form controls
                        string username = tbxUsername.Text;
                        string password = tbxPassword.Text;

                        // Display a confirmation prompt
                        DialogResult result = MessageBox.Show("Are you sure you want to create this account?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                        // Check if the user clicked Yes
                        if (result == DialogResult.Yes)
                        {
                            // Prepare the data to send in the request body
                            var data = new
                            {
                                username = username,
                                password = password,
                                repassword = password // Assuming re-entered password is same as password
                            };

                            // Serialize the data to JSON
                            string jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);

                            // Create HttpClient instance
                            using (HttpClient client = new HttpClient())
                            {
                                // Set the base address of your Node.js server
                                client.BaseAddress = new Uri("http://localhost:4000");

                                // Set the content type
                                client.DefaultRequestHeaders.Accept.Add(new System.Net.Http.Headers.MediaTypeWithQualityHeaderValue("application/json"));

                                // Send POST request to the '/createUser' endpoint
                                HttpResponseMessage response = await client.PostAsync("/createUser", new StringContent(jsonData, Encoding.UTF8, "application/json"));

                                // Check if the request was successful
                                if (response.IsSuccessStatusCode)
                                {
                                    MessageBox.Show("Account created successfully");
                                }
                                else
                                {
                                    string errorMessage = await response.Content.ReadAsStringAsync();
                                    MessageBox.Show("Failed to create account: " + errorMessage);
                                }
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void checkBoxPass_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxPass.Checked)
            {
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword.UseSystemPasswordChar = true;
            }
        }

        private void Account_Load(object sender, EventArgs e)
        {
           
            
        }

        private void button2_Click(object sender, EventArgs e)
        {
            dashboard ds = new dashboard();
            this.Hide();
            ds.Show();
        }

        private void checkBoxCon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCon.Checked)
            {
                tbxCon.UseSystemPasswordChar = false;
            }
            else
            {
                tbxCon.UseSystemPasswordChar = true;
            }
        }
    }
}
