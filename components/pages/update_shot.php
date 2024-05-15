<?php

function update_shot($database)
{

    if (isset($_GET['id'])) {
        $record_id = $_GET['id'];
        // Assuming $database is an instance of your Database class
        $record = $database->getDataById('shot_records', $record_id); // You need to implement this method in your database class
    }

?>
    <div class="container-xxl flex-grow-1 container-p-y">
        <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Shot /</span> Update Shot</h4>

        <div class="row">
            <div class="col-md-12">
                <div class="card mb-4">
                    <hr class="my-0" />
                    <div class="card-body">
                        <div class="app-brand justify-content-center">
                            <a href="index.html" class="app-brand-link gap-2">
                                <h2><span class="fw-bold py-3 mb-4">Update Shot</span></h2>
                            </a>
                        </div>
                        <br>
                        <form method="POST" action="home.php?tab=shot_records">
                            <input type="hidden" name="id" value="<?= $record['id'] ?>">
                            <div class="row">
                                <div class="mb-3 col-md-6">
                                    <label for="vaccineName" class="form-label">Vaccine</label>
                                    <select class="form-select" name="vaccineName" id="vaccineName" required>
                                        
                                        <?php 
                                        $vaccineNames = $database->getAllData('vaccine_tbl'); // You need to implement this method in your database class
                                        foreach ($vaccineNames as $vaccineName) {
                                            $selected = ($vaccineName['id'] == $vaccineName['vaccine_name']) ? 'selected' : '';
                                            echo '<option value="' . $vaccineName['id'] . '" ' . $selected . '>' . $vaccineName['vaccine_name'] . '</option>';
                                        }
                                        ?>
                                    </select>

                                </div>
                                <div class="mb-3 col-md-6">
                                    <label for="dose" class="form-label">Dose</label>
                                    <select name="dose" id="dose" class="form-select">
                                    <option value=" <?php echo $record['id']?>"><?php echo $record['dose_no']?> </option>;
                                        <!-- Options will be dynamically added here -->
                                    </select>
                                </div>
                                <div class="mb-3 col-md-6">
                                    <label for="shot_date" class="form-label">Shot Date</label>
                                    <input type="datetime-local" class="form-control" id="shot_date" name="shot_date" value="<?= $record['shot_date'] ?>" ></input>
                                </div>
                                <div class="mb-3">
                                    <label for="remarks" class="form-label">Remarks</label>
                                    <textarea class="form-control" id="remarks" name="remarks" rows="4" placeholder="Write remarks..."><?= $record['remarks'] ?></textarea>
                                </div>
                            </div>

                            <div class="mt-2" style="text-align: center;">
                                <button type="submit" name="update_shot" onclick="showMessageBox()" class="btn btn-primary me-2"  style="width: 60%; text-align:center;background-color:#1b1a5e;margin-top:3%">Save</button>
                            </div>

                        </form>
                    </div>
                    <!-- /Account -->
                </div>
            </div>
        </div>
    </div>
    <script>
        document.getElementById('vaccineName').addEventListener('change', function() {
            var selectedVaccine = this.value;
            var xhr = new XMLHttpRequest();
            xhr.open('POST', 'config/classes/getDose.php');
            xhr.setRequestHeader('Content-type', 'application/x-www-form-urlencoded');
            xhr.onload = function() {
                if (xhr.status === 200) {
                    var doseLabel = document.getElementById('dose');
                    doseLabel.innerHTML = ''; // Clear existing options
                    var doseCount = parseInt(xhr.responseText);
                    if (doseCount > 0) {
                        // Loop to create options
                        for (var i = 1; i <= doseCount; i++) {
                            var option = document.createElement('option');
                            option.value = i;
                            option.textContent = i;
                            doseLabel.appendChild(option);
                        }
                    } else {
                        // If no dose count, display a message
                        doseLabel.textContent = 'No doses available';
                    }
                } else {
                    console.error('Request failed. Status: ' + xhr.status);
                }
            };
            xhr.send('vaccineName=' + selectedVaccine);
        });
    </script>

<?php } ?>