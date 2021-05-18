using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scSpawn : MonoBehaviour {

	public GameObject player;
	public GameObject spawnPoint;
	public GameObject enemy;

	int numOfEnemy = 30;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (numOfEnemy == 0)
			StopCoroutine (spawnMonster ());
		
		if (!player.GetComponent<scPlayer> ().enabled) {
			//몬스터 스폰
			StartCoroutine (spawnMonster ());
		}
	}

	IEnumerator spawnMonster(){
		for(int i=0; i<numOfEnemy; i++) {
			yield return new WaitForSeconds (15.0f);

			Vector3 pos = spawnPoint.transform.position + new Vector3 (Random.Range (-50, 50), 0, Random.Range (-50, 50));
			Instantiate (enemy, pos, Quaternion.identity);
			Debug.Log ("몬스터 생성: "+numOfEnemy);
		}
	}
}
