using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class raycast : MonoBehaviour {

	public Image reticle;
	float timeElapsed;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		RaycastHit hit;
		Vector3 forward = transform.TransformDirection (Vector3.forward) * 1000;
		Debug.DrawRay (transform.position, forward, Color.green);
		if (Physics.Raycast (transform.position, forward, out hit)) {
			if (hit.collider.tag == "enemy") {
				//레이캐스트가 적을 만났을 때 - 공격
			}
			if (timeElapsed >= 3.0f) {		//버튼 
				timeElapsed = 3.0f;
				/*
				if (hit.collider.tag == "ship01") {
					PlayerPrefs.SetInt ("ship", 1);
					Debug.Log ("ship01");
				} else if (hit.collider.tag == "ship02") {
					PlayerPrefs.SetInt ("ship", 2);
					Debug.Log ("ship02");
				} else if (hit.collider.tag == "ship03") {
					PlayerPrefs.SetInt ("ship", 3);
					Debug.Log ("ship03");
				} else if (hit.collider.tag == "ship04") {
					PlayerPrefs.SetInt ("ship", 4);
					Debug.Log ("ship04");
				} else if (hit.collider.tag == "ship05") {
					PlayerPrefs.SetInt ("ship", 5);
					Debug.Log ("ship05");
				} else {
				*/
					//hit.transform.GetComponent<Button> ().onClick.Invoke ();
				//}
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
