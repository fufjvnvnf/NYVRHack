using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scrit : MonoBehaviour {

	public float turnSpeed = 10f; 
	void Update() {
		transform.Rotate (Vector3.up, turnSpeed * Time.deltaTime);
	}
}
