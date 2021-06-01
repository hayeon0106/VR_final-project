using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerAttack : MonoBehaviour {
	GameObject player;

	// Use this for initialization
	void Start () {
		player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

	}

	void OnTriggerEnter(Collider other){
		//몬스터 공격 받음
		if (other.transform.tag == "enemy") {
			Debug.Log ("몬스터를 공격");

			other.GetComponent<csEnemy> ().hltPnt = //몬스터 채력 감소
				other.GetComponent<csEnemy> ().hltPnt - player.GetComponent<csPlayer> ().atkPnt;
			
			Destroy (this.gameObject);
			Debug.Log ("공격하고 사라짐");
		}
	}
}
