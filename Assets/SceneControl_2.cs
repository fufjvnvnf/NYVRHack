using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;


public class SceneControl_2 : MonoBehaviour{

	DateTime v_0;

	void Start () {
		v_0 = System.DateTime.Now;
		//		person.GetComponents<AudioSource>()[0].Play();
	}

	void Update (){
		if (System.DateTime.Now.Subtract (v_0).Seconds > 5) {
			SceneManager.LoadScene (2);
		}
	}
}
