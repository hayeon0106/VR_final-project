using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class csPlay : MonoBehaviour {
	public GameObject player;
	public GameObject enemys;
	public GameObject[] platforms;

	int[] enemyByStage = { 5, 10, 15 };
	int countStage = 0;
	int countFallEnemy = 0;
	int originAtkPnt;
	int originhltPnt;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (countStage == enemyByStage.Length) {
			//씬 전환
			countStage--;
			finishStage();
			Debug.Log ("게임 종료");
			SceneManager.LoadScene("finish");	//게임 종료 화면으로 전환
		} else {
			if (countFallEnemy == enemyByStage [countStage]) {	//스테이지 끝
				//플레이어 움직이고 맵에 스폰된 몬스터들 제거
				finishStage();
				countStage++;
				Debug.Log ("countStage: " + countStage);
				GetComponent<csPlayerMove> ().enabled = true;	//플레이어 움직이는 스크립트 활성화
			}
		}
	}

	void increaseCountFallEnemy(){
		countFallEnemy++;
		Debug.Log ("쓰러진 몬스터 수: " + countFallEnemy);
	}

	public void playerHeal(){
		originhltPnt = player.GetComponent<csPlayer> ().MaxHltPnt;
		int heal = player.GetComponent<csPlayer> ().hltPnt + 15;
		if (originhltPnt >= heal) {
			player.GetComponent<csPlayer> ().hltPnt += 15;
			Debug.Log ("힐");
		}
	}

	public void increaseAtkPnt(){
		originAtkPnt = player.GetComponent<csPlayer> ().atkPnt;
		int increaseAtkPnt = originAtkPnt + 10;
		Debug.Log ("원래 공격력: " + originAtkPnt + ", 증가한 공격력: " + increaseAtkPnt);
		if ((player.GetComponent<csPlayer> ().MaxAtkPnt+20) >= increaseAtkPnt) {
			player.GetComponent<csPlayer> ().atkPnt = increaseAtkPnt;
			Debug.Log ("공격력 상승");
			StartCoroutine ("resetAtkPnt");
		}
		Debug.Log ("공격력: " + player.GetComponent<csPlayer> ().atkPnt);
	}

	void doStage(){
		Debug.Log ("스테이지 시작");
		GetComponent<csPlayerMove> ().enabled = false;
		GetComponent<csSpawn> ().enabled = true;
	}

	void finishStage(){
		Debug.Log ("한 스테이지 끝");
		countFallEnemy = 0;
		platforms [countStage].GetComponent<csPlatform> ().enabled = false;	//플랫폼 스크립트 비활성화
		GetComponent<csSpawn> ().enabled = false;		//적 스폰 비활성화

		Transform[] children = enemys.GetComponentsInChildren <Transform> ();

		foreach (Transform iterator in children) {
			if (iterator.gameObject != enemys) {
				//Debug.Log (iterator + " 제거");
				Destroy (iterator.gameObject);
			}
		}
	}

	IEnumerator resetAtkPnt(){
		yield return new WaitForSeconds (30.0f);
		player.GetComponent<csPlayer> ().atkPnt = originAtkPnt;
		Debug.Log ("공격력 원래대로");
	}
}
