using UnityEngine;
using System.Collections;

public class EnemyControllerSquare2 : MonoBehaviour {

	public float speed;
	private Vector3 movement;
	private bool flag = false;

	void Start()
	{
	}
	void Update()
	{
		transform.Translate (Vector3.forward * speed * Time.deltaTime);
//		if (flag && transform.localPosition.z < -280 ) {
//			double s = Time.deltaTime * 0.07;
//			float shift = (float)s;
//			transform.Translate (new Vector3(shift,0,0));
//		}
		//		Debug.Log(transform.localPosition.z);
		if ( transform.localPosition.x > -356 && transform.localPosition.z < -205 && !flag) {
//			Debug.Log ("2");
			transform.Rotate (0, -90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.x > -356 && transform.localPosition.z > -139 && flag) {
//			Debug.Log ("3");
			transform.Rotate (0, -90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.z > -139 && transform.localPosition.x < -541 && !flag) {
//			Debug.Log ("4");
			transform.Rotate (0, -90, 0);
			flag = !flag;
		}
		if ( transform.localPosition.x < -540 && transform.localPosition.z > -208 && flag) {
//			Debug.Log ("1");
			transform.Rotate (0, -90, 0);
			flag = !flag;
		}
	}
}
