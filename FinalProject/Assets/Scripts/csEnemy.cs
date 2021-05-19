using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csEnemy : MonoBehaviour {
	public GameObject player;
	public GameObject enemy;

	float speed = 0.5f;
	int hltPnt = 0;
	int atkPnt = 0;

	// Use this for initialization
	void Start () {
		hltPnt = 200;
		atkPnt = 30;
	}
	
	// Update is called once per frame
	void Update () {
		//movement ();
	}

	void OnTriggerEnter(Collider other){
		StartCoroutine (crash ());
	}

	IEnumerator crash(){
		Destroy (this.gameObject);
		yield return new WaitForSeconds (1.0f);
	}

	void movement(){
		this.transform.LookAt (player.transform);
		Vector3 v = player.transform.position;
		v.Normalize ();
		Debug.Log (v);

		this.transform.position = v * speed * Time.deltaTime;
	}
}
