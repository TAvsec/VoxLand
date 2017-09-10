using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NetworkScript : MonoBehaviour {

	bool wwwIsRunning = false;

	[Header("Login forms")]
	public InputField usernameLogin_f;
	public InputField passwordLogin_f;
	/*----------------------------*/
	string username_login;
	string password_login;


	[Header("Register forms")]
	public InputField username_f;
	public InputField email_f;
	public InputField password_f;	
	public InputField passwordC_f;
	/*----------------------------*/
	string username;
	string email;
	string password;
	string passwordC;

	[Header("Animators")]
	public Animator register;
	public Animator login;	

	[Header("UI Elements")]
	public RectTransform loadingIcon;
	public GameObject StartScreen, MainMenu;

	public GameObject alert;

	void Start(){
		Debug.Log(PlayerPrefs.GetString("PlayerName"));
	}

	void Update(){
		username = username_f.text;
		email = email_f.text;
		password = password_f.text;
		passwordC = passwordC_f.text;

		username_login = usernameLogin_f.text;
		password_login =passwordLogin_f.text;

		if(wwwIsRunning){
			loadingIcon.Rotate(0,0,Time.deltaTime * 250,Space.World);
		}
			

		
	}

	public void Register(){
		WWWForm form = new WWWForm();
		form.AddField("username",username);
		form.AddField("email",email);
		form.AddField("password",password);

		if(password == passwordC){
			WWW www = new WWW("https://voxland.000webhostapp.com/register.php",form);
			Debug.Log("Account created");
			PlayerPrefs.SetString("PlayerName",username_f.text);
			register.SetTrigger("registerTrigger");
			StartScreen.SetActive(false);
			MainMenu.SetActive(true);
		}
		else{
			triggerAlert("Passwords must match",Color.red);
			password_f.text ="";
			passwordC_f.text ="";
			Debug.Log("Passwords must match");
		}
		
	}

	public void LoginButton(){
		StartCoroutine(Login());
	}

	IEnumerator Login(){
		WWWForm form = new WWWForm();
		form.AddField("username",username_login);
		form.AddField("password",password_login); 
		WWW www = new WWW("https://voxland.000webhostapp.com/login.php",form);

		startLoadingIcon();

		yield return www;

		wwwIsRunning = false;
		stopLoadingIcon();

		switch(www.text){
			case 	"Login succesfull":	
						PlayerPrefs.SetString("PlayerName",username_login);
						login.SetTrigger("loginScreen_trigger"); 
						StartScreen.SetActive(false);
						MainMenu.SetActive(true);
						Debug.Log(PlayerPrefs.GetString("PlayerName"));break;
			case 	"Wrong password":
						Debug.Log("Wrong password");
						triggerAlert("Wrong password",Color.red); break;
			case 	"User not found":
						Debug.Log("User not found");
						triggerAlert("User not found",Color.red);break;
			default : 	Debug.Log("There was an error.Try again later");
						triggerAlert("There was an error.Try again later",Color.red);break;
		}
		

	}

	void OnApplicationQuit(){
		PlayerPrefs.DeleteKey("PlayerName");
	}

	void startLoadingIcon(){
		loadingIcon.transform.eulerAngles = new Vector2(0,0);
		loadingIcon.gameObject.SetActive(true);
		wwwIsRunning = true;
		
	}

	void stopLoadingIcon(){
		loadingIcon.gameObject.SetActive(false);
	}

	public void triggerAlert(string alertText, Color alertColor){
		alert.GetComponent<Image>().color = alertColor;
		alert.GetComponentInChildren<Text>().text = alertText;
		alert.GetComponent<Animator>().SetTrigger("AlertTrigger");
	}

	
}
