using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuideShoot : MonoBehaviour {
	public Text hint;
	public Image img;
	public float fadeSpeed = 5f;
	public bool entrance;
	public GameObject canvas;
	public float minSwipeDistX;
	private Vector2 startPos;


	static bool flag = false;

	void Awake(){
		hint = canvas.GetComponentInChildren<Text> ();
		hint.color = Color.clear;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {		
		ColorChange ();	
		ShowImage ();

//		if (Input.acceleration.x != 0) {
//			entrance = false;
//		}
//
		if (Input.GetButtonDown ("Fire1")) {
			entrance = false;
		}

	}

	void OnTriggerStay(Collider col){
		if(!flag)
		{
			if (col.gameObject.name == "rabbit")
				entrance = true;	
			flag = true;
		}
	}

	void OnTriggerExit(Collider col){
		if (col.gameObject.name == "rabbit")
			entrance = false;			
	}

	void ColorChange(){
		if (entrance) {
			hint.color = Color.Lerp (hint.color, Color.white, fadeSpeed * Time.deltaTime);
		}

		if (!entrance) {
			hint.color = Color.Lerp (hint.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
	}

	void ShowImage(){
		if (entrance)
			canvas.GetComponent<CanvasGroup>().alpha = 1f;
		else if(!entrance)
			canvas.GetComponent<CanvasGroup>().alpha = 0f;
		}


}
