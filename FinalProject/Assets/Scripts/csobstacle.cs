﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csobstacle : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if(other.transform.tag == "Player"){
			//other
		}
	}
}
