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
}
