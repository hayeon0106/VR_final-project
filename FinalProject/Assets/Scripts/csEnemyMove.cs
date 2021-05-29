using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class csEnemyMove : MonoBehaviour {
	//NavMeshAgent 컴포넌트를 이용하여 몬스터 이동
	NavMeshAgent agent;

	GameObject target;

	bool isMove = true;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
		target = GameObject.Find ("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (isMove) {
			movement ();
		}
	}

	private void movement(){
		if (agent.destination != target.transform.position) {
			agent.SetDestination (target.transform.position);
		} else {
			agent.SetDestination (transform.position);
		}
	}
}