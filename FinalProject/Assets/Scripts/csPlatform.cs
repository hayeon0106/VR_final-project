using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlatform : MonoBehaviour {
	//플랫폼에 닿으면 일어나야할 일(csPlayerMove 비활성화, csSpawn 활성화)
	//스테이지 종료
	public GameObject head;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		head.SendMessage ("doStage");
		head.transform.position = this.transform.position;
	}
}
