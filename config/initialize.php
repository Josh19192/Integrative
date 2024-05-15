<?php
require_once('classes/database.php');
require_once('classes/session.php');
require_once('config/classes/htmlclass.php');
require_once('components/pages/dashboard.php');
require_once('components/pages/child.php');
require_once('components/pages/manage_children.php');
require_once('components/pages/vaccine.php');
require_once('components/pages/manage_vaccine.php');
require_once('components/pages/update_child.php');
require_once('components/pages/update_vaccine.php');
require_once('components/pages/inject.php');
require_once('components/pages/shot_records.php');
require_once('components/pages/update_shot.php');
require_once('components/pages/account.php');



//require_once('components/pages/user_interface.php');



// Database configuration
$db_host = 'localhost';
$db_user = 'root';
$db_pass = '';
$db_name = 'child_vaccine';

// Create database connection
$database = new Database("mysql:host={$db_host};dbname={$db_name}", $db_user, $db_pass);

$session = new Session;
$session->db_connect(); 
require_once('classes/posts.php');


?>
