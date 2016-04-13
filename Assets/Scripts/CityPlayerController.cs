using UnityEngine;
using System.Collections;

public class CityPlayerController : MonoBehaviour {

	public Sprite littleWhiteRabbit;
	public GameObject finalGoal;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider other)
	{
		Debug.Log ("CityTrigger");
		if (other.gameObject.CompareTag ("SteinMamba")) {
			other.gameObject.SetActive (false);
//			transform.GetChild (0).gameObject.SetActive (false);
//			transform.GetChild (1).gameObject.SetActive (true);

			GetComponent<PlayerController> ().hasKey = true;
			GetComponent<PlayerController> ().targetImage.sprite = littleWhiteRabbit;

			GameObject arrow = transform.FindChild ("arrow").gameObject;
			arrow.GetComponents<ArrowController> () [0].target = finalGoal;
		}
		if (other.gameObject.CompareTag ("LittleWhiteRabbit"))
		{
			Debug.Log ("Win");
		}

	}

	void OnCollisionEnter(Collision collision)
	{
		Debug.Log ("Collision");
	}
}