using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		if (Physics.Raycast (transform.position,transform.forward,out hit, 100f)) {
			Debug.Log (hit.collider.name);

		}
		Debug.DrawRay(transform.position, transform.forward, Color.green);
	}
}
