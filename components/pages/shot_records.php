<?php
function shot_records($database){ 
    // Get all records from the 'employee_tbl' table
    $record_json = file_get_contents('http://localhost:4000/shot_recs');
    $allRecords = json_decode($record_json, true);

    // Check if there are records
    if (!empty($allRecords)) {
        echo '<div class="container-xxl flex-grow-1 container-p-y">';
        echo '<div class="row justify-content-center">';
        echo'<h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Vaccines /</span> Manage Vaccines</h4>';
        echo '<div class="table-responsive">';
        echo '<input type="text" class="form-control justify-content-center" id="searchInput" placeholder="Search..."><br><br>';
        echo '<table class="table table-bordered table-striped table-sm" id="dataTable">';
        
        // Display table header
        echo '<thead class="thead-dark">';
        echo '<tr>';
        foreach ($allRecords[0] as $key => $value) {
            echo '<th style="text-align:center; font-size:16px">' . htmlspecialchars($key) . '</th>'; // Sanitize column names
        }
        echo '<th style="text-align:center;font-size:16px">Action</th>'; // Action column header
        echo '</tr>';
        echo '</thead>';

        // Display table data
        echo '<tbody>';
        foreach ($allRecords as $record) {
            echo '<tr>';
            foreach ($record as $value) {
                echo '<td>' . htmlspecialchars($value) . '</td>'; // Sanitize data values
            }
            // Action column with update and delete actions
            echo '<td style="text-align:center;">';
            echo '<a href="home.php?tab=update_shot&id=' . $record['id'] . '" class="bx bx-edit-alt me-1"></a> &nbsp;&nbsp;';

            echo '<form style="display: inline;" id="deleteForm' . $record['id'] . '" action="" method="POST">';
            echo '<input type="hidden" name="delete_shot" value="' . $record['id'] . '">';
            echo '<button type="submit" style="border: none; color:maroon;" class="bx bx-trash me-1" onclick="return confirmDelete(' . $record['id'] . ')"></button>';
            echo '</form>';
            echo '</td>';
            echo '</tr>';
        }
        
        echo '</tbody>';
        echo '</table>';
        echo '</div>'; // Close table-responsive
        echo '</div>'; // Close row
        echo '</div>'; // Close container-xxl
    } else {
        echo '<div class="container-xxl flex-grow-1 container-p-y">';
        echo '<p class="text-center">No records found.</p>';
        echo '</div>';
    }
}
?>
<script>
  function confirmDelete(id) {
                  if (confirm("Are you sure you want to delete this user?")) {
                      document.getElementById('deleteForm' + id).submit();
                  }
                  return false; // Prevents the default form submission
              }
  // JavaScript for table search functionality
  document.addEventListener('DOMContentLoaded', function() {
    const searchInput = document.getElementById('searchInput');
    const dataTable = document.getElementById('dataTable');
    const tableRows = dataTable.getElementsByTagName('tr');

    searchInput.addEventListener('keyup', function(event) {
      const searchTerm = event.target.value.toLowerCase();
      Array.from(tableRows).forEach(function(row, index) {
        if (index !== 0) { // Exclude the first row (table headers)
          const rowData = row.textContent.toLowerCase();
          if (rowData.includes(searchTerm)) {
            row.style.display = '';
          } else {
            row.style.display = 'none';
          }
        }
      });
    });
  });
</script>

