using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpawn : MonoBehaviour {
	//몬스터 스폰
	public GameObject spawnPoint;
	public GameObject enemys;
	public GameObject enemy;

	public GameObject[] itemPrefabs = new GameObject[2];
	GameObject potion;

	//스테이지에 따라 몬스터 수, 생성 몬스터 다르게
	int maxEnemy = 30;
	float createEnemyTime = 4.0f;
	float createItemTime = 6.0f;
	int randomN;

	// Use this for initialization
	void Start () {
		StartCoroutine (this.spawnMonster ());
		StartCoroutine (spawnItem ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnMonster(){
		while(true) {
			int enemyCount = (int)GameObject.FindGameObjectsWithTag ("enemy").Length;
			Debug.Log ("생성된 몬스터 수: "+enemyCount);

			if (enemyCount < maxEnemy) {
				//스폰 포인트로부터 일정 거리 떨어진 범위 안에 랜덤 스폰
				Vector3 pos = spawnPoint.transform.position + new Vector3 (Random.Range (-40, 40), 0, Random.Range (-40, 40));
				GameObject e = Instantiate (enemy, pos, Quaternion.identity);
				e.transform.parent = enemys.transform;

				yield return new WaitForSeconds(createEnemyTime);
			} else {
				yield break;
			}
		}
	}

	IEnumerator spawnItem(){
		while (true) {
			randomN = Random.Range (0, 2);

			//스폰 포인트로부터 일정 거리 떨어진 범위 안에 랜덤 스폰
			Vector3 pos = spawnPoint.transform.position + new Vector3 (Random.Range (-10, 10), 0, Random.Range (-10, 10));

			potion = Instantiate (itemPrefabs [randomN], pos, Quaternion.identity);

			yield return new WaitForSeconds (createItemTime);
		}
	}
}
