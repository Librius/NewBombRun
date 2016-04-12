using UnityEngine;
using System.Collections;

public class background : MonoBehaviour {

	public AudioClip beep;
	public GUISkin menuSkin;
	public Rect menuArea;
	public Rect playButton;
	public Rect settingButton;
	public Rect quitButton;
	public Rect instructions;
	Rect menuAreaNormalized;
	string menuPage = "main";
	// Use this for initialization
	void Start () {

		menuAreaNormalized =
			new Rect(menuArea.x * Screen.width - (menuArea.width * 0.5f), menuArea.y * Screen.height - (menuArea.height * 0.5f), menuArea.width, menuArea.height);
	}
	void OnGUI()
	{
		GUI.skin = menuSkin;
		GUI.BeginGroup(menuAreaNormalized);
		if (menuPage == "main")
		{
			if (GUI.Button(new Rect(playButton), "Play"))
			{
				Debug.Log("1");
				//StartCoroutine("ButtonAction", "second");
				Application.LoadLevel("GameSelect");
				//menuPage = "select level";

			}
			if (GUI.Button(new Rect(settingButton), "Setting"))
			{
				Debug.Log("Have");
				GetComponent<AudioSource>().PlayOneShot(beep);
				menuPage = "setting";

			}
			if (GUI.Button(new Rect(quitButton), "Quit"))
			{
				Debug.Log("3");
				StartCoroutine("ButtonAction", "quit");
			}
		}
		else if(menuPage=="setting")
		{
			// game setting
			if(GUI.Button(new Rect(quitButton),"Back"))  
			{    
				menuPage = "main";  
			}  
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
