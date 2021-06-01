using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class csMode : MonoBehaviour {

	// Use this for initialization
	IEnumerator Start () {
		yield return new WaitForSeconds (0.2f);

		if (PlayerPrefs.GetInt ("mode") == 0) {
			Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.VIEWER_VR);
		} else if (PlayerPrefs.GetInt ("mode") == 1) {
			Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.HANDHELD_VR);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
