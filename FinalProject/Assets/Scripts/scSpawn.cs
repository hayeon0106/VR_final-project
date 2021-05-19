using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scSpawn : MonoBehaviour {

	public GameObject player;
	public GameObject spawnPoint;
	public GameObject enemy;

	bool stopSpawn = false;
	int maxEnemy = 30;
	float createTime = 5.0f;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (!player.GetComponent<scPlayer> ().enabled) {
			//몬스터 스폰
			StartCoroutine (this.spawnMonster ());
		}
	}

	IEnumerator spawnMonster(){
		while(true) {		//스테이지 종료 조건
			int enemyCount = (int)GameObject.FindGameObjectsWithTag ("enemy").Length;
			Debug.Log ("생성된 몬스터 수: "+enemyCount);
			Debug.Log (enemyCount == maxEnemy);

			if (enemyCount < maxEnemy) {
				Vector3 pos = spawnPoint.transform.position + new Vector3 (Random.Range (-50, 50), 0, Random.Range (-50, 50));
				Instantiate (enemy, pos, Quaternion.identity);

				yield return new WaitForSeconds(createTime);
				//시간을 기다려주지 않음
			} else {
				yield return null;
			}
		}
	}
}
