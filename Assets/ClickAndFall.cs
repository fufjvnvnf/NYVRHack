using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class ClickAndFall : MonoBehaviour {

	RaycastHit hit;

	public GameObject bigball;
	public GameObject smallball;
	private AudioSource[] speakings;
	private DateTime t0;
	private bool audio1 = true;
	private bool audio10 = false;

	// Use this for initialization
	void Start () {
		speakings = this.GetComponents<AudioSource> ();
		t0 = System.DateTime.Now;
		// Hint0: Introduction
	}
	
	// Update is called once per frame
	void Update () {
		
		TimeSpan delta = System.DateTime.Now.Subtract (t0);
//
		if (delta.Seconds > 0.5 && audio1) {
			speakings [0].Play ();
			audio1 = false;
		}

		if (delta.Seconds > 7 && audio10) {
			speakings [0].Stop ();
			audio10 = false;
		}
		Physics.Raycast (transform.position, transform.forward, out hit, 10000f);
		print (hit.collider.name);
//

		if (Physics.Raycast (transform.position, transform.forward, out hit, 10000f)) {
			Debug.Log (hit.collider.name);
			if (Input.GetMouseButtonDown (0)) {
				audio10 = true;
				bigball.GetComponent<Rigidbody> ().useGravity = true;
				smallball.GetComponent<Rigidbody> ().useGravity = true;
				t0 = System.DateTime.Now;
			}
		}
	}
}
