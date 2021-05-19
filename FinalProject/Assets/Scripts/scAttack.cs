using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scAttack : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//other.GetComponent<scPlayer> ().hltPnt =
		//	this.GetComponent<raycast> ().hltPnt - this.GetComponent<raycast> ().hltPnt;
	}
}
