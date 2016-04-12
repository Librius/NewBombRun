using UnityEngine;
using System.Collections;

public class FallingElems : MonoBehaviour {


	private float speed;
	private Color color;
	private Vector3 startPos;
	private Vector3 screenToWorld;

	void Start () {
		screenToWorld = Camera.main.ViewportToWorldPoint (new Vector3 (0, 0, 0));
		//Instantiate (gameObject,screenToWorld,Quaternion.identity);
	}

	void Awake () {
		speed = Random.Range (5,15);
		color = GetComponent<SpriteRenderer>().color;
		color.a = Random.Range (0.1f, 1f);
		startPos = transform.position;
	}

	// Update is called once per frame
	void Update () {
		transform.Rotate (0,0,2.5f);
		transform.position = new Vector3 (transform.position.x-speed*0.001f,transform.position.y-speed*0.001f,-0.02f);

		if (transform.position.y<screenToWorld.y-1 ){transform.position = startPos; speed = Random.Range (5,15);}



	}
}
