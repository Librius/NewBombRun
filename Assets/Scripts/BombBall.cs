using UnityEngine;
using System.Collections;

public class BombBall : MonoBehaviour 
{
	public float speed;
	public GameObject explosion;
	private Rigidbody rb;

	public int destroy_time = 100;
	private int shot_time = 0;
	private int hit_time = 0;
	private bool hit = false;

	private AudioSource bombSound;

	void Start ()
	{
		rb = GetComponent<Rigidbody>();
		rb.velocity = transform.forward * speed;
		bombSound = GetComponent<AudioSource> ();
//		Debug.Log(
	}

	void Update()
	{
		transform.Rotate (new Vector3 (900, 0, 0) * Time.deltaTime);

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
//		Debug.Log ("CollideBomb");
		if (other.gameObject.CompareTag ("Enermies")) {
			Debug.Log ("CollideBomb");
			bombSound.Play ();
			Debug.Log ("here");
			other.gameObject.SetActive (false);
			// hide the bomb and destroy it after the sound effect is played
			MeshRenderer[] renders = gameObject.GetComponentsInChildren<MeshRenderer> ();
			Instantiate (explosion, other.gameObject.transform.position + new Vector3(0,5,0), other.gameObject.transform.rotation);
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
