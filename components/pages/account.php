<?php
function account()
{ ?>
  <div class="container-xxl flex-grow-1 container-p-y">
    <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light">Account Settings /</span> Create Account</h4>

    <div class="row">
      <div class="col-md-12">
        <!-- Account -->
        <hr class="my-0" />
        <div class="card">
          <div class="card-body">
            <div class="app-brand justify-content-center">
              <a href="index.html" class="app-brand-link gap-2">
                <h2><span class="fw-bold py-3 mb-4">Account</span></h2>
              </a>
            </div>
            <br><br>
            <br>
            <?php echo isset($msg) ? "<p style='color: red;text-align:center;margin-top: 0px; margin-bottom: 5px;'>$msg</p>" : ""; ?>
            <form id="formAuthentication" class="mb-3" method="POST" onsubmit="return validatePassword()">
              <div class="row">
                <div class="mb-3 col-md-6">

                  <label for="firstName" class="form-label">Username</label>
                  <input class="form-control" type="text" id="username" name="username" placeholder="Enter Username" autofocus required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="lastName" class="form-label">Password</label>
                  <input class="form-control" type="password" name="password" id="password" placeholder="Enter your password" required />
                </div>
                <div class="mb-3 col-md-6">
                  <label for="lastName" class="form-label">Confirm Password</label>
                  <input class="form-control" type="password" name="repassword" id="repassword" placeholder="Re-Enter your password" required />
                </div>
              </div>
              <br>
              <div class="mt-2" style="text-align: center;">
                <button type="submit" name="create" class="btn btn-primary me-2" style="width: 60%; text-align:center;background-color:#1b1a5e;margin-top:3%">Create Account</button>

              </div>
            </form>
            <script>
              function validatePassword() {
                var password = document.getElementById("password").value;
                var repassword = document.getElementById("repassword").value;
                if (password !== repassword) {
                  alert("Passwords do not match! Please try again.");
                  return false; // Prevent form submission
                } else {
                  alert("Account successfully Created!");
                }
                return true; // Allow form submission
              }
            </script>
          </div>
          <br>
        </div>
        <!-- /Account -->
      </div>
    </div>
  </div>

<?php } ?>