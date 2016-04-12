using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CameraController : MonoBehaviour {

	public Transform target;
	public float distanceAboveTarget;
	public float distance;
	public float height;
	public float damping;
	public bool smoothRotation = true;
	public bool followBehind = true;
	public float rotationDamping = 10.0f;

	private List<Renderer> colliderObject;//the objects between rabbit and camera


	// Use this for initialization
	void Start () {
		colliderObject = new List<Renderer> ();
	}

	void Update(){
		//transform.LookAt (target);
		Vector3 wantedPosition;
		if(followBehind)
			wantedPosition = target.TransformPoint(0, height, -distance);
		else
			wantedPosition = target.TransformPoint(0, height, distance);

		transform.position = Vector3.Lerp (transform.position, wantedPosition , Time.deltaTime * damping);

		if (smoothRotation) {
			Quaternion wantedRotation = Quaternion.LookRotation(target.position + new Vector3(0, distanceAboveTarget, 0) - transform.position, target.up);
			transform.rotation = Quaternion.Slerp (transform.rotation, wantedRotation, Time.deltaTime * rotationDamping);
		}
		else transform.LookAt (target, target.up);
//		Debug.Log (target.up);

		//get objects between rabbit and camera and set them transparent
		//Debug.DrawLine(target.position, transform.position, Color.red);
		RaycastHit[] hit;
		hit = Physics.RaycastAll(transform.position,target.position-transform.position,(target.position-transform.position).magnitude);
		if (hit.Length > 0) 
		{
			for (int i = 0; i < hit.Length; i++) 
			{
				if (hit [i].collider.gameObject.tag == "WallsAndBlocks") 
				{
					Renderer obj = hit [i].collider.gameObject.GetComponent<Renderer> ();
					colliderObject.Add (obj);
					SetMaterialsColor (obj, 0.5f);
				}
			}
		} 
		else 
		{
			for (int i = 0; i < colliderObject.Count; i++)
			{
				Renderer obj = colliderObject[i];
				SetMaterialsColor(obj, 1f);
			}
			//colliderObject.Clear ();
		}
	}

	private void SetMaterialsColor(Renderer _renderer, float Transpa)
	{
		_renderer.material.shader = Shader.Find("Transparent/Diffuse");
		int materialsNumber = _renderer.sharedMaterials.Length;
		for (int i = 0; i < materialsNumber; i++)
		{

			//获取当前材质球颜色
			Color color = _renderer.materials[i].color;

			//设置透明度  0-1;  0 = 完全透明
			color.a = Transpa;

			//置当前材质球颜色
			_renderer.materials[i].SetColor("_Color", color);
		}

	}


}