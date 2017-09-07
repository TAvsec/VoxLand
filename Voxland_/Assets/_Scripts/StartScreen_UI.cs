using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartScreen_UI : MonoBehaviour {

	public Animator logAnim;
	public Animator regAnim;
	
	public void changeForms(){
		logAnim.SetTrigger("loginScreen_trigger");
		regAnim.SetTrigger("registerTrigger");
	}
	
}
