using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class GetToolHint : MonoBehaviour {

	public Image RocketHint;
	public Image RocketDestination;
	private Image rh;

	public Image HealthHint;
	public Image HealthDestination;
	private Image hh;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (PlayerController.RocketHint == true) 
		{
			rh = Instantiate (RocketHint) as Image;
			rh.transform.SetParent (transform);
			rh.transform.localPosition = new Vector3 (0, 0, 0);
			PlayerController.RocketHint = false;
		}
		if (rh != null) 
		{
			rh.transform.position = Vector3.MoveTowards (rh.transform.position, RocketDestination.transform.position, 5);
		}
		if (rh != null && rh.transform.position.Equals (RocketDestination.transform.position)) 
		{
			PlayerController.hasRocket = true;
			PlayerController.RocketInStock = PlayerController.ROCKET_MAX;
			rh.gameObject.SetActive (false);
			rh = null;
		}

		if (PlayerController.HealthHint == true)
		{
			hh = Instantiate (HealthHint) as Image;
			hh.transform.SetParent (transform);
			hh.transform.localPosition = new Vector3 (0, 0, 0);
			PlayerController.HealthHint = false;
		}
		if (hh != null) 
		{
			hh.transform.position = Vector3.MoveTowards (hh.transform.position, HealthDestination.transform.position, 5);
		}
		if (hh != null && hh.transform.position.Equals (HealthDestination.transform.position)) 
		{
			PlayerController.currentHealth = PlayerController.HEALTH_MAX;
			//PlayerController.healthBar.currentValue = PlayerController.currentHealth;
			hh.gameObject.SetActive(false);
			hh = null;
		}
	}
}
