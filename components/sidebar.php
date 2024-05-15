<!-- Layout wrapper -->
<div class="layout-wrapper layout-content-navbar">
  <div class="layout-container">
    <!-- Menu -->

    <aside id="layout-menu" class="layout-menu menu-vertical menu bg-menu-theme">
      <div><br>
        <div class="app-brand demo">
          <a href="index.php" class="app-brand-link">
            <span class="app-brand-logo">
              <img src="assets/img/favicon/vaccine.jpg" height="90px" width="85px" style="border-radius: 50%;">
            </span>
            <span class="app-brand-text menu-text fw-bolder ms-2">CHILD VACCINE <br>INFORMATION</span>
          </a>
          <a href="javascript:void(0);" class="layout-menu-toggle menu-link text-large ms-auto d-block d-xl-none">
            <i class="bx bx-chevron-left bx-sm align-middle"></i>
          </a>
        </div>
        <br>
        <div class="menu-inner-shadow"></div>

        <ul class="menu-inner py-1">
          <!-- Dashboard -->
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'dashboard') {
                                  echo 'active';
                                } ?> ">
            <a href="home.php?tab=dashboard" class="menu-link">
              <i class="menu-icon tf-icons bx bxs-home-circle"></i>
              <div data-i18n="Analytics">Dashboard</div>
            </a>
          </li>


          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'child' || $current_tab == 'manage_child') {
                                  echo 'active open';
                                } ?>">
            <a href="javascript:void(0);" class="menu-link menu-toggle">
              <i class="menu-icon tf-icons bx bxs-group"></i>
              <div data-i18n="Account Settings">Children</div>
            </a>
            <ul class="menu-sub">
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'child') {
                                      echo 'active';
                                    } ?>">
                <a href="home.php?tab=child" class="menu-link">
                  <div data-i18n="Account">Add Child</div>
                </a>
              </li>
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'manage_children') {
                                      echo 'active ';
                                    } ?> ">
                <a href="home.php?tab=manage_children" class="menu-link">
                  <div data-i18n="Notification">Manage Children</div>
                </a>
              </li>

            </ul>
          </li>
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'shot_records') {
                                  echo 'active';
                                } ?> ">
            <a href="home.php?tab=shot_records" class="menu-link">
              <i class="menu-icon tf-icons bx bxs-food-menu"></i>
              <div data-i18n="Analytics">Shot Records</div>
            </a>
          </li>

          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'vaccine' || $current_tab == 'manage_vaccine') {
                                  echo 'active open';
                                } ?>">
            <a href="javascript:void(0);" class="menu-link menu-toggle">
              <i class="menu-icon tf-icons bx bxs-bong"></i>
              <div data-i18n="Account Settings">Vaccines</div>
            </a>
            <ul class="menu-sub">
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'vaccine') {
                                      echo 'active';
                                    } ?>">
                <a href="home.php?tab=vaccine" class="menu-link">
                  <div data-i18n="Account">Add Vaccine</div>
                </a>
              </li>
              <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'manage_vaccine') {
                                      echo 'active';
                                    } ?>">
                <a href="home.php?tab=manage_vaccine" class="menu-link">
                  <div data-i18n="Notifications">Manage Vaccine</div>
                </a>
              </li>

            </ul>
          </li>
          <li class="menu-item <?php if (isset($current_tab) && $current_tab == 'account') {
                                  echo 'active';
                                } ?> ">
            <a href="home.php?tab=account<?php echo isset($_GET['user_id']) ? '&user_id=' . $_GET['user_id'] : ''; ?>" class="menu-link">

              <i class="menu-icon tf-icons bx bx-user me-1"></i>
              <div data-i18n="Analytics">Account</div>
            </a>
          </li>
          <li class="menu-item ">
            <a href="#" class="menu-link" onclick="confirmLogout()">
              <i class="bx bx-power-off me-2"></i>
              <span class="align-middle">Log Out</span>
            </a>
          </li>
        </ul>
      </div>
    </aside>
    <script>
      function confirmLogout() {
        if (confirm("Are you sure you want to log out?")) {
          window.location.href = "config/classes/logout.php";
        }
      }
    </script>
    <!-- / Menu -->