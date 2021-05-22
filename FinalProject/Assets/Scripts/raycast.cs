using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour {
	Animator anim;

	public GameObject player;

	public Image reticle;
	float timeElapsed;

	// Use this for initialization
	void Start () {
		anim = transform.GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 100;
		Debug.DrawRay (transform.position, forward, Color.green);
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {	//hit이 적이면
				timeElapsed = timeElapsed + Time.deltaTime;
				if (timeElapsed >= 3) {		//일정시간 동안 맞췄을 때 공격
					Debug.Log("플레이어 공격");

					anim.SetBool("isAttack", true);	//애니메이션 변경
					//공격 효과
					//공격하는 걸 발사
				}
			}
			if (timeElapsed >= 3.0f) {		//버튼 
				timeElapsed = 3.0f;

			}
			timeElapsed = timeElapsed + Time.deltaTime;
			reticle.fillAmount = timeElapsed / 3.0f;
			Debug.Log ("hit");
		} else {
			if (timeElapsed <= 0.0f) {
				timeElapsed = 0.0f;
			}
			timeElapsed = timeElapsed - Time.deltaTime;
			reticle.fillAmount = timeElapsed / 3.0f;
		}
	}
}
