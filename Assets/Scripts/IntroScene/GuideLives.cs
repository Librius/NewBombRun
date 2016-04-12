using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuideLives : MonoBehaviour {
	public Text hint;
	public Text hint2;
	public Image img;
	public float fadeSpeed = 5f;
	public bool entrance;
	public GameObject canvas;
	public float minSwipeDistX;
	private Vector2 startPos;


	private bool flag = false;

	void Awake(){
		hint = canvas.GetComponentsInChildren<Text> () [0];
		hint.color = Color.clear;
		hint2 = canvas.GetComponentsInChildren<Text> () [1];
		hint2.color = Color.clear;
	}

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {		
		ColorChange ();	
		ShowImage ();

	}

	void OnTriggerEnter(Collider col){
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
			hint2.color = Color.Lerp (hint2.color, Color.white, fadeSpeed * Time.deltaTime);
		}

		if (!entrance) {
			hint.color = Color.Lerp (hint.color, Color.clear, fadeSpeed * Time.deltaTime);
			hint2.color = Color.Lerp (hint2.color, Color.clear, fadeSpeed * Time.deltaTime);
		}
	}

	void ShowImage(){
		if (entrance)
			canvas.GetComponent<CanvasGroup>().alpha = 1f;
		else if(!entrance)
			canvas.GetComponent<CanvasGroup>().alpha = 0f;
	}

}
