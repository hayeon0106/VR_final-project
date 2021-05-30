using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour {
	public GameObject attackObj;
	public RaycastHit hit;

	public Transform dir;
	Vector3 _dir;

	public Image reticle;
	int speed;
	float timeElapsed, time;

	// Use this for initialization
	void Start () {
		time = 2.0f;
		speed = 200;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 1000;
		Debug.DrawRay (transform.position, forward, Color.green);

		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {		//hit이 적이면
				timeElapsed = timeElapsed + Time.deltaTime;
				if (timeElapsed >= time) {		//일정시간 동안 맞췄을 때 공격
					Debug.Log ("플레이어의 공격: attackObj 생성");
					//this.gameObject.GetComponent<AudioSource>().PlayOneShot(expSnd);	//발사 효과음
					attack();	//공격 오브젝트 생성, 발사

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

	void attack(){
		//방향을 계산
		Vector3 _dir = new Vector3 (dir.position.x - transform.position.x,
									dir.transform.position.y - transform.position.y,
									dir.position.z - transform.position.z).normalized;
		GameObject myAttack = Instantiate (attackObj, dir.transform.position, Quaternion.identity);
		//발사 방향 * 속도 * 시간
		Vector3 v = _dir * speed * Time.deltaTime;

		//발사
		myAttack.GetComponent<Rigidbody>().velocity = v;
	}
}