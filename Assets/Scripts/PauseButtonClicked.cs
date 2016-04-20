using UnityEngine;
using System.Collections;

public class PauseButtonClicked : MonoBehaviour {

	public Canvas canvas;
	private bool pause = false;
	// Use this for initialization
	void Start () {
		pause = false;
	}
	
	// Update is called once per frame
	void Update () {
//		Debug.Log (Time.time);
//		Debug.Log (pause);
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
		Time.timeScale = 1;
		Debug.Log (pause);
//		canvas.GetComponent<Animator> ().SetTrigger ("GameResume");
	}

	IEnumerator Wait ()
	{
		canvas.GetComponent<Animator> ().SetTrigger ("GamePause");
		yield return new WaitForSeconds(2.0f);
		pause = true;
		Debug.Log (pause);
	}
}
