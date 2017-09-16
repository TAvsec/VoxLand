﻿using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float walkSpeed = 2;
	public float runSpeed = 6;
	public float gravity = -12;
	public float jumpHeight = 1;
	[Range(0,1)]
	public float airControlPercent;

	public float turnSmoothTime = 0.2f;
	float turnSmoothVelocity;

	public float speedSmoothTime = 0.1f;
	float speedSmoothVelocity;
	float currentSpeed;
	float velocityY;

	Animator animator;
	Transform cameraT;
	CharacterController controller;

	void Start () {
		animator = GetComponent<Animator> ();
		cameraT = Camera.main.transform;
		controller = GetComponent<CharacterController> ();
	}

	void Update () {
		// input

		float targetRotation =  cameraT.eulerAngles.y;
		transform.eulerAngles = Vector3.up * targetRotation;

		
		Debug.Log("C " + cameraT.eulerAngles.y); //-------------------
		Debug.Log("T " + transform.eulerAngles); //-------------------

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));
		Vector2 inputDir = input.normalized;
		bool running = Input.GetKey (KeyCode.LeftShift);

		Move (inputDir, running);

		if (Input.GetKeyDown (KeyCode.Space)) {
			Jump ();
		}
		// animator
		float animationSpeedPercent = ((running) ? currentSpeed / runSpeed : currentSpeed / walkSpeed * .5f);
		animator.SetFloat ("speedPercent", animationSpeedPercent, speedSmoothTime, Time.deltaTime);
		animator.SetFloat("direction", Input.GetAxisRaw ("Horizontal"));

	}

	void Move(Vector2 inputDir, bool running) {
		
		//float targetRotation = Mathf.Atan2 (inputDir.x, inputDir.y) * Mathf.Rad2Deg + cameraT.eulerAngles.y;
		//float targetRotation =  cameraT.eulerAngles.y;
		//transform.eulerAngles = Vector3.up * Mathf.SmoothDampAngle(transform.eulerAngles.y, targetRotation, ref turnSmoothVelocity, GetModifiedSmoothTime(turnSmoothTime));
		

		float targetSpeed = ((running) ? runSpeed : walkSpeed) ;
		currentSpeed = Mathf.SmoothDamp (currentSpeed, targetSpeed, ref speedSmoothVelocity, GetModifiedSmoothTime(speedSmoothTime));

		//GRAVITACIJA
		velocityY += Time.deltaTime * gravity;

		//SMER PREMIKANJA
		Vector3 velocity = transform.right * inputDir.x * targetSpeed + transform.forward * inputDir.y * targetSpeed+ Vector3.up * velocityY;

		//Debug.Log(currentSpeed);

		//PREMIKANJE
		controller.Move (velocity * Time.deltaTime );
		currentSpeed = new Vector2 (controller.velocity.x, controller.velocity.z).magnitude;

		//PREVERJANJE STIKA S TLEMI
		if (controller.isGrounded) {
			velocityY = 0;
		}

	}

	void Jump() {
		if (controller.isGrounded) {
			float jumpVelocity = Mathf.Sqrt (-2 * gravity * jumpHeight);
			velocityY = jumpVelocity;
		}
	}

	float GetModifiedSmoothTime(float smoothTime) {
		if (controller.isGrounded) {
			return smoothTime;
		}

		if (airControlPercent == 0) {
			return float.MaxValue;
		}
		return smoothTime / airControlPercent;
	}
}