<?php

class Database {
    private $pdo;

    public function __construct($dsn, $db_user, $db_pw) {
        try {
            $this->pdo = new PDO($dsn, $db_user, $db_pw);
            $this->pdo->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
        } catch (PDOException $e) {
            die("Connection failed: " . $e->getMessage());
        }
    }

    public function authenticate($username, $password, $tablename) {
        $hashedPassword = "BhsXkflnsm".md5($password)."ls0a1L2";
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE username = ? AND password=?");
        $stmt->execute([$username, $hashedPassword]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
    

    public function validating($column, $value, $table) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$table} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value); 
        $stmt->execute(); 
    
        return $stmt->fetch(PDO::FETCH_ASSOC); 
    }

    public function addData($columns, $values, $tablename) {
        $columnNames = implode(',', $columns);
        $placeholders = implode(',', array_fill(0, count($columns), '?'));
        $stmt = $this->pdo->prepare("INSERT INTO {$tablename} ({$columnNames}) VALUES ({$placeholders})");
        $stmt->execute($values);
    }

    public function getAllData($tablename) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename}");
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function getChildData($tablename) {
        $stmt = $this->pdo->prepare("SELECT id, first_name, middle_name, last_name, sex, birthdate, child_blood_type, barangay, purok FROM {$tablename}");
        $stmt->execute();
        return $stmt->fetchAll(PDO::FETCH_ASSOC);
    }

    public function updateData($tablename, $column, $id, $newData) {
        $stmt = $this->pdo->prepare("UPDATE {$tablename} SET {$column} = :newData WHERE id = :id");
        $stmt->bindParam(':newData', $newData);
        $stmt->bindParam(':id', $id);
        $stmt->execute();
    }

    public function deleteData($tablename, $column, $value) {
        $stmt = $this->pdo->prepare("DELETE FROM {$tablename} WHERE {$column} = :value");
        $stmt->bindParam(':value', $value);
        $stmt->execute();
    }
    
    public function getDataById($tablename, $id) {
        $stmt = $this->pdo->prepare("SELECT * FROM {$tablename} WHERE id = ?");
        $stmt->execute([$id]);
        return $stmt->fetch(PDO::FETCH_ASSOC);
    }
    public function getCount($tablename) {
        $stmt = $this->pdo->prepare("SELECT COUNT(*) as totalCount FROM {$tablename}");
        $stmt->execute();
        $row = $stmt->fetch(PDO::FETCH_ASSOC);
        return $row['totalCount'];
    }

    public function getDosesForVaccine($vaccineId) {
        $query = "SELECT dose FROM vaccine_tbl WHERE id = ?";
        $stmt = $this->pdo->prepare($query);
        $stmt->execute([$vaccineId]);
        $result = $stmt->fetch(PDO::FETCH_ASSOC);
        
        if ($result) {
            return $result['dose'];
        } else {
            // Handle if the vaccine ID is not found
            return 0;
        }
    }
}

?>
