using UnityEngine;
using System.Collections;

public class EnemyControllerBackForwardInRange : MonoBehaviour {

	public float speed;
	private Vector3 movement;
	private bool flag = false;


	void Start()
	{
	}
	void Update()
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if ( transform.localPosition.z > -330 && !flag) {
			//			Debug.Log ("2");
			transform.Rotate (0, 180, 0);
			flag = !flag;
		}
		if ( transform.localPosition.z < -402 && flag) {
			//			Debug.Log ("2");
			transform.Rotate (0, 180, 0);
			flag = !flag;
		}
	}
}
