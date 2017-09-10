using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartScreen_UI : MonoBehaviour {

	public Animator logAnim;
	public Animator regAnim;

	public InputField[] loginInputFields;
	public InputField[] registerInputFields;

	void Update(){
		if(Input.GetKeyDown(KeyCode.Tab)){
			if(loginInputFields[0].isFocused){
				loginInputFields[1].ActivateInputField();
			}

			else if(registerInputFields[0].isFocused){
				registerInputFields[1].ActivateInputField();
			}
			else if(registerInputFields[1].isFocused){
				registerInputFields[2].ActivateInputField();
			}
			else if(registerInputFields[2].isFocused){
				registerInputFields[3].ActivateInputField();
			}
			
		}
	}
	
	public void changeForms(){
		logAnim.SetTrigger("loginScreen_trigger");
		regAnim.SetTrigger("registerTrigger");
		for(int i=0;i<loginInputFields.Length;i++){
			loginInputFields[i].text = "";
		}

		for(int i=0;i<registerInputFields.Length;i++){
			registerInputFields[i].text = "";
		}
	}

	public void StartButton(string levelName){
		SceneManager.LoadScene(levelName);
	}
	
}
