<?php
function dashboard($database)
{ ?>
    <?php
    $record_json1 = @file_get_contents('http://localhost:4000/childinfo/count');
    $childCount = "Data not available"; // Default value
    
    if ($record_json1 !== false) {
        $childCountData = json_decode($record_json1, true);
        if ($childCountData && isset($childCountData['count'])) {
            $childCount = $childCountData['count'];
        }
    }
    
    $record_json2 = @file_get_contents('http://localhost:4000/vacciness/count');
    $vaccineCount = "Data not available"; // Default value
    
    if ($record_json2 !== false) {
        $vaccineCountData = json_decode($record_json2, true);
        if ($vaccineCountData && isset($vaccineCountData['count'])) {
            $vaccineCount = $vaccineCountData['count'];
        }
    }

    $record_json3 = @file_get_contents('http://localhost:4000/vacciness/count');
    $allRecs = "Data not available"; // Default value
    
    if ($record_json3 !== false) {
        $recsCountData = json_decode($record_json3, true);
        if ($recsCountData && isset($recsCountData['count'])) {
            $allRecs = $recsCountData['count'];
        }
    }

    $record_json4 = @file_get_contents('http://localhost:4000/vacciness/count');
    $recsNow = "Data not available"; // Default value
    
    if ($record_json4 !== false) {
        $recsCountNow = json_decode($record_json4, true);
        if ($recsCountNow && isset($recsCountNow['count'])) {
            $recsNow = $recsCountNow['count'];
        }
    }

    ?>
    <style>

    </style>
    <div class="container-xxl flex-grow-1 container-p-y" style="margin-left: 5%;">
        <h4 class="fw-bold py-3 mb-4"><span class="text-muted fw-light"></span> DASHBOARD</h4>
        <div class="row" style="margin-top: 5%;">
            <div class="col-lg-5 col-md-5 col-sm-6 mb-2">
                <div class="card">
                    <button style="border:none ">
                        <div class="card-body" style="color:white; background-color:#1b1a5e; border-radius:30px ">
                            <a href="home.php?tab=manage_children">
                                <div class="card-title d-flex align-items-start justify-content-between">
                                    <div class="bx bx-group" style="color:white;font-size:50px "></div>
                                </div>
                                <span class="fw-semibold d-block mb-3" style="color:#00ffee;">Children Registered</span>
                                <h3 class="card-title mb-1" style="color:white;"><?php echo $childCount ?></h3>
                            </a>
                        </div>
                    </button>
                </div>
            </div>
            <div class="col-lg-5 col-md-5 col-sm-6 mb-2">
                <div class="card">

                    <button style="border:none">
                        <div class="card-body" style="background-color:#037b80; border-radius:30px">
                            <a href="home.php?tab=manage_vaccine">
                                <div class="card-title d-flex align-items-start justify-content-between">
                                    <div class="bx bxs-eyedropper" style="color:white;font-size:50px "></div>
                                </div>
                                <span class="fw-semibold d-block mb-3" style="color:#00ffee;">Vaccines</span>
                                <h3 class="card-title text-nowrap mb-1" style="color:white;"><?php echo $vaccineCount ?></h3>
                            </a>
                        </div>
                    </button>

                </div>
            </div>

        </div>

        <div class="row" style="margin-top: 5%;">
            <div class="col-lg-5 col-md-5 col-sm-6 mb-2">
                <div class="card">

                    <button style="border:none">
                        <div style="background-color:#037b80 ; border-radius:30px" class="card-body">
                            <a href="home.php?tab=shot_records">
                                <div class="card-title d-flex align-items-start justify-content-between">
                                    <div  class="bx bx-checkbox-checked" style="color:white;font-size:50px "></div>
                                </div>
                                <span class="fw-semibold d-block mb-3" style="color:#00ffee;">Injected Today</span>
                                <h3 class="card-title text-nowrap mb-1" style="color:white;"><?php echo $recsNow ?></h3>
                            </a>
                        </div>
                    </button>

                </div>
            </div>
            <div class="col-lg-5 col-md-5 col-sm-6 mb-2">
                <div class="card">

                    <button style="border:none">
                        <div class="card-body" style="background-color:#1b1a5e; border-radius:30px">
                            <a href="home.php?tab=shot_records">
                                <div class="card-title d-flex align-items-start justify-content-between">
                                    <div class="menu-icon tf-icons bx bxs-category" style="color:white;font-size:50px "></div>
                                </div>
                                <span class="fw-semibold d-block mb-3" style="color:#00ffee;">Total Injected</span>
                                <h3 class="card-title text-nowrap mb-1" style="color:white;"><?php echo $allRecs ?></h3>
                            </a>
                        </div>
                    </button>

                </div>
            </div>
            <?php
            //$totalEmployees = $database->getCount('employee_tbl');
            ?>

        </div>
    </div>
<?php } ?>