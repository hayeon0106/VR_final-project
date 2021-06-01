using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour {
	public Image img;
	public Text text;

	public void playGame(){
		Debug.Log ("게임 시작");
		SceneManager.LoadScene("stage1");
	}

	public void goTitle(){
		Debug.Log ("타이틀로");
		SceneManager.LoadScene ("start");
	}

	public void tutorial(){
		Debug.Log ("게임 방법");
		SceneManager.LoadScene ("tutorial");
	}

	public void options(){
		Debug.Log ("설정");
		SceneManager.LoadScene ("options");
	}

	public void exit(){
		Debug.Log ("게임 종료");
		Application.Quit ();
	}

	public void vrmode(){
		Debug.Log ("VR 모드");
		//img.enabled = true;
		//text.text = "VR 모드로 선택되었습니다.";
		PlayerPrefs.SetInt ("mode", 0);
		PlayerPrefs.Save ();

		Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.VIEWER_VR);
	}

	public void hhmode(){
		Debug.Log ("핸들 모드");
		//img.enabled = true;
		//text.text = "Handheld 모드로 선택되었습니다.";
		PlayerPrefs.SetInt ("mode", 1);
		PlayerPrefs.Save ();
		Vuforia.MixedRealityController.Instance.SetMode (Vuforia.MixedRealityController.Mode.HANDHELD_VR);
	}

	public void selectShip(){
		SceneManager.LoadScene ("select");
	}
}
