<?php 
$error="";
// Login form submission
/*if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['log'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    // Authenticate user
    $userData = $database->authenticate($username, $password, 'admin_login');
    if ($userData) {
        $session->login($userData);
         header("Location: home.php?tab=dashboard");
        exit();
    } else {
        $error = "Invalid username or password";
    }
}*/
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['log'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];

    // Data to be sent to the Node.js server
    $data = array(
        'username' => $username,
        'password' => $password,
        'tablename' => 'admin_login' // Assuming the table name is 'admin_tbl'
    );

    // Encode the data as JSON
    $data_string = json_encode($data);

    // Set up cURL to make a POST request to the Node.js server
    $ch = curl_init('http://localhost:4000/authenticate'); // Replace 'localhost:4000' with the correct address of your Node.js server
    curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "POST");
    curl_setopt($ch, CURLOPT_POSTFIELDS, $data_string);
    curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
    curl_setopt($ch, CURLOPT_HTTPHEADER, array(
        'Content-Type: application/json',
        'Content-Length: ' . strlen($data_string))
    );

    // Execute the cURL request and get the response
    $result = curl_exec($ch);
    $http_status = curl_getinfo($ch, CURLINFO_HTTP_CODE);

    // Close cURL resource
    curl_close($ch);

    // Handle the response
    if ($http_status == 200) {
        // Authentication successful, handle the response from Node.js server
        $userData = json_decode($result, true);
        // Assuming $session->login() and $error are defined elsewhere in your code
        $session->login($userData);
        header("Location: home.php?tab=dashboard");
        exit();
    } else {
        // Authentication failed, handle the error response
        $error = "Invalid username or password";
    }
}


if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_child'])) {
    $id = $_POST['id'];
    $putEndpointChild = 'http://localhost:4000/child/' . $id; // Update endpoint
    // Data to be updated
    $putData = array(
        'id' =>  $id, // ID of the vaccine to be updated
        'first_name' => $_POST['first_name'],
        'middle_name' => $_POST['middle_name'],
        'last_name' => $_POST['last_name'],
        'sex' => $_POST['sex'],
        'birthdate' => $_POST['birthdate'],
        'place_of_birth' => $_POST['place_of_birth'],
        'birth_method' => $_POST['birth_method'],
        'child_blood_type' => $_POST['child_blood_type'],
        'barangay' => $_POST['barangay'],
        'purok' => $_POST['purok'],
        'mother_fname' => $_POST['mother_fname'],
        'mother_mname' => $_POST['mother_mname'],
        'mother_lname' => $_POST['mother_lname'],
        'mother_blood_type' => $_POST['mother_blood_type'],
        'mother_citizenship' => $_POST['mother_citizenship'],
        'mother_occupation' => $_POST['mother_occupation'],
        'father_fname' => $_POST['father_fname'],
        'father_mname' => $_POST['father_mname'],
        'father_lname' => $_POST['father_lname'],
        'father_blood_type' => $_POST['father_blood_type'],
        'father_citizenship' => $_POST['father_citizenship'],
        'father_occupation' => $_POST['father_occupation']
    );

    // Make the HTTP PUT request to the API endpoint
    $putResponse = file_get_contents($putEndpointChild, false, stream_context_create(array(
        'http' => array(
            'method' => 'PUT',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($putData)
        )
    )));

    // Check if the request was successful
    if ($putResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to update data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($putResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Data updated successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_child'])) {
    $id = $_POST['delete_child']; // Corrected the variable name
    $deleteEndpoint = 'http://localhost:4000/child/' . $id;

    // Make the HTTP DELETE request to the API endpoint
    $deleteResponse = file_get_contents($deleteEndpoint, false, stream_context_create(array(
        'http' => array(
            'method' => 'DELETE',
            'header' => 'Content-Type: application/json'
        )
    )));

    // Check if the request was successful
    if ($deleteResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to delete data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($deleteResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg = "Data deleted successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_vaccine'])) {
    // Get the ID of the record to be deleted from the form data
    $id = $_POST['delete_vaccine'];

    // API endpoint for deleting data
    $deleteEndpoint = 'http://localhost:4000/vaccine/' . $id;

    // Make the HTTP DELETE request to the API endpoint
    $deleteResponse = file_get_contents($deleteEndpoint, false, stream_context_create(array(
        'http' => array(
            'method' => 'DELETE',
            'header' => 'Content-Type: application/json'
        )
    )));

    // Check if the request was successful
    if ($deleteResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to delete data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($deleteResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg = "Data deleted successfully.";
        }
    }
}


if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['shot'])){
    $postEndpointShot = 'http://localhost:4000/shot';
 
    // Data to be inserted
    $currentDateTime = date("Y-m-d H:i:s");
    $postData = array(
        'child_id' => $_POST['id'],
        'vaccine_id' => $_POST['vaccineName'],
        'dose_no' => $_POST['dose'],
        'shot_date' => $currentDateTime,
        'remarks' =>  $_POST['remarks'],

    );

    // Make the HTTP POST request to the API endpoint
    $postResponse = file_get_contents($postEndpointShot, false, stream_context_create(array(
        'http' => array(
            'method' => 'POST',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($postData)
        )
    )));

    // Check if the request was successful
    if ($postResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to insert data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($postResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Data inserted successfully.";
        }
    }
}



$msg="";
// Handle form submission on the server side
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['vaccine'])) {
    $postEndpointVac = 'http://localhost:4000/vaccine';
    // Data to be inserted
    $postData = array(
        'vaccine_name' => $_POST['vaccine_name'],
        'vaccine_brand' => $_POST['vaccine_brand'],
        'dose' => $_POST['dose'],
        'date_added' => date('Y-m-d') 
    );

    // Make the HTTP POST request to the API endpoint
    $postResponse = file_get_contents($postEndpointVac, false, stream_context_create(array(
        'http' => array(
            'method' => 'POST',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($postData)
        )
    )));

    // Check if the request was successful
    if ($postResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to insert data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($postResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Data inserted successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_vaccine'])) {
    $id = $_POST['id'];
    $putEndpointVac = 'http://localhost:4000/vaccine/' . $id; // Update endpoint
    // Data to be updated
    $putData = array(
        'id' =>  $id, // ID of the vaccine to be updated
        'vaccine_name' => $_POST['vaccine_name'],
        'vaccine_brand' => $_POST['vaccine_brand'],
        'dose' => $_POST['dose'],
        'date_added' => $_POST['date_added']
    );

    // Make the HTTP PUT request to the API endpoint
    $putResponse = file_get_contents($putEndpointVac, false, stream_context_create(array(
        'http' => array(
            'method' => 'PUT',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($putData)
        )
    )));

    // Check if the request was successful
    if ($putResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to update data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($putResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Data updated successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['child'])) {
    // Define API endpoint for child data insertion
    $postEndpointChild = 'http://localhost:4000/child';
    
    // Data to be inserted
    $postDataChild = array(
        'first_name' => $_POST['first_name'],
        'middle_name' => $_POST['middle_name'],
        'last_name' => $_POST['last_name'],
        'sex' => $_POST['sex'],
        'birthdate' => $_POST['birthdate'],
        'place_of_birth' => $_POST['place_of_birth'],
        'birth_method' => $_POST['birth_method'],
        'child_blood_type' => $_POST['child_blood_type'],
        'barangay' => $_POST['barangay'],
        'purok' => $_POST['purok'],
        'mother_fname' => $_POST['mother_fname'],
        'mother_mname' => $_POST['mother_mname'],
        'mother_lname' => $_POST['mother_lname'],
        'mother_blood_type' => $_POST['mother_blood_type'],
        'mother_citizenship' => $_POST['mother_citizenship'],
        'mother_occupation' => $_POST['mother_occupation'],
        'father_fname' => $_POST['father_fname'],
        'father_mname' => $_POST['father_mname'],
        'father_lname' => $_POST['father_lname'],
        'father_blood_type' => $_POST['father_blood_type'],
        'father_citizenship' => $_POST['father_citizenship'],
        'father_occupation' => $_POST['father_occupation']
    );

    // Set headers
    $headers = array(
        'Content-Type: application/json'
    );

    // Make the HTTP POST request to the API endpoint
    $options = array(
        'http' => array(
            'method' => 'POST',
            'header' => implode("\r\n", $headers),
            'content' => json_encode($postDataChild)
        )
    );
    $context = stream_context_create($options);
    $postResponseChild = file_get_contents($postEndpointChild, false, $context);

    // Check if the request was successful
    if ($postResponseChild === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to insert child data using the API.";
    } else {
        // Decode the JSON response
        $responseDataChild = json_decode($postResponseChild, true);

        // Check if JSON decoding was successful
        if ($responseDataChild === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Child data inserted successfully.";
        }
    }
}
if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['update_shot'])) {
    $id = $_POST['id'];
    $putEndpointVac = 'http://localhost:4000/shot_rec/' . $id; // Update endpoint
    // Data to be updated
    $putData = array(
        'id' =>  $id, // ID of the vaccine to be updated
        'vaccine_id' => $_POST['vaccineName'],
        'dose_no' => $_POST['dose'],
        'shot_date' => $_POST['shot_date'],
        'remarks' => $_POST['remarks']
    );

    // Make the HTTP PUT request to the API endpoint
    $putResponse = file_get_contents($putEndpointVac, false, stream_context_create(array(
        'http' => array(
            'method' => 'PUT',
            'header' => 'Content-Type: application/json',
            'content' => json_encode($putData)
        )
    )));

    // Check if the request was successful
    if ($putResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to update data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($putResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg =  "Data updated successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['delete_shot'])) {
    // Get the ID of the record to be deleted from the form data
    $id = $_POST['delete_shot'];

    // API endpoint for deleting data
    $deleteEndpoint = 'http://localhost:4000/shot_rec/' . $id;

    // Make the HTTP DELETE request to the API endpoint
    $deleteResponse = file_get_contents($deleteEndpoint, false, stream_context_create(array(
        'http' => array(
            'method' => 'DELETE',
            'header' => 'Content-Type: application/json'
        )
    )));

    // Check if the request was successful
    if ($deleteResponse === false) {
        // Handle the error if the request failed
        $msg = "Error: Failed to delete data using the API.";
    } else {
        // Decode the JSON response
        $responseData = json_decode($deleteResponse, true);

        // Check if JSON decoding was successful
        if ($responseData === null) {
            // Handle the error if JSON decoding failed
            $msg = "Error: Failed to decode JSON response.";
        } else {
            // Display success message
            $msg = "Data deleted successfully.";
        }
    }
}

if ($_SERVER["REQUEST_METHOD"] == "POST" && isset($_POST['create'])) {
    $username = $_POST['username'];
    $password = $_POST['password'];
    $repassword = $_POST['repassword'];
   

    // Check if passwords match
    if ($password !== $repassword) {
        $error = "Password doesn't match";
    } else {
        // Data to be sent to the Node.js server
        $data = array(
            'username' => $username,
            'password' => $password,
            'repassword' => $repassword,
        );

        // Encode the data as JSON
        $data_string = json_encode($data);

        // Set up cURL to make a POST request to the Node.js server
        $ch = curl_init('http://localhost:4000/createUser'); // Replace 'localhost:3000' with the correct address of your Node.js server
        curl_setopt($ch, CURLOPT_CUSTOMREQUEST, "POST");
        curl_setopt($ch, CURLOPT_POSTFIELDS, $data_string);
        curl_setopt($ch, CURLOPT_RETURNTRANSFER, true);
        curl_setopt($ch, CURLOPT_HTTPHEADER, array(
            'Content-Type: application/json',
            'Content-Length: ' . strlen($data_string))
        );

        // Execute the cURL request and get the response
        $result = curl_exec($ch);
        $http_status = curl_getinfo($ch, CURLINFO_HTTP_CODE);

        // Close cURL resource
        curl_close($ch);

        // Handle the response
        if ($http_status == 200) {
            // User creation successful
            $msg = json_decode($result, true)['message'];
        } else {
            // User creation failed
            $error = "User creation failed";
        }
    }

    // Output any errors or messages
    if (isset($error)) {
        echo "<pre>";
        var_dump($error);
        echo "</pre>";
    } else if (isset($msg)) {
        echo "<pre>";
        var_dump($msg);
        echo "</pre>";
    }
}

?>