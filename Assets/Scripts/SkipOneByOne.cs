using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SkipOneByOne : MonoBehaviour {

	public bool add = true;
	private Text textObj;

	void Start() {
	}

	void Update(){
		if (add) {
			StartCoroutine(Example());
		}
		add = false;
	}

	IEnumerator Example() {
		textObj = GameObject.Find("Text").GetComponent<Text>();
		yield return new WaitForSeconds(0.2f);
		textObj.text += ">";
		yield return new WaitForSeconds(0.2f);
		textObj.text += ">";
		yield return new WaitForSeconds(0.2f);
		textObj.text += ">";
		yield return new WaitForSeconds(1.0f);
		textObj.text = "Skip ";
		add = true;
	}
}
