using UnityEngine;
using System.Collections;

public class GamePauseManager : MonoBehaviour {

	public GameObject targetTreasureBox;

	Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update () {
		if (targetTreasureBox.GetComponent<TreasureBoxManager>().open == 1)
		{
			anim.SetTrigger("GameSuccess");
		}
	}
}