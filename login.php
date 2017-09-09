<?php 
	$server_name		= "localhost";
	$server_username	= "id2853697_voxland";
	$server_password	= "!voxland";
	$dbName			 	= "id2853697_voxland";

	$conn = new mysqli($server_name,$server_username,$server_password,$dbName);
	if(!$conn){
		die("Connection failed");
	}

	$username = $_POST['username'];
	$password = $_POST['password'];

	$sql = "SELECT Password
			FROM Player_Account
			WHERE Username = '".$username."'";
	$result = mysqli_query($conn,$sql);

	if(mysqli_num_rows($result) > 0){
		while($row=mysqli_fetch_assoc($result)){
			if($row['Password'] == $password){
				echo "Login succesfull";
			}
			else{
				echo "Wrong password";
			}
		}
	}
	else{
		echo "User not found";
	}

 ?>