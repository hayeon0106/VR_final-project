using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayer : MonoBehaviour {
	//캐릭터에 따른 hp, ap 지정
	public int hltPnt;
	public int atkPnt;

	public GameObject head;

	// Use this for initialization
	void Start () {
		//head = transform.parent.parent.gameObject;
		hltPnt = 50;
		atkPnt = 10;
	}
	
	// Update is called once per frame
	void Update () {
		GetComponent<CapsuleCollider> ().radius = head.GetComponent<csPlayerMove> ().enabled ? 0.08f : 0.2f;
		//Debug.Log ("Player hp: "+hltPnt);
		if (hltPnt <= 0) {
			Debug.Log ("플레이어 쓰러짐");
			//hp가 0이면 게임오버
		}
	}
}
