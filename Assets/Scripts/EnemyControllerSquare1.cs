using UnityEngine;
using System.Collections;

public class EnemyControllerSquare : MonoBehaviour {

	public float speed;
	private Vector3 movement;
	private bool flag = false;

	void Start()
	{
	}
	void Update()
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
		if (flag && transform.localPosition.z < -280 ) {
			double s = Time.deltaTime * 0.07;
			float shift = (float)s;
			transform.Translate (new Vector3(shift,0,0));
		}
//		Debug.Log(transform.localPosition.z);
		if ( transform.localPosition.z < -292.5 && transform.localPosition.x > -730 && !flag) {
			Debug.Log ("2");
			transform.Rotate (0, 90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.x < -730 && transform.localPosition.z < -280 && flag) {
			Debug.Log ("3");
			transform.Rotate (0, 90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.z > -208 && transform.localPosition.x < -730 && !flag) {
			Debug.Log ("4");
			transform.Rotate (0, 90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.x > -542 && transform.localPosition.z > -210 && flag) {
			Debug.Log ("1");
			transform.Rotate (0, 90, 0);
			flag = !flag;
		}
	}

}
