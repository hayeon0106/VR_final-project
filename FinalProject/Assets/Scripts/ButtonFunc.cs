using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonFunc : MonoBehaviour {

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

}
