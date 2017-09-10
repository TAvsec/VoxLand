using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text userNameTxt;
	
	void OnEnable () {
		Debug.Log(PlayerPrefs.GetString("PlayerName"));
		userNameTxt.text = "Welcome, " + PlayerPrefs.GetString("PlayerName");	
	}
	
}
