using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour {
	//스폰된 후 플레이어를 향해 이동
	//체력이 다 달면 사라짐

	Animator anim;
	GameObject head;

	public int hltPnt;
	public int atkPnt;
	int randomN;

	float timeElapsed, time;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
		head = GameObject.FindGameObjectWithTag ("head");

		//캐릭터에 따라 hp와 ap를 다르게
		hltPnt = 15;
		atkPnt = 2;
		time = 1.5f;
	}
	
	// Update is called once per frame
	void Update () {
		//hp가 0이면 오브젝트 제거
		if (hltPnt <= 0) {
			//this.gameObject.GetComponent<AudioSource>().PlayOneShot(expSnd);	//사라지는 효과음
			//explosion.SetActive(true);

			timeElapsed += Time.deltaTime;
			anim.SetBool("isDead", true);	//애니메이션 변경
			if(timeElapsed>time) {
				gameObject.SetActive(false);	//적 비활성화
				Debug.Log ("몬스터 쓰러짐");
				head.SendMessage ("increaseCountFallEnemy");
				
				timeElapsed = 0.0f;
			}

		}
	}
}
