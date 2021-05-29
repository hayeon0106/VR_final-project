using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csSpawn : MonoBehaviour {
	//몬스터 스폰

	public GameObject spawnPoint;
	public GameObject enemy;

	//스테이지에 따라 몬스터 수, 생성 몬스터 다르게
	int maxEnemy = 30;
	float createTime = 5.0f;

	// Use this for initialization
	void Start () {
		StartCoroutine (this.spawnMonster ());
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	IEnumerator spawnMonster(){
		while(true) {
			int enemyCount = (int)GameObject.FindGameObjectsWithTag ("enemy").Length;
			//Debug.Log ("생성된 몬스터 수: "+enemyCount);
			//Debug.Log ("test: "+(enemyCount < maxEnemy));

			if (enemyCount < maxEnemy) {
				Vector3 pos = spawnPoint.transform.position + new Vector3 (Random.Range (-50, 50), 0, Random.Range (-50, 50));
				Instantiate (enemy, pos, Quaternion.identity);

				yield return new WaitForSeconds(createTime);
			} else {
				break;
			}
		}
	}
}
