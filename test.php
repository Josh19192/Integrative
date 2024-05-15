<div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Add Vaccine /</span> Vaccine</h4>

    <div class="row">
      <div class="col-md-12">

        <div class="card mb-4">

          <hr class="my-0" />
          <div class="card-body">
            <div class="app-brand justify-content-center">
              <a href="index.html" class="app-brand-link gap-2">
                <h2><span class="fw-bold py-3 mb-4">Add Vaccine</span></h2>
              </a>
            </div>
            <br>
            <form id="formData" name="formData" method="POST" >
              <div class="row">
                <div class="mb-3 col-md-6">
                  <label for="vaccine_name" class="form-label">Vaccine name</label>
                  <input class="form-control" type="text" name="vaccine_name" id="vaccine_name" placeholder="Enter vaccine name" autofocus required />
                </div>

                <div class="mb-3 col-md-6">
                  <label for="vaccine_brand" class="form-label">Vaccine brand</label>
                  <input class="form-control" type="text" name="vaccine_brand" id="vaccine_brand" placeholder="Enter vaccine brand" autofocus required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="date_added" class="form-label">Date added</label>
                  <input class="form-control" type="date" name="date_added" id="date_added" placeholder="Select date" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="dose" class="form-label">Dose Number</label>
                  <input type="number" class="form-control" id="dose" name="dose" placeholder="Enter dose number" required />
                </div>

              </div>
              <div class="mt-2">
                <button type="submit" name="submit" onclick="submitForm()" class="btn btn-primary me-2">Save Vaccine</button>

              </div>
            </form>
          </div>
          <!-- /Account -->
        </div>

      </div>
    </div>
  </div>
  <script>
        function submitForm() {
            const vaccineName = document.getElementById('vaccine_name').value;
            const vaccineBrand = document.getElementById('vaccine_brand').value;
            const dose = document.getElementById('dose').value;
            const dateAdded = document.getElementById('date_added').value;

            const formData = {
                vaccine_name: vaccineName,
                vaccine_brand: vaccineBrand,
                dose: dose,
                date_added: dateAdded
            };

            fetch('http://localhost:4000/vaccine', {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json'
                },
                body: JSON.stringify(formData)
            })
            .then(response => {
                if (!response.ok) {
                    throw new Error('Network response was not ok');
                }
                return response.json();
            })
            .then(data => {
                console.log('Data inserted successfully:', data);
                // Optionally, you can display a success message to the user
                alert('Data inserted successfully');
            })
            .catch(error => {
                console.error('Error inserting data:', error);
                // Optionally, you can display an error message to the user
                alert('Error inserting data. Please try again.');
            });
        }
    </script>