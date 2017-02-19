using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene2_Script : MonoBehaviour {

//	private IEnumerator coroutine;

	float length = 1000.0f;

	public GameObject camera = null;
	// Use this for initialization
	void Start () {
//		coroutine = Begin ();
//		StartCoroutine (coroutine);
	}

	// Update is called once per frame
	void Update () {
//		print (camera.transform.position.ToString());
		RaycastHit hit;
		Vector3 rayDirection = camera.transform.TransformDirection(transform.forward);
		Vector3 rayStart = camera.transform.position + rayDirection;
		Debug.DrawRay(rayStart, rayDirection * length);
		if (Physics.Raycast(rayStart, rayDirection, out hit, length)) {
			if (hit.collider.tag == "Selectable") {
				// Do stuff
			}
		}
		Debug.Log (hit.collider.name);

//		if (temp != null && flag == false){
//			temp.position = new Vector3 (-43, 10, -54);
//		}
//
//		if (Physics.Raycast (transform.position, transform.forward, out hit, 100f)) {
//			Debug.Log (hit.collider.name);
//			if (hit.collider.tag == "Selectable") {
//				flag = true;
//				temp = hit.collider.gameObject.transform;
//				temp.position = new Vector3 (-43, 30, -54);
//				if (Input.GetMouseButtonDown (0)) {
//					temp.gameObject.SetActive (false);
//				}
//			} else {
//				flag = false;
//			} 
//		} else {
//			flag = false;
//		}
//
//		Debug.DrawRay (transform.position + rayDirection, rayDirection * 100000, Color.green);
	}

//	private IEnumerator Begin() {
//		while (true) {
////			yield return new WaitForSeconds(waitTime);
//		}
//	}
}
