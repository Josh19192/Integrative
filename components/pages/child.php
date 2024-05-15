<?php
function child()
{ ?>
  <div class="container-xxl flex-grow-1 container-p-y">

    <div class="row">
      <div class="col-md-12">
        <!-- Account -->
        <hr class="my-0" />
        <div class="card">
          <div class="card-body">
            <div class="app-brand justify-content-center">
              <h4 class="fw-bold py-3 mb-2"><span class="text-muted fw-light">Child Info /</span> Add Child</h4>
            </div>
            <br>
            <br>
            <form id="formAuthentication" class="mb-3" method="POST" action="home.php?tab=manage_children">
              <div class="row">
                <div class="mb-3 col-md-6">

                  <label for="first_name" class="form-label">First Name</label>
                  <input class="form-control" type="text" id="first_name" name="first_name" placeholder="Enter First Name" autofocus required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="middle_name" class="form-label">Middle Name</label>
                  <input class="form-control" type="text" name="middle_name" name="middle_name" id="middle_name" placeholder="Enter middle name" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="last_name">Last Name</label>
                  <input class="form-control" type="text" id="last_name" name="last_name" placeholder="Enter last name" required>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="sex" class="form-label">Sex</label>
                  <select class="form-select" name="sex" id="sex" required>
                    <option value="">Select sex</option>
                    <option value="male">Male</option>
                    <option value="female">Female</option>
                  </select>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="birthdate">Birthdate</label>
                  <input class="form-control" type="datetime-local" id="birthdate" name="birthdate" required>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="place_of_birth" class="form-label">Place of Birth</label>
                  <input class="form-control" type="text" name="place_of_birth" id="place_of_birth" placeholder="Enter place of birth" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="birth_method">Birth Method</label>
                  <input class="form-control" type="text" id="birth_method" name="birth_method" placeholder="Enter birth method eg. normal, caesarian, etc." required>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="child_blood_type" class="form-label">Blood Type</label>
                  <select class="form-select" name="child_blood_type" id="child_blood_type" required>
                    <option value="">Select blood type</option>
                    <option value="A+">A+</option>
                    <option value="A-">A-</option>
                    <option value="B+">B+</option>
                    <option value="B-">B-</option>
                    <option value="AB+">AB+</option>
                    <option value="AB-">AB-</option>
                    <option value="O+">O+</option>
                    <option value="O-">O-</option>
                  </select>
                </div>

                <div class="mb-3 col-md-6">
                  <label for="barangay">Barangay</label>
                  <input class="form-control" type="text" id="barangay" name="barangay" placeholder="Enter barangay" required>
                </div>
                <div class="mb-3 col-md-6">
                  <label for="purok">Purok</label>
                  <input class="form-control" type="text" id="purok" name="purok" placeholder="Enter purok" required>
                </div>

              </div>

              <h4 class="fw-bold py-3 mb-4">Mother's info / <span class="text-muted fw-light">Leave if none</span> </h4>

              <div class="row">
                <div class="col-md-12">
                  <!-- Account -->
                  <hr class="my-0" />
                  <div class="card">
                    <div class="card-body">
                      <div class="app-brand justify-content-center">

                      </div>
                      <?php echo isset($error) ? "<p style='color: red;text-align:center;margin-top: 0px; margin-bottom: 5px;'>$error</p>" : ""; ?>
                      <br>
                     
                        <div class="row">
                          <div class="mb-3 col-md-6">
                            <label for="mother_fname" class="form-label">First Name</label>
                            <input class="form-control" type="text" id="mother_fname" name="mother_fname" placeholder="Enter First Name" autofocus />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="mother_mname" class="form-label">Middle Name</label>
                            <input class="form-control" type="text" name="mother_mname" id="mother_mname" placeholder="Enter middle name"  />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="mother_lname">Last Name</label>
                            <input class="form-control" type="text" id="mother_lname" name="mother_lname" placeholder="Enter last name" >
                          </div>
                         
                          <div class="mb-3 col-md-6">
                            <label for="mother_blood_type" class="form-label">Blood Type</label>
                            <select class="form-select" name="mother_blood_type" id="mother_blood_type" >
                              <option value="">Select blood type</option>
                              <option value="A+">A+</option>
                              <option value="A-">A-</option>
                              <option value="B+">B+</option>
                              <option value="B-">B-</option>
                              <option value="AB+">AB+</option>
                              <option value="AB-">AB-</option>
                              <option value="O+">O+</option>
                              <option value="O-">O-</option>
                            </select>
                          </div>

                          <div class="mb-3 col-md-6">
                            <label for="mother_citizenship">Citizenship</label>
                            <input class="form-control" type="text" id="mother_citizenship" name="mother_citizenship" placeholder="Enter citizenship" >
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="mother_occupation">Occupation</label>
                            <input class="form-control" type="text" id="mother_occupation" name="mother_occupation" placeholder="Enter Occupation">
                          </div>

                        </div>
                       

                      

                    </div>
                    
                  </div>
                  <!-- /Account -->
                </div>
              </div>
              <br>
              <h4 class="fw-bold py-3 mb-4">Father's info / <span class="text-muted fw-light">Leave if none</span> </h4>

              <div class="row">
                <div class="col-md-12">
                  <!-- Account -->
                  <hr class="my-0" />
                  <div class="card">
                    <div class="card-body">
                      <div class="app-brand justify-content-center">

                      </div>

                      <?php echo isset($error) ? "<p style='color: red;text-align:center;margin-top: 0px; margin-bottom: 5px;'>$error</p>" : ""; ?>
                      <br>
                      
                        <div class="row">
                          <div class="mb-3 col-md-6">
                            <label for="father_fname" class="form-label">First Name</label>
                            <input class="form-control" type="text" id="father_fname" name="father_fname" placeholder="Enter First Name"   />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="father_mname" class="form-label">Middle Name</label>
                            <input class="form-control" type="text" name="father_mname"  id="father_mname" placeholder="Enter middle name"  />
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="father_lname">Last Name</label>
                            <input class="form-control" type="text" id="father_lname" name="father_lname" placeholder="Enter last name" >
                          </div>
                         
                          <div class="mb-3 col-md-6">
                            <label for="father_blood_type" class="form-label">Blood Type</label>
                            <select class="form-select" name="father_blood_type" id="father_blood_type">
                              <option value="">Select blood type</option>
                              <option value="A+">A+</option>
                              <option value="A-">A-</option>
                              <option value="B+">B+</option>
                              <option value="B-">B-</option>
                              <option value="AB+">AB+</option>
                              <option value="AB-">AB-</option>
                              <option value="O+">O+</option>
                              <option value="O-">O-</option>
                            </select>
                          </div>

                          <div class="mb-3 col-md-6">
                            <label for="father_citizenship">Citizenship</label>
                            <input class="form-control" type="text" id="father_citizenship" name="father_citizenship" placeholder="Enter citizenship" >
                          </div>
                          <div class="mb-3 col-md-6">
                            <label for="father_occupation">Occupation</label>
                            <input class="form-control" type="text" id="father_occupation" name="father_occupation" placeholder="Enter Occupation" >
                          </div>

                        </div>
                       

                      
                    </div>
                   
                  </div>
                  <!-- /Account -->
                </div>
              </div>
               <br><br>
              <div class="mt-2" style=" text-align:center">
                <button type="submit" name="child" onclick="showMessageBox()" class="btn btn-primary me-2" style="width: 60%; text-align:center;background-color:#1b1a5e">Save</button>

              </div>
            </form>

          </div>
          <br>
        </div>
        <!-- /Account -->
      </div>
    </div>
  </div>

<?php } ?>
<script>
  function showMessageBox() {
    alert('Successfully Saved!');
  }
</script>