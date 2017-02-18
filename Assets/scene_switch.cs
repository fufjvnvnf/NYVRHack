using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scene_switch : MonoBehaviour {

	// Use this for initialization
	void Start () {
		System.Threading.Thread.Sleep(5000);
		SceneManager.LoadScene ("Tower_Scene");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
