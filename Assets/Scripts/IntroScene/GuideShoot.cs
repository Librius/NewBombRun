using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GuideShoot : MonoBehaviour
{
	public Text hint;
	public Image img;
	public float fadeSpeed = 5f;
	public bool entrance;
	public GameObject canvas;
	public float minSwipeDistY;
	private Vector2 startPos;


	static bool flag = false;

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
//		ColorChange ();	
		ShowImage ();
		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];

			switch (touch.phase) {

			case TouchPhase.Began:

				startPos = touch.position;
				break;

			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				float swipeDistHorizontal = (new Vector3 (0, touch.position.x, 0) - new Vector3 (0, startPos.x, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {
					float swipeValueVertical = Mathf.Sign (touch.position.y - startPos.y);
					if (swipeValueVertical > 0) {
						entrance = false;
					}
				} 
				break;
			}
		}
	}

	void OnTriggerStay (Collider col)
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
