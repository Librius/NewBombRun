using UnityEngine;
using System.Collections;

public class EnemyControllerRandom : MonoBehaviour {
	public float speed;
	private Rigidbody rb;
	private Vector3 movement;
	private int count = 0;
	private System.Random random = new System.Random();

	private Vector3 InitialPostion;
	private bool UpDown;//true means the spikeball will go up; false means down
	private const float YshiftUnit = 0.1f;//shifting in Y axis
	private const float MAX_SHIFT = 1.0f;//max shift above the ground


	void Start()
	{
		rb = GetComponent<Rigidbody> ();
		movement = new Vector3 (speed, 0, speed);
		InitialPostion = rb.gameObject.transform.position;
		UpDown = true;
	}
	void FixedUpdate()
	{
		rb.AddForce (movement);
		count++;
		if (count > 20) {
			int x = random.Next (-20, 20);
			int z = random.Next (-20, 20);
			movement.x = x;
			movement.z = z;
			count = 0;
		}
		if (UpDown == true) {
			rb.gameObject.transform.position = new Vector3(rb.gameObject.transform.position.x,rb.gameObject.transform.position.y+YshiftUnit,rb.gameObject.transform.position.z);
			if (rb.gameObject.transform.position.y - InitialPostion.y > MAX_SHIFT) 
				UpDown = false;
		} 
		else 
		{
			rb.gameObject.transform.position = new Vector3(rb.gameObject.transform.position.x,rb.gameObject.transform.position.y-YshiftUnit,rb.gameObject.transform.position.z);
			if (rb.gameObject.transform.position.y <= InitialPostion.y)
				UpDown = true;
		}
	}
	void OnCollisionEnter(Collision collision)
	{
		if (!collision.gameObject.CompareTag ("WallsAndBlocks")) {
			return;
		}
		//var otherPosition = other.gameObject.transform.position;
		var otherPosition = collision.contacts[0].point;
		var playerPosition = gameObject.transform.position;
		if (System.Math.Abs (otherPosition.x - playerPosition.x) > System.Math.Abs (otherPosition.z - playerPosition.z)) {
			movement.x = -movement.x;
		} else
			movement.z = -movement.z;
	}
}
