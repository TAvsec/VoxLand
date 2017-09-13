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

	$sql = "SELECT Username 
			FROM Player_Account 
			WHERE Username = '$userName' ";

	
	$result = mysqli_query($conn,$sql);

	
	if(mysqli_num_rows($result)==0)
		{
			$sql = "INSERT INTO Player_Account (Username,Email,Password,Nickname)
					VALUES ('".$userName."','".$email."','".$password."','".$userName."')";
			$result = mysqli_query($conn,$sql);
			echo "Account have been created";
		}
	else{
		echo("Account with that username already exist");
	}
		
	


 ?>