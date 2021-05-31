using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemyAttack : MonoBehaviour {
	Animator anim;

	float timer;
	int waitingTime;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		timer = 0.0f;
		waitingTime = 3;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
	}

	void OnTriggerEnter(Collider other){
		//부딪힌 것이 플레이어
		if(other.transform.tag == "Player"){		//플레이어 공격 받음
			//플레이어에게 닿았을 때 collider 크기를 변경
			GetComponent<BoxCollider>().size = new Vector3(1.0f,1.0f,1.0f);

			//애니메이션 수정

			Debug.Log ("플레이어를 공격");
			anim.SetBool ("isAttack", true);	//애니메이션 변경 - 공격, 몬스터의 공격 모션
			//this.gameObject.GetComponent<AudioSource>().PlayOneShot(expSnd);	//사라지는 효과음
			other.GetComponent<csPlayer> ().hltPnt = //플레이어 체력 감소
				other.GetComponent<csPlayer> ().hltPnt - GetComponent<csEnemy> ().atkPnt;
		}
	}
}
