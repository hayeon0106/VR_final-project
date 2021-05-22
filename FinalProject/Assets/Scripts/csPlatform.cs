using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlatform : MonoBehaviour {
	//플랫폼에 닿으면 일어나야할 일(csPlayerMove 비활성화, csSpawn 활성화)
	//스테이지 종료
	public GameObject player;
	public GameObject spawn;

	public bool isFinish = false;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (isFinish) {
			//종료 시 일어나는 일

		}
		player.GetComponent<csPlayerMove> ().enabled = false;
		spawn.GetComponent<csSpawn> ().enabled = true;
		player.transform.position = this.transform.position;
	}
}
