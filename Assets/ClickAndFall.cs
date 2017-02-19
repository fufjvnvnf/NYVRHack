using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickAndFall : MonoBehaviour {

	RaycastHit hit;

	public GameObject bigball;
	public GameObject smallball;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Physics.Raycast (transform.position, transform.forward, out hit, 1000f)) {

			if (Input.GetMouseButtonDown (0)) {
				bigball.GetComponent<Rigidbody> ().useGravity = true;
				smallball.GetComponent<Rigidbody> ().useGravity = true;
			}
		}
	}
}
