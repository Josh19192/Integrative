using System.Text;

namespace Child_vaccine
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            Vaccines vc = new Vaccines();
            this.Hide();
            vc.Show();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Get data from form controls
                string username = tbxUsername.Text;
                string password = tbxPassword.Text;
                string tablename = "admin_login"; // Assuming you have a tablename control or it's hardcoded

                // Prepare the data to send in the request body
                var data = new
                {
                    username = username,
                    password = password,
                    tablename = tablename
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

                    // Send POST request to the '/authenticate' endpoint
                    HttpResponseMessage response = await client.PostAsync("/authenticate", new StringContent(jsonData, Encoding.UTF8, "application/json"));

                    // Check if the request was successful
                    if (response.IsSuccessStatusCode)
                    {
                        // Read response content for user data
                        string responseData = await response.Content.ReadAsStringAsync();
                        dashboard ds = new dashboard();
                        this.Hide();
                        ds.Show();
                    }
                    else
                    {
                        // Read response content for error message
                        string errorMessage = await response.Content.ReadAsStringAsync();
                        MessageBox.Show("Authentication failed: " + errorMessage);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void checkBoxCon_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBoxCon.Checked)
            {
                tbxPassword.UseSystemPasswordChar = false;
            }
            else
            {
                tbxPassword.UseSystemPasswordChar = true;
            }
        }
    }
}
