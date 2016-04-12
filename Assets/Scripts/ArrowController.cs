using UnityEngine;
using System.Collections;

public class ArrowController : MonoBehaviour {
	public GameObject player;
	private Vector3 offset;
	public GameObject target;
	Vector3 target_point;


	// Use this for initialization
	void Start () {	
		offset = transform.position - player.transform.position;
	}

	void Update(){
		target_point = target.transform.position;
		target_point.z = 0;
		transform.LookAt(target.transform);
	}
	// Update is called once per frame
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
