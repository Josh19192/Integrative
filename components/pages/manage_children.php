    <?php
    
    function manage_children($database){ 
      echo'<div class="container-xxl flex-grow-1 container-p-y">';
      echo'<h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Children /</span> Manage Children</h4>';
      echo'<div class="row justify-content-center">';
      echo'<div class="table-responsive">';
      echo '<link rel="stylesheet" href="https://cdn.jsdelivr.net/npm/boxicons@2.1.1/css/boxicons.min.css">';

      $Children_json = file_get_contents('http://localhost:4000/children');
       $allRecords = json_decode($Children_json, true);
        // Check if there are records
        if (!empty($allRecords)) {
        
            echo '<table class=" table table-bordered table-striped table-sm" id="dataTable">';
            echo'<input type="text"  class="form-control justify-content-center" id="searchInput" placeholder="Search..."><br><br>';
            // Display table header
            echo '<thead class="thead-dark">';
            echo '<tr>';
            foreach ($allRecords[0] as $key => $value) {
                echo '<th style="text-align:center;font-size:16px">' . htmlspecialchars($key) . '</th>'; // Sanitize column names
            }
            echo '<th style="text-align:center; font-size:16px">Action</th>'; // Action column header
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
                echo '<a style="color:green;" href="home.php?tab=inject&id=' . $record['id'] . '" class="bx bxs-injection"  ></a> &nbsp;&nbsp;&nbsp;';
                echo '<a  href="home.php?tab=update_child&id=' . $record['id'] . '"  class="bx bx-edit-alt me-1"></a> &nbsp;&nbsp;';
                echo '<form style=" display: inline;" id="deleteForm' . $record['id'] . '" action="" method="POST">';
                echo '<input type="hidden" name="delete_child" value="' . $record['id'] . '">';
                echo '<button type="submit" style="background-color:none; border: none;color:maroon;" class="bx bx-trash me-1" onclick="return confirmDelete(' . $record['id'] . ')"></button>';
                echo '</form>';
                echo '</td>';
                echo '</tr>';
            }
            
            echo '</tbody>';
            echo '</table>';
        } else {
            echo '<p class="text-center">No records found.</p>';
        }
      echo'</div>';
      echo'</div>';
      echo'</div>';
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

