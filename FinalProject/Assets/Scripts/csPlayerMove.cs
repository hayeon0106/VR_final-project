using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csPlayerMove : MonoBehaviour {
	//시선의 움직임에 따라 플레이어를 이동시킴
	public GameObject head;
	public GameObject ARCam;
	public GameObject player;

	float currot;
	float prevrot;
	float deltrot;


	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
			movement ();
	}

	void movement(){
		head.transform.Translate (ARCam.transform.forward.x * 0.1f, 0.0f, ARCam.transform.forward.z * 0.1f);
		currot = ARCam.transform.eulerAngles.y;
		deltrot = currot - prevrot;
		prevrot = currot;
		if (deltrot < 0) {
			rotateByARCam (-45);
		} else if (deltrot > 0) {
			rotateByARCam (45);
		} else {
			rotateByARCam (0);
		}
	}

	private void rotateByARCam(int degree){
		player.transform.rotation = 
		Quaternion.Lerp (player.transform.rotation,
			Quaternion.Euler (player.transform.eulerAngles.x,
					degree, player.transform.eulerAngles.z),
			Time.deltaTime);
	}
}
