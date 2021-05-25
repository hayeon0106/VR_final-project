using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csAttack : MonoBehaviour {
	//Trigger 이벤트 모음
	//몬스터 -> 플레이어 공격
	//플레이어 기술 -> 몬스터

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		//부딪힌 것이 플레이어
		if(other.transform.tag == "Player"){		//플레이어 공격 받음
			Debug.Log ("플레이어를 공격");
			//anim.SetBool ("isAttack", true);	//애니메이션 변경 - 공격, 몬스터의 공격 모션
			other.GetComponent<csPlayer> ().hltPnt = 	//플레이어 체력 감소
				other.GetComponent<csPlayer> ().hltPnt - GetComponent<csEnemy>().atkPnt;
		}

		//부딪힌 것이 플레이어의 기술
		if (other.transform.tag == "attack") {		//몬스터 공격 받음
			Debug.Log ("몬스터를 공격");
			GetComponent<csEnemy>().hltPnt = 			//몬스터 채력 감소
				GetComponent<csEnemy>().hltPnt - other.GetComponent<csPlayer> ().atkPnt;
		}
	}
}
