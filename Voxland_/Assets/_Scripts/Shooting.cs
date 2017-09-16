using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour {

	public Animator anim;
	
	public float damage = 10f;
	public float range = 100f;

	public Camera cam;

	float x = 0;

	void Start () {
		anim = GetComponent<Animator>();
	}

	void Update(){
		if(Input.GetButton("Fire1") && Quaternion.Angle(Quaternion.Euler(transform.eulerAngles),Quaternion.Euler(Vector2.up * cam.transform.eulerAngles.y)) < 80 ){
			shoot(0.375f);
		}
	else{
			anim.SetBool("shoot",false);
		}

		//Debug.Log(Quaternion.Angle(Quaternion.Euler(transform.eulerAngles),Quaternion.Euler(Vector2.up * cam.transform.eulerAngles.y)));
	}

	public void shoot(float delayBetweenShots){
		
		//anim.SetBool("shoot",true);

		if(x>=delayBetweenShots ){
			anim.SetBool("shoot",true);

			RaycastHit hit;
			if(Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, range)){
				Debug.Log(hit.transform.name);

				DummyTarget dTarget = hit.transform.GetComponent<DummyTarget>();
				if(dTarget!=null){
					dTarget.TakeDamage(damage);
				}
			}
		x=0;
		}
		else{
			x+=Time.deltaTime;
		}
	}
	
}
