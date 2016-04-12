using UnityEngine;
using System.Collections;

public class Rocket : MonoBehaviour 
{
	public float range_distance;
	public float range_angle_cos;
	public float speed;
	public GameObject explosion;
	private Rigidbody rb;

	private int destroy_time = 200;
	private int shot_time = 0;
	private int hit_time = 0;
	private bool hit = false;

	private GameObject first_enemy = null;//the first enemy within bomb's range

	private AudioSource bombSound;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
//		rb.rotation = Quaternion.identity;
		rb.velocity = transform.forward * speed;
		bombSound = GetComponent<AudioSource> ();
		//find the first enemy within bomb's range
		GameObject[] all_enemies = GameObject.FindGameObjectsWithTag("Enermies");
		foreach (GameObject enemy in all_enemies) 
		{
			Vector3 bombToEnemy = enemy.transform.position - rb.transform.position;
			if (bombToEnemy.magnitude <= range_distance) 
			{
				bombToEnemy.Normalize ();
				if (Vector3.Dot (bombToEnemy, transform.forward) > range_angle_cos) 
				{
					first_enemy = enemy;
					break;
				}
			}
		}

	}

	void Update()
	{
		//if there is an enemy in front, target it
		if (first_enemy != null) 
		{
			rb.velocity = (first_enemy.transform.position - rb.transform.position).normalized * speed;
		}
		if (hit) {
			hit_time++;
			if (hit_time >= destroy_time) {
				Destroy (rb.gameObject);
			}
		}

		shot_time++;
		if (shot_time >= destroy_time) 
		{
			Destroy (rb.gameObject);
		}
	}


	void OnTriggerEnter(Collider other)
	{
//		if (other.gameObject.CompareTag ("Enermies"))
//		{
//			bombSound.Play();
//			Debug.Log ("here");
//			other.gameObject.SetActive (false);
//			// hide the bomb and destroy it after the sound effect is played
//			MeshRenderer render = gameObject.GetComponentInChildren<MeshRenderer>();
//			render.enabled = false;
//			hit = true;
//		}

		Debug.Log ("RocketCollision");
		if (other.gameObject.CompareTag ("Enermies")) {
			Debug.Log ("CollideBomb");
			bombSound.Play ();
			Debug.Log ("here");
			other.gameObject.SetActive (false);
			Instantiate (explosion, other.gameObject.transform.position + new Vector3(0,4,0), other.gameObject.transform.rotation);
			// hide the bomb and destroy it after the sound effect is played
			MeshRenderer[] renders = gameObject.GetComponentsInChildren<MeshRenderer> ();
			for (int i = 0; i < renders.Length; i++) {
				//				Debug.Log (renders [i]);
				renders[i].enabled = false;
			}
			//			render.enabled = false;
			hit = true;
		} else if (other.gameObject.CompareTag ("WallsAndBlocks")) {
			Destroy (rb.gameObject);
		} else {
			//			Debug.Log (other.gameObject.tag);
		}
	}

}
