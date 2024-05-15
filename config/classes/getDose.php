<?php
// Include your database connection file here
require_once('database.php');

// Create an instance of the Database class
$database = new Database("mysql:host=localhost;dbname=child_vaccine", "root", "");

// Check if the POST data is set
if (isset($_POST['vaccineName'])) {
    // Sanitize and store the selected vaccine name
    $selectedVaccine = $_POST['vaccineName'];

    // Use the getDosesForVaccine method from the Database class to retrieve dose information based on selected vaccine name
    $dose = $database->getDosesForVaccine($selectedVaccine);

    // Check if a dose is obtained
    if ($dose) {
        // Echo the dose information
        echo $dose;
    } else {
        // If no dose found, echo a message
        echo "Dose information not found for the selected vaccine.";
    }
} else {
    // If POST data is not set, echo an error message
    echo "Error: No vaccine selected.";
}
?>
