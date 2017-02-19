using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Walking : MonoBehaviour {

	public Animator anim;
	public int speed;
	public float z;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

	}

	// Update is called once per frame
	void Update () {
		if (anim.bodyPosition.z >= z)
			transform.position -= Vector3.forward * Time.deltaTime * speed;

		anim.SetFloat ("Destination", anim.bodyPosition.z);
	}	
}