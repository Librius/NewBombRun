using UnityEngine;
using System.Collections;

public class PauseButtonClicked : MonoBehaviour {

	public Canvas canvas;
	private bool pause = false;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if (pause) {
			Time.timeScale = 0;
			pause = false;
		}
	}

	public void pausedClicked(){
		Debug.Log (pause);
		StartCoroutine (Wait ());
	}

	public void ResumeClicked(){
		Debug.Log ("Resume Clicked");
		canvas.GetComponent<Animator> ().SetTrigger ("GameResume");
	}

	IEnumerator Wait ()
	{
		canvas.GetComponent<Animator> ().SetTrigger ("GamePause");
		yield return new WaitForSeconds(2.0f);
		pause = true;
		Debug.Log (pause);
	}
}
