<?php
   include("config/initialize.php");
   if (!$session->is_logged_in()) {
      header("Location: index.php");
      exit();
  }

   HTML :: head();
   $current_tab = " ";

   if(isset($_GET['tab']))
   {
    $current_tab = $_GET['tab'];
   }
   HTML :: sidebar($current_tab);
   HTML :: navbar();

   if($current_tab == "dashboard")
   {
    dashboard($database);
   }
   
   if($current_tab == "child")
   {
    child();
   }

   if($current_tab == "manage_children")
   {
      manage_children($database);
   }
   
   if($current_tab == "vaccine")
   {
      vaccine();
   }
   
   if($current_tab == "manage_vaccine")
   {
      manage_vaccine($database);
   }
   if($current_tab == "update_child")
   {
      update_child($database);
   }
   
   if($current_tab == "update_vaccine")
   {
      update_vaccine($database);
   }

   if($current_tab == "inject")
   {
      inject($database);
   }
   if($current_tab == "shot_records")
   {
      shot_records($database);
   }
   if($current_tab == "update_shot")
   {
      update_shot($database);
   }
   if($current_tab == "account")
   {
      account();
   }


   HTML ::footer();

?>
