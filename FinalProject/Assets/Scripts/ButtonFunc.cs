using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonFunc : MonoBehaviour {

	public void playGame(){
		SceneManager.LoadScene("main");
	}

	public void vrmode(){
		PlayerPrefs.SetInt ("mode", 0);
		PlayerPrefs.Save ();

		Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.VIEWER_VR);
	}

	public void hhmode(){
		PlayerPrefs.SetInt ("mode", 1);
		PlayerPrefs.Save ();
		Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.HANDHELD_VR);
	}

	public void selectShip(){
		SceneManager.LoadScene ("select");
	}
}
