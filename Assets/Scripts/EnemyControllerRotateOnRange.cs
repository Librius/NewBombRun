using UnityEngine;
using System.Collections;

public class EnemyControllerRotateOnRange : MonoBehaviour {
	public float speed;
	public float range;
	private Vector3 movement;
	private float count = 0;


	void Start()
	{
	}
	void Update()
	{
		count += 1;
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if (count >= range) {
			transform.Rotate (0, 90, 0);
			count = 0;
		}
	}
}