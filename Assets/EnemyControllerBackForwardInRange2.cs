using UnityEngine;
using System.Collections;

public class EnemyControllerBackForwardInRange2 : MonoBehaviour {

	public float speed;
	private Vector3 movement;
	private bool flag = false;


	void Start()
	{
	}
	void Update()
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if ( transform.localPosition.x > -740 && !flag) {
			//			Debug.Log ("2");
			transform.Rotate (0, 180, 0);
			flag = !flag;
		}
		if ( transform.localPosition.x < -880 && flag) {
			//			Debug.Log ("2");
			transform.Rotate (0, 180, 0);
			flag = !flag;
		}
	}
}
