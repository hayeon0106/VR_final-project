using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour {
	Animator anim;

	public GameObject attack;

	public Image reticle;
	int power;
	float timeElapsed;
	float time;
	// Use this for initialization
	void Start () {
		//anim = transform.GetComponent<Animator> ();
		time = 2.0f;
		power = 50;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 100;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {		//hit이 적이면
				timeElapsed = timeElapsed + Time.deltaTime;
				if (timeElapsed >= time) {		//일정시간 동안 맞췄을 때 공격
					Debug.Log("플레이어의 공격 모션");

					//anim.SetBool("isAttack", true);	//애니메이션 변경, 플레이어의 공격 모션
					//공격 효과
					//공격하는 걸 발사
					//spawnAttack();
					//StartCoroutine(spawnAttack());

				}
				timeElapsed = timeElapsed + Time.deltaTime;
				reticle.fillAmount = timeElapsed / time;
				Debug.Log ("hit");
			}
			//if (timeElapsed >= time) {		//버튼 
			//	timeElapsed = time;
			//}

		}
		else {		//retucle 줄어듬
			if (timeElapsed <= 0.0f) {
				timeElapsed = 0.0f;
			}
			timeElapsed = timeElapsed - Time.deltaTime;
			reticle.fillAmount = timeElapsed / time;
		}
	}

	IEnumerator spawnAttack(){
		Debug.Log ("플레이어의 공격");
		GameObject myAttack = Instantiate (attack, transform.position, Quaternion.identity);
		myAttack.GetComponent<Rigidbody>().AddForce (transform.forward * power);
		return null;
	}
}
