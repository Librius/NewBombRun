using UnityEngine;
using System.Collections;

public class EnemyControllerBackForward : MonoBehaviour {
	public float speed;
	private Vector3 movement;


	void Start()
	{
	}
	void Update()
	{
		    transform.Translate (Vector3.forward * speed * Time.deltaTime);
	}
	void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag ("WallsAndBlocks")) {
		} 
		else {
			transform.Rotate (0, 180, 0);
		}
	}
}
