const express = require('express');
const mysql = require('mysql2');
const bodyParser = require('body-parser');
const crypto = require('crypto');
const app = express();
const port = 4000;

// MySQL connection
const connection = mysql.createConnection({
  host: 'localhost',
  user: 'root',
  password: '',
  database: 'child_vaccine'
});

// Test MySQL connection
connection.connect((err) => {
  if (err) {
    console.error('Error connecting to MySQL database:', err);
    return;
  }
  console.log('Connected to MySQL database');
});

// Body parser middleware
app.use(bodyParser.json());


// Your code snippet
app.post('/authenticate', (req, res) => {
  const { username, password, tablename } = req.body;

  // Hash the password using MD5
  const hashedPassword = "BhsXkflnsm" + crypto.createHash('md5').update(password).digest("hex") + "ls0a1L2";

  // Prepare the SQL query
  const query = `SELECT * FROM admin_login WHERE username = ? AND password = ?`;

  // Execute the query with the provided parameters
  connection.query(query, [username, hashedPassword], (error, results, fields) => {
    if (error) {
      console.error('Error executing SQL query:', error);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }

    // Check if any rows matched the query
    if (results.length > 0) {
      // If a match is found, return the user data
      res.json(results[0]);
    } else {
      // If no match is found, return a 404 Not Found status
      res.status(404).json({ error: 'User not found or incorrect credentials' });
    }
  });
});

// API endpoint to fetch all data from MySQL database
app.get('/vaccines', (req, res) => {
  connection.query('SELECT * FROM vaccine_tbl', (err, results) => {
    if (err) {
      console.error('Error querying database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.json(results);
  });
});

// API endpoint to fetch data by ID from MySQL database
app.get('/vaccine/:id', (req, res) => {
  const id = req.params.id;
  connection.query('SELECT * FROM vaccine_tbl WHERE id = ?', id, (err, results) => {
    if (err) {
      console.error('Error querying database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    if (results.length === 0) {
      res.status(404).send('Data not found');
      return;
    }
    res.json(results[0]);
  });
});

// Handle form submission on the server side
app.post('/vaccine', (req, res) => {
  const { vaccine_name, vaccine_brand, dose, date_added } = req.body;

  // Check if any required fields are missing
  if (!vaccine_name || !vaccine_brand || !dose || !date_added) {
    res.status(400).send('All fields are required');
    return;
  }

  connection.query('INSERT INTO vaccine_tbl (vaccine_name, vaccine_brand, dose, date_added) VALUES (?, ?, ?, ?)', [vaccine_name, vaccine_brand, dose, date_added], (err, result) => {
    if (err) {
      console.error('Error inserting into database:', err);
      res.status(500).send(`Error inserting into database: ${err.message}`); // Send the actual error message
      return;
    }
    res.status(201).send('Data inserted successfully');
  });
});


// API endpoint to update data in MySQL database
app.put('/vaccine/:id', (req, res) => {
  const id = req.params.id;
  const { vaccine_name, vaccine_brand, dose, date_added } = req.body;
  connection.query('UPDATE vaccine_tbl SET vaccine_name = ?, vaccine_brand = ?, dose = ?, date_added =? WHERE id = ?', [vaccine_name, vaccine_brand, dose, date_added, id], (err, result) => {
    if (err) {
      console.error('Error updating database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data updated successfully');
  });
});

// API endpoint to delete data from MySQL database
app.delete('/vaccine/:id', (req, res) => {
  const id = req.params.id;
  connection.query('DELETE FROM vaccine_tbl WHERE id = ?', id, (err, result) => {
    if (err) {
      console.error('Error deleting from database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data deleted successfully');
  });
});

// API endpoint to fetch all data from MySQL database for child_info
app.get('/children', (req, res) => {
  connection.query('SELECT id, first_name, middle_name, last_name, sex, birthdate, child_blood_type, barangay, purok FROM child_info', (err, results) => {
    if (err) {
      console.error('Error querying database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.json(results);
  });
});


// API endpoint to fetch data by ID from MySQL database for child_info
app.get('/child/:id', (req, res) => {
  const id = req.params.id;
  connection.query('SELECT * FROM child_info WHERE id = ?', id, (err, results) => {
    if (err) {
      console.error('Error querying database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    if (results.length === 0) {
      res.status(404).send('Data not found');
      return;
    }
    res.json(results[0]);
  });
});







app.post('/child', (req, res) => {
  const { first_name, middle_name, last_name, sex, birthdate, place_of_birth, birth_method, child_blood_type, barangay, purok, mother_fname, mother_mname, mother_lname, mother_blood_type, mother_citizenship, mother_occupation, father_fname, father_mname, father_lname, father_blood_type, father_citizenship, father_occupation } = req.body;

  connection.query('INSERT INTO child_info (first_name, middle_name, last_name, sex, birthdate, place_of_birth, birth_method, child_blood_type, barangay, purok, mother_fname, mother_mname, mother_lname, mother_blood_type, mother_citizenship, mother_occupation, father_fname, father_mname, father_lname, father_blood_type, father_citizenship, father_occupation) VALUES (?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?, ?)', [first_name, middle_name, last_name, sex, birthdate, place_of_birth, birth_method, child_blood_type, barangay, purok, mother_fname, mother_mname, mother_lname, mother_blood_type, mother_citizenship, mother_occupation, father_fname, father_mname, father_lname, father_blood_type, father_citizenship, father_occupation], (err, result) => {
    if (err) {
      console.error('Error inserting into database:', err);
      return res.status(500).json({ error: err.message }); // Send error message in response
    }
    res.status(201).send('Data inserted successfully');
  });
});


// API endpoint to update data in MySQL database for child_info
app.put('/child/:id', (req, res) => {
  const id = req.params.id;
  const { first_name, middle_name, last_name, sex, birthdate, place_of_birth, birth_method, child_blood_type, barangay, purok, mother_fname, mother_mname, mother_lname, mother_blood_type, mother_citizenship, mother_occupation, father_fname, father_mname, father_lname, father_blood_type, father_citizenship, father_occupation } = req.body;

  connection.query('UPDATE child_info SET first_name = ?, middle_name = ?, last_name = ?, sex = ?, birthdate = ?, place_of_birth = ?, birth_method = ?, child_blood_type = ?, barangay = ?, purok = ?, mother_fname = ?, mother_mname = ?, mother_lname = ?, mother_blood_type = ?, mother_citizenship = ?, mother_occupation = ?, father_fname = ?, father_mname = ?, father_lname = ?, father_blood_type = ?, father_citizenship = ?, father_occupation = ? WHERE id = ?', [first_name, middle_name, last_name, sex, birthdate, place_of_birth, birth_method, child_blood_type, barangay, purok, mother_fname, mother_mname, mother_lname, mother_blood_type, mother_citizenship, mother_occupation, father_fname, father_mname, father_lname, father_blood_type, father_citizenship, father_occupation, id], (err, result) => {
    if (err) {
      console.error('Error updating database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data updated successfully');
  });
});

// API endpoint to delete data from MySQL database for child_info
app.delete('/child/:id', (req, res) => {
  const id = req.params.id;
  connection.query('DELETE FROM child_info WHERE id = ?', id, (err, result) => {
    if (err) {
      console.error('Error deleting from database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data deleted successfully');
  });
});

// API endpoint to fetch all data from MySQL database for child_info
app.get('/shot_recs', (req, res) => {
  connection.query(`
    SELECT sr.id, CONCAT(c.first_name, ' ', c.last_name) AS child_name, v.vaccine_name, sr.dose_no, sr.shot_date, sr.remarks 
    FROM shot_records sr
    INNER JOIN child_info c ON sr.child_id = c.id
    INNER JOIN vaccine_tbl v ON sr.vaccine_id = v.id
    ORDER BY sr.id ASC
  `, (err, results) => {
    if (err) {
      console.error('Error querying database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.json(results);
  });
});

app.get('/shot_rec/:id', (req, res) => {
  // Extract the ID parameter from the URL path
  const id = req.params.id;

  connection.query(
    `SELECT sr.id, CONCAT(c.first_name, ' ', c.last_name) AS child_name, v.vaccine_name, sr.dose_no, sr.shot_date, sr.remarks 
    FROM shot_records sr
    INNER JOIN child_info c ON sr.child_id = c.id
    INNER JOIN vaccine_tbl v ON sr.vaccine_id = v.id 
    WHERE sr.id = ?`,
    id,
    (err, results) => {
      if (err) {
        console.error('Error querying database:', err);
        res.status(500).send('Internal Server Error');
        return;
      }
      if (results.length === 0) {
        res.status(404).send('Data not found');
        return;
      }
      // Send the fetched data as JSON response
      res.json(results[0]);
    }
  );
});

app.get('/shot_recd/:id', (req, res) => {
  // Extract the ID parameter from the URL path
  const id = req.params.id;

  connection.query(
    `SELECT * FROM shot_records WHERE id = ?`,
    id,
    (err, results) => {
      if (err) {
        console.error('Error querying database:', err);
        // Send an error response with status code 500 and a descriptive message
        return res.status(500).send('Internal Server Error');
      }
      if (results.length === 0) {
        // If no data is found for the provided ID, send a 404 Not Found response
        return res.status(404).send('Data not found');
      }
      // Send the fetched data as a JSON response
      res.json(results[0]);
    }
  );
});

// Handle form submission on the server side
app.post('/shot', (req, res) => {
  const { child_id, vaccine_id, dose_no, shot_date, remarks } = req.body;


  connection.query('INSERT INTO shot_records (child_id, vaccine_id, dose_no, shot_date, remarks) VALUES (?, ?, ?, ?, ?)', [child_id, vaccine_id, dose_no, shot_date, remarks], (err, result) => {
    if (err) {
      console.error('Error inserting into database:', err);
      res.status(500).send(`Error inserting into database: ${err.message}`); // Send the actual error message
      return;
    }
    res.status(201).send('Data inserted successfully');
  });
});


// API endpoint to update data in MySQL database
app.put('/shot_rec/:id', (req, res) => {
  const id = req.params.id;
  const { vaccine_id, dose_no, shot_date, remarks} = req.body;
  connection.query('UPDATE shot_records SET vaccine_id = ?, dose_no = ?, shot_date = ?, remarks = ? WHERE id = ?', [vaccine_id, dose_no, shot_date, remarks, id], (err, result) => {
    if (err) {
      console.error('Error updating database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data updated successfully');
  });
});
// API endpoint to delete data from MySQL database for child_info
app.delete('/shot_rec/:id', (req, res) => {
  const id = req.params.id;
  connection.query('DELETE FROM shot_records WHERE id = ?', id, (err, result) => {
    if (err) {
      console.error('Error deleting from database:', err);
      res.status(500).send('Internal Server Error');
      return;
    }
    res.status(200).send('Data deleted successfully');
  });
});

app.post('/createUser', (req, res) => {
  const { username, password, repassword } = req.body;

  // Check if passwords match
  if (password !== repassword) {
      return res.status(400).json({ error: "Password doesn't match" });
  }

  // Hash the password
  const hashedPassword = "BhsXkflnsm" + crypto.createHash('md5').update(password).digest("hex") + "ls0a1L2";

  // Check if the username already exists
 
      // Insert new user into the database
      const queryInsertUser = "INSERT INTO admin_login (username, password) VALUES (?, ?)";
      connection.query(queryInsertUser, [username, hashedPassword], (error, results) => {
          if (error) {
              console.error('Error inserting new user:', error);
              return res.status(500).json({ error: 'Internal server error' });
          }

          res.json({ message: 'Successfully created' });
      });
  
});

app.get('/childinfo/count', (req, res) => {
  const sql = 'SELECT COUNT(*) AS total FROM child_info';
  connection.query(sql, (err, result) => {
    if (err) {
      console.error('Error executing MySQL query:', err);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }
    res.json({ count: result[0].total });
  });
});

app.get('/vacciness/count', (req, res) => {
  const sql = 'SELECT COUNT(*) AS total FROM vaccine_tbl';
  connection.query(sql, (err, result) => {
    if (err) {
      console.error('Error executing MySQL query:', err);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }
    res.json({ count: result[0].total });
  });
});

app.get('/shot_recss/count', (req, res) => {
  const sql = 'SELECT COUNT(*) AS total FROM shot_records';
  connection.query(sql, (err, result) => {
    if (err) {
      console.error('Error executing MySQL query:', err);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }
    res.json({ count: result[0].total });
  });
});

app.get('/shot_recss/countNow', (req, res) => {
  // Get today's date in YYYY-MM-DD format
  const today = new Date().toISOString().split('T')[0];
  
  const sql = `SELECT COUNT(*) AS total FROM shot_records WHERE shot_date = ?`;
  connection.query(sql, [today], (err, result) => {
    if (err) {
      console.error('Error executing MySQL query:', err);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }
    res.json({ count: result[0].total });
  });
});

app.get('/child/search', (req, res) => {
  const searchText = req.query.searchText;

  // Prepare SQL query to search for matching records
  const query = `
    SELECT id, first_name, middle_name,last_name, sex, birthdate, child_blood_type, barangay, purok FROM child_info 
    WHERE id LIKE ? 
    OR first_name LIKE ? 
    OR middle_name LIKE ? 
    OR last_name LIKE ? 
    OR sex LIKE ?
    OR birthdate LIKE ?
    OR child_blood_type LIKE ?
    OR barangay LIKE ?
    OR purok LIKE ?
  `;
  // Bind the '%' wildcard character to the search text
  const searchString = `%${searchText}%`;

  // Execute the query with the provided parameters
  connection.query(query, [searchString, searchString, searchString, searchString, searchString, searchString, searchString, searchString, searchString], (error, results) => {
    if (error) {
      console.error('Error executing SQL query:', error);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }

    // Send the matching records as JSON response
    res.json(results);
  });
});


app.get('/records/search', (req, res) => {
  const searchText = req.query.searchText;

  // Prepare SQL query to search for matching records
  const query = `
    SELECT * FROM shot_records 
    WHERE id LIKE ?
  `;
  
  // Bind the '%' wildcard character to the search text
  const searchString = `%${searchText}%`;

  // Execute the query with the provided parameters
  connection.query(query, [searchString], (error, results) => {
    if (error) {
      console.error('Error executing SQL query:', error);
      res.status(500).json({ error: 'Internal server error' });
      return;
    }

    // Send the matching records as JSON response
    res.json(results);
  });
});

app.get('/vaccine/search', (req, res) => {
  const searchTerm = req.query.searchTerm; // Assuming the search term is passed as a query parameter
  // Construct SQL query with parameterized query
  const query = `
    SELECT * FROM vaccine_tbl 
    WHERE id LIKE ? 
    OR vaccine_name LIKE ? 
    OR vaccine_brand LIKE ? 
    OR dose LIKE ? 
    OR date_added LIKE ?
  `;
  // Parameters to replace placeholders in the query
  const params = Array(5).fill('').map(() => `%${searchTerm}%`);

  // Execute the query with parameters
  pool.query(query, params, (error, results, fields) => {
    if (error) {
      console.error('Error executing query:', error);
      return res.status(500).json({ error: 'Internal server error' });
    }
    res.json(results);
  });
});




// Start the server
app.listen(port, () => {
  console.log(`Server is running on http://localhost:${port}`);
});
