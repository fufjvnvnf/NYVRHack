using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class SceneControl : MonoBehaviour {

	[SerializeField]
	public GameObject person;

	// Use this for initialization
	void Start () {
		System.Threading.Thread.Sleep (10000);
//		SceneManager.LoadScene (1);
		person.GetComponents<AudioSource>()[0].Play();
	}
}
