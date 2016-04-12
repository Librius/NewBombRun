using UnityEngine;
using System.Collections;

public class EasyMenuScript : MonoBehaviour {

	private GameObject BG;
	public Sprite Background;
	public Color BackgroundColor = Color.white;

	private GameObject Lines;
	public bool LinesON = true;
	public Sprite LinesSprite;
	public Color LinesColor = new Color(0.1F, 0.15F, 0.4F, 0.2F);
	public bool FastRotation = false;
	private int rotateLinesSpeed;
	public string LinesPosition = "center";

	private GameObject logo;
	public bool LogoOn = false;
	public Sprite Logo;

	public bool FallingElementsON = true;
	private GameObject fallingEl;
	public Sprite FallingElement;
	public Color FallingElementColor = Color.white;
	private GameObject fallingEl2;
	private GameObject fallingEl3;
	private GameObject fallingEl4;



	void Start () {

		if (LinesPosition!= "top" && LinesPosition!= "center" && LinesPosition!= "bottom"){LinesPosition = "center";}
		BG = GameObject.Find ("BackGround");
		Lines = GameObject.Find ("Lines");

		fallingEl = GameObject.Find ("FallingEl");
		fallingEl2 = GameObject.Find ("FallingEl2");
		fallingEl3 = GameObject.Find ("FallingEl3");
		fallingEl4 = GameObject.Find ("FallingEl4");

		logo = GameObject.Find ("Logo");

	}

	void Update () {

		BG.GetComponent<SpriteRenderer>().sprite = Background;
		BG.GetComponent<SpriteRenderer>().color = BackgroundColor;

		Lines.GetComponent<SpriteRenderer>().sprite = LinesSprite;
		Lines.GetComponent<SpriteRenderer>().color = LinesColor;
		if (!FastRotation){rotateLinesSpeed=3;}else{rotateLinesSpeed=10;}
		Lines.GetComponent<SpriteRenderer>().enabled=LinesON;
		Lines.transform.RotateAround(Vector3.zero, Vector3.back, rotateLinesSpeed * Time.deltaTime);
		if (LinesPosition!= "top" && LinesPosition!= "center" && LinesPosition!= "bottom"){LinesPosition = "center";}
		if (LinesPosition == "top") {Lines.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height,9.99f));}
		if (LinesPosition == "center") {Lines.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/2,9.99f));}
		if (LinesPosition == "bottom") {Lines.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,0,9.99f));}

		logo.GetComponent<SpriteRenderer> ().sprite = Logo;
		logo.transform.position = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width/2,Screen.height/1.2f,9.98f));
		logo.GetComponent<SpriteRenderer> ().enabled = LogoOn;

		fallingEl.GetComponent<SpriteRenderer>().sprite = FallingElement;
		fallingEl.GetComponent<SpriteRenderer> ().enabled = FallingElementsON;
		fallingEl.GetComponent<SpriteRenderer>().color = FallingElementColor;
		fallingEl2.GetComponent<SpriteRenderer>().sprite = FallingElement;
		fallingEl2.GetComponent<SpriteRenderer> ().enabled = FallingElementsON;
		fallingEl2.GetComponent<SpriteRenderer>().color = FallingElementColor;
		fallingEl3.GetComponent<SpriteRenderer>().sprite = FallingElement;
		fallingEl3.GetComponent<SpriteRenderer> ().enabled = FallingElementsON;
		fallingEl3.GetComponent<SpriteRenderer>().color = FallingElementColor;
		fallingEl4.GetComponent<SpriteRenderer>().sprite = FallingElement;
		fallingEl4.GetComponent<SpriteRenderer> ().enabled = FallingElementsON;
		fallingEl4.GetComponent<SpriteRenderer>().color = FallingElementColor;




	}
}
