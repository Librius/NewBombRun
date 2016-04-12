using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class SelectBtn : MonoBehaviour {

	public int lvl;
	public Texture lvl1;
	public Texture lvl2;
	public Texture lvl3;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	public void RightBtn(Component rawImage)
	{
		lvl = lvl + 1;
		if (lvl <= 3) {
			Debug.Log (lvl);
			if (lvl == 1) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl1;
			}
			if (lvl == 2) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl2;
			}
			if (lvl == 3) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl3;
			}
		}else {
			lvl = lvl - 1;
		}
	}

	public void LftBtn(Component rawImage)
	{
		lvl = lvl - 1;
		if (lvl >= 1) {
			//loadingImage.SetActive (true);
			Debug.Log (lvl);
			if (lvl == 1) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl1;
			}
			if (lvl == 2) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl2;
			}
			if (lvl == 3) {
				rawImage.gameObject.GetComponent<RawImage> ().texture = lvl3;
			}
			Debug.Log (rawImage.gameObject.GetComponent<RawImage> ().texture.name);
		} else {
			lvl = lvl + 1;
		}
	}

	public void GameSelect()
	{
//		Debug.Log (lvl);
		if (lvl == 1) {
			Application.LoadLevel ("IntroScene");
		}
		if (lvl == 2) {
			Application.LoadLevel ("Forest");
		}
		if (lvl == 3) {
			Application.LoadLevel ("City");
		}
	}
}
