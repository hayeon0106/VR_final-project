using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scPlatform : MonoBehaviour {
	public GameObject player;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		player.GetComponent<scPlayer> ().enabled = false;
		player.transform.position = this.transform.position;
	}
}
