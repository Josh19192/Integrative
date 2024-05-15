using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Child_vaccine
{
    internal class Info
    {
       
         public static MySqlConnection cnn = new MySqlConnection("Server=localhost;Database=child_vaccine;user ID=root;Password=;");
        
    }
}
