using UnityEngine;
using System.Collections;

public class WaitForSecondsExample : MonoBehaviour {

	public bool show = false;

	void Start() {
//		StartCoroutine(Example());
	}

	void Update(){
		if (show) {
			StartCoroutine(Example());
		}
		show = false;
	}

	IEnumerator Example() {
//		print(Time.time);
		MeshRenderer[] render = gameObject.GetComponentsInChildren<MeshRenderer> ();
//		for(int i=0; i<render.Length; i++)
//			print (render[i]);
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = true;
		render[3].enabled = true;
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = false;
		render[3].enabled = false;
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = true;
		render[3].enabled = true;
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = false;
		render[3].enabled = false;
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = true;
		render[3].enabled = true;
		yield return new WaitForSeconds(0.5f);
		render[2].enabled = false;
		render[3].enabled = false;
//		print(Time.time);
	}
}
