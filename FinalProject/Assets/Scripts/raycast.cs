using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;

public class raycast : MonoBehaviour {
	public GameObject attack;
	public RaycastHit hit;

	public Image reticle;
	int power;
	float timeElapsed;
	float time;
	// Use this for initialization
	void Start () {
		time = 2.0f;
		power = 50;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 1000;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {		//hit이 적이면
				timeElapsed = timeElapsed + Time.deltaTime;
				if (timeElapsed >= time) {		//일정시간 동안 맞췄을 때 공격
					//공격 효과
					//공격하는 걸 발사
					Debug.Log ("플레이어의 공격: attack 생성");
					//this.gameObject.GetComponent<AudioSource>().PlayOneShot(expSnd);	//사라지는 효과음
					GameObject myAttack = Instantiate (attack, transform.position, Quaternion.identity);
					myAttack.SendMessage ("setTarget",hit.transform.gameObject);
					timeElapsed = 0.0f;
					reticle.fillAmount = 0;
				}
				timeElapsed = timeElapsed + Time.deltaTime;
				reticle.fillAmount = timeElapsed / time;
			}
			//if (timeElapsed >= time) {		//버튼 
			//	timeElapsed = time;
			//}

		}
		else {
			if (timeElapsed <= 0.0f) {
				timeElapsed = 0.0f;
			}
			timeElapsed = timeElapsed - Time.deltaTime;
			reticle.fillAmount = timeElapsed / time;	//retucle 줄어듬
		}
	}
}