using UnityEngine;
using System.Collections;

public class GameOverManager : MonoBehaviour {

	public IconProgressBar healthBar;
	// Use this for initialization

	Animator anim;

	void Awake() {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (healthBar.currentValue <= 0 || PlayerController.TimeRemain == 0) {
			anim.SetTrigger("GameOver");
		}
	}
}
