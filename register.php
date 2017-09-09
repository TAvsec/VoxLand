<?php 
	$server_name		= "localhost";
	$server_username	= "id2853697_voxland";
	$server_password	= "!voxland";
	$dbName			 	= "id2853697_voxland";

	$userName 	= $_POST['username'];
	$email 		= $_POST['email'];
	$password 	= $_POST['password'];

	$conn = new mysqli($server_name,$server_username,$server_password,$dbName);
	if(!$conn){
		die("Connection failed");
	}

	$sql = "INSERT INTO Player_Account (Username,Email,Password,Nickname)
			VALUES ('".$userName."','".$email."','".$password."','".$userName."')";
	$result = mysqli_query($conn,$sql);

	if(!$result){
		echo "There was error registering your account";
	}else{
		echo "Account have been created";
	}
	


 ?>