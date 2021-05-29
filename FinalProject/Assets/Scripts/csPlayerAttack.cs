using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class csPlayerAttack : MonoBehaviour {
	NavMeshAgent agent;

	GameObject target;

	// Use this for initialization
	void Start () {
		agent = GetComponent<NavMeshAgent> ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log ("플레이어 공격 대상: "+target);

		Debug.Log (agent.destination != target.transform.position);
		if (agent.destination != target.transform.position) {
			agent.SetDestination (target.transform.position);
		} else {
			agent.SetDestination (transform.position);
		}
	}

	void OnTriggerEnter(Collider other){
		//몬스터 공격 받음
		Debug.Log("attack trigger: "+other);
		if (other.transform.tag == "enemey") {
			Debug.Log ("몬스터를 공격");
			GetComponent<csEnemy>().hltPnt = 			//몬스터 채력 감소
				GetComponent<csEnemy>().hltPnt - other.GetComponent<csPlayer> ().atkPnt;
			StartCoroutine (dead ());
		}
	}

	IEnumerator dead(){
		//this.gameObject.GetComponent<MeshRenderer> ().enabled = false;	//사라지는 효과
		//explosion.SetActive(true);

		Destroy (this.gameObject);
		Debug.Log ("공격하고 사라짐");
		return null;
	}

	void setTarget(GameObject t){
		target = t;
	}
}
