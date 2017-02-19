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
//		p0 = sphere_0.transform.position;
//		Debug.Log (p0.ToString());
//		p1 = sphere_1.transform.position;
//		Debug.Log (p1.ToString());
//
//		p2 = sphere_2.transform.position;
//		Debug.Log (p2.ToString());
//
//		p3 = sphere_3.transform.position;
//		Debug.Log (p3.ToString());
		p0 = new Vector3(-27.2f, 192.9f, 115.3f);
		p1 = new Vector3 (-27.2f, 193.0f, 106.2f);
		p2 = new Vector3 (-28.9f, 190.8f, 99.3f);
		p3 = new Vector3 (-29.0f, 190.8f, 94.2f);

	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 rayrayDirection = transform.TransformDirection(Vector3.forward);
		Vector3 rayDirection = new Vector3 (rayrayDirection.x, 0, rayrayDirection.z);
		Vector3 rayStart = transform.position + rayDirection- new Vector3(0,10,0);

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

		if (Physics.Raycast (rayStart, rayDirection, out hit, 1000f) && flag2 > 0) {
			Debug.Log (hit.collider.name);
			switch (hit.collider.tag) {
			case "select_0":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p0 + new Vector3 (0, 2, 0);
				sphere_1.transform.position = p1;
				sphere_2.transform.position = p2;
				sphere_3.transform.position = p3;
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_1":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p1 + new Vector3 (0, 2, 0);
				sphere_0.transform.position = p0;
				sphere_2.transform.position = p2;
				sphere_3.transform.position = p3;
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_2":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p2 + new Vector3 (0, 2, 0);
				sphere_0.transform.position = p0;
				sphere_1.transform.position = p1;
				sphere_3.transform.position = p3;
				if (Input.GetMouseButtonDown (0)) {
					temp.gameObject.SetActive (false);
					flag2--;
				}
				break;
			case "select_3":
				flag = true;
				temp = hit.collider.gameObject.transform;
				temp.position = p3 + new Vector3 (0, 2, 0);
				sphere_1.transform.position = p1;
				sphere_2.transform.position = p2;
				sphere_0.transform.position = p0;
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
		Debug.DrawRay(rayStart, rayDirection*10000, Color.green);
	}
}
