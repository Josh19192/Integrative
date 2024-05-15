<?php
function update_vaccine($database)
{
  // Check if the record ID is provided in the URL
  if (isset($_GET['id'])) {
    $record_id = $_GET['id'];

    $record = $database->getDataById('vaccine_tbl', $record_id);
  }

?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Update Vaccine /</span> Vaccine</h4>

    <div class="row">
      <div class="col-md-12">

        <div class="card mb-4">

          <hr class="my-0" />
          <div class="card-body">
            <div class="app-brand justify-content-center">
              <a href="index.html" class="app-brand-link gap-2">
                <h2><span class="fw-bold py-3 mb-4">Update Vaccine</span></h2>
              </a>
            </div>
            <br>
            <form method="POST" action = "home.php?tab=manage_vaccine">
            <input type="hidden" name="id" value="<?= $record['id'] ?>">
              <div class="row">
                <div class="mb-3 col-md-6">
                  <label for="vaccine_name" class="form-label">Vaccine name</label>
                  <input class="form-control" type="text" name="vaccine_name" id="vaccine_name" placeholder="Enter vaccine name" value="<?= $record['vaccine_name'] ?>" autofocus required />
                </div>

                <div class="mb-3 col-md-6">
                  <label for="vaccine_brand" class="form-label">Vaccine brand</label>
                  <input class="form-control" type="text" name="vaccine_brand" id="vaccine_brand" placeholder="Enter vaccine brand" value="<?= $record['vaccine_brand'] ?>" autofocus required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="date_added" class="form-label">Date added</label>
                  <input class="form-control" type="date" name="date_added" id="date_added" placeholder="Select date" value="<?= $record['date_added'] ?>" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="dose" class="form-label">Dose Number</label>
                  <input type="number" class="form-control" id="dose" name="dose" placeholder="Enter dose number" value="<?= $record['dose'] ?>" required />
                </div>

              </div>
              <div class="mt-2" style="text-align:center">
                <button type="submit" name="update_vaccine" onclick="showMessageBox()" class="btn btn-primary me-2"  style="width: 60%; text-align:center;background-color:#1b1a5e;margin-top:3%">Update</button>

              </div>
            </form>
          </div>
          <!-- /Account -->
        </div>



      </div>
      <script>
        function showMessageBox() {
          alert("Save Successfully");
        }
      </script>
    </div>
  </div>
<?php } ?>