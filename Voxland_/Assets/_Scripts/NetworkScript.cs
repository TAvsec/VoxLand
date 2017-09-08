using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkScript : MonoBehaviour {

	string username;
	string email;
	string password;
	string passwordC;

	public InputField username_f;
	public InputField email_f;
	public InputField password_f;	
	public InputField passwordC_f;	

	public GameObject alarm;

	void Update(){
		username = username_f.text;
		email = email_f.text;
		password = password_f.text;
		passwordC = passwordC_f.text;
	}

	public void Register(){
		WWWForm form = new WWWForm();
		form.AddField("username",username);
		form.AddField("email",email);
		form.AddField("password",password);

		if(password == passwordC){
			WWW www = new WWW("https://voxland.000webhostapp.com/register.php",form);
			Debug.Log("Account created");
		}
		else{
			alarm.GetComponent<Animator>().SetTrigger("AlertTrigger");
			password_f.text ="";
			passwordC_f.text ="";
			Debug.Log("Passwords must match");
		}
		
	}
	
}
