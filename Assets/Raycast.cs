using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour {
	Transform temp = null;
	bool flag = false;
	Vector3 StartPosition;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		RaycastHit hit;
		Vector3 rayDirection = transform.TransformDirection (Vector3.forward);

		if (temp != null && flag == false){
			temp.position = new Vector3 (-43, 10, -54);
		}

		if (Physics.Raycast (transform.position, transform.forward, out hit, 100f)) {
			Debug.Log (hit.collider.name);
			if (hit.collider.tag == "Selectable") {
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = new Vector3 (-43, 30, -54);
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
				}
			} else {
				flag = false;
			} 
		} else {
			flag = false;
		}
		Debug.DrawRay(transform.position + rayDirection, rayDirection * 100000, Color.green);
	}

}
