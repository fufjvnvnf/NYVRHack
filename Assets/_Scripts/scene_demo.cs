using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class scrit : MonoBehaviour {

	void start() {
		System.Threading.Thread.Sleep (5000);
		SceneManager.LoadScene ("_Scenes/Tower_Scene");
	}
	void Update() {
		
	}
}


