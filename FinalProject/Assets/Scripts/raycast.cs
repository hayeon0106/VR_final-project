using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour {
	Animator anim;

	public Image reticle;
	float timeElapsed;

	int hltPnt = 0;
	int atkPnt = 0;

	// Use this for initialization
	void Start () {
		hltPnt = 1000;
		atkPnt = 50;
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 100;
		Debug.DrawRay (transform.position, forward, Color.green);
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {
				//레이캐스트가 적을 만났을 때 - 공격
				//효과
				//공격하는 걸 발사
				anim.SetBool("isAttack", true);	//애니메이션 변경

				timeElapsed = timeElapsed + Time.deltaTime;
				if (timeElapsed >= 3) {
					Debug.Log("플레이어 공격");
				//	hit.transform.GetComponent<csEnemy> ().hltPnt =
				//		hit.transform.GetComponent<csEnemy> ().hltPnt - atkPnt;
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
