using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour {
	//스폰된 후 플레이어를 향해 이동
	//플레이어 근처에 가면 공격
	//체력이 다 달면 사라짐
	public GameObject player;
	public GameObject enemy;

	Animator anim;

	float speed = 0.5f;
	public int hltPnt;
	public int atkPnt;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();

		//캐릭터에 따라 hp와 ap를 다르게
		hltPnt = 200;
		atkPnt = 30;
	}
	
	// Update is called once per frame
	void Update () {
		//movement ();
	}

	void OnTriggerEnter(Collider other){
		//플레이어에게 닿았을 때
		if(other.transform.tag == "Player"){
			anim.SetBool ("isAttack", true);	//애니메이션 변경 - 공격
			player.GetComponent<csPlayer> ().hltPnt = 
				player.GetComponent<csPlayer> ().hltPnt - atkPnt;
				
		}

		//부딪힌 것이 공격받는 것이라면 hp 감소
		if (other.transform.tag == "attack") {
			
			hltPnt = hltPnt - other.GetComponent<csPlayer> ().atkPnt;
		}

		//hp가 0이면 오브젝트 제거
		if (hltPnt == 0) {
			StartCoroutine (dead ());
		}
	}

	void movement(){	//제일 문제
		this.transform.LookAt (player.transform);
		Vector3 v = player.transform.position;
		v.Normalize ();
		Debug.Log (v);

		this.transform.position = v * speed * Time.deltaTime;
	}

	IEnumerator dead(){
		//this.gameObject.GetComponent<MeshRenderer> ().enabled = false;	//사라지는 효과
		//this.gameObject.GetComponent<AudioSource>().PlayOneShot(expSnd);	//사라지는 효과음
		//explosion.SetActive(true);

		anim.SetBool("isDead", true);	//애니메이션 변경
		yield return new WaitForSeconds(1.0f);
		Destroy (this.gameObject);
		Debug.Log ("몬스터 쓰러짐");
	}
}
