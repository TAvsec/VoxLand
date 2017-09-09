using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour {

	public Text userNameTxt;
	
	void OnEnable () {
		userNameTxt.text = "Welcome, " + PlayerPrefs.GetString("PlayerName");	
	}
	
}
