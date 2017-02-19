using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Ball : MonoBehaviour {

	public GameObject sphere_0;
	public GameObject sphere_1;
	public GameObject sphere_2;
	public GameObject sphere_3;

	 Vector3 p0;
	 Vector3 p1;
	 Vector3 p2;
	 Vector3 p3;

	Transform temp = null;
	bool flag = false;
	int flag2 = 2;

	// Use this for initialization
	void Start () {
		p0 = sphere_0.transform.position;
		p1 = sphere_1.transform.position;
		p2 = sphere_2.transform.position;
		p3 = sphere_3.transform.position;

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 rayDirection = transform.TransformDirection (Vector3.forward);

		if (temp != null && flag == false){
			switch (temp.gameObject.tag) {
			case "select_0":
				temp.position = p0;
				break;
			case "select_1":
				temp.position = p1;
				break;
			case "select_2":
				temp.position = p2;
				break;
			case "select_3":
				temp.position = p3;
				break;
			}
		}

		if (Physics.Raycast (transform.position, transform.forward, out hit, 100f) && flag2 > 2) {
			Debug.Log (hit.collider.name);
			switch (hit.collider.tag) {
			case "select_0":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p0 + new Vector3 (0, 2, 0);
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_1":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p1 + new Vector3 (0, 2, 0);
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_2":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p2 + new Vector3 (0, 2, 0);
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_3":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p3 + new Vector3 (0, 2, 0);
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			default:
				flag = false;
				break;
			}
		}else {
			flag = false;
		}
		Debug.DrawRay(transform.position + rayDirection, rayDirection * 100000, Color.green);
	}
}
