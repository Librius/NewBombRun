using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuideTilt : MonoBehaviour
{
	public Text hint;
	public float fadeSpeed = 5f;
	public bool entrance;
	public GameObject canvas;

	private bool flag = false;

	void Awake ()
	{
//		hint = canvas.GetComponentInChildren<Text> ();
//		hint.color = Color.clear;
	}

	// Use this for initialization
	void Start ()
	{

	}

	// Update is called once per frame
	void Update ()
	{
		ShowImage ();
		//ColorChange ();	

//		if (Input.acceleration.x != 0) {
//			entrance = false;
//		}
	}

	void OnTriggerEnter (Collider col)
	{
		if (!flag) {
			if (col.gameObject.name == "rabbit")
				entrance = true;	
			flag = true;
		}
	}

	void OnTriggerExit (Collider col)
	{
		if (col.gameObject.name == "rabbit")
			entrance = false;			
	}

	//	void ColorChange ()
	//	{
	//		if (entrance) {
	//			hint.color = Color.Lerp (hint.color, Color.white, fadeSpeed * Time.deltaTime);
	//		}
	//
	//		if (!entrance) {
	//			hint.color = Color.Lerp (hint.color, Color.clear, fadeSpeed * Time.deltaTime);
	//		}
	//	}

	void ShowImage ()
	{
		if (entrance)
			canvas.GetComponent<CanvasGroup> ().alpha = 1f;
		else if (!entrance)
			canvas.GetComponent<CanvasGroup> ().alpha = 0f;
	}

}
