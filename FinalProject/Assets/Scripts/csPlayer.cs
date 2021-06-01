using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class csPlayer : MonoBehaviour {
	//캐릭터에 따른 hp, ap 지정
	public int hltPnt;
	public int atkPnt;
	float MaxHltPnt;

	public GameObject head;
	public GameObject gameOver;

	public Image reticle;

	// Use this for initialization
	void Start () {
		hltPnt = 10;
		atkPnt = 10;
		MaxHltPnt = (float)hltPnt;
	}
	
	// Update is called once per frame
	void Update () {
		
		//플레이어가 움직일 땐 콜리더를 0.08f로 움직이지 않을 때는 0.2f로 변경
		GetComponent<CapsuleCollider> ().radius = head.GetComponent<csPlayerMove> ().enabled ? 0.08f : 0.2f;
		//Debug.Log ("Player hp: "+hltPnt);
		reticle.fillAmount = hltPnt/MaxHltPnt;
		if (hltPnt <= 0) {	//hp가 0이면 게임오버
			Debug.Log ("플레이어 쓰러짐");
			gameOver.SetActive (true);
		}
	}
}
