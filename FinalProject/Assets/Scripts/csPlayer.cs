using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour {
	Animator anim;

	//캐릭터에 따른 hp, ap 지정
	public int hltPnt;
	public int atkPnt;

	GameObject head;

	// Use this for initialization
	void Start () {
		hltPnt = 50;
		atkPnt = 10;
	}
	
	// Update is called once per frame
	void Update () {
		//Debug.Log ("Player hp: "+hltPnt);
		if (hltPnt <= 0) {
			Debug.Log ("플레이어 쓰러짐");
			//hp가 0이면 게임오버
		}
	}
}
