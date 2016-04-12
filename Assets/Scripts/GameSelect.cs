using UnityEngine;
using System.Collections;

public class GameSelect : MonoBehaviour {

	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect introLvl;
	public Rect Lvl1;
	public Rect Lvl2;
	public Rect quitButton;
	//public Rect playButton;
	public Rect t1;
	public Rect t2;
	public Rect t3;
	int lvl = 0;
	public Texture texture0;
	public Texture texture1;
	public Texture texture2;
	Rect menuAreaNormalized;
	string menuPage = "select";
	// Use this for initialization
	void Start () {

		menuAreaNormalized =
			new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
	}
	void OnGUI()
	{
		GUI.skin = menuSkin;
		GUI.BeginGroup(menuAreaNormalized);
		if (menuPage == "select")
		{
			GUI.Box (new Rect (introLvl), texture0);
				GUI.Label (new Rect (t1), "Teaching Level");
			GUI.Box (new Rect (Lvl1), texture1);
				GUI.Label (new Rect (t2), "Mushroom Land");

			GUI.Box (new Rect (Lvl2), texture2);
				GUI.Label (new Rect (t3), "Abandon City");


			if(GUI.Button(new Rect(quitButton),"Back"))  
			{    
				Application.LoadLevel("GameScene");
			} 
//			if(GUI.Button(new Rect(playButton),"Play"))  
//			{    
//				if (lvl == 0) {
//					Application.LoadLevel ("IntroScene");
//				}
//			} 
		}
		else if(menuPage=="back")
		{
			// game setting
		}
		GUI.EndGroup();
	}

	IEnumerator ButtonAction(string levelName)
	{
		GetComponent<AudioSource>().PlayOneShot(beep);
		yield return new WaitForSeconds(0.35f);

		if(levelName!="quit")
		{
			Application.LoadLevel(levelName);
		}
		else
		{
			Application.Quit();
			Debug.Log("Have Quit");
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
