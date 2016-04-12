using UnityEngine;
using System.Collections;

public class StoryMobileVideoPlayer : MonoBehaviour {

	public string movieFileName;
	public Color backgroundColor;

	#if UNITY_ANDROID || UNITY_IPHONE
	public FullScreenMovieControlMode controlMod = FullScreenMovieControlMode.Hidden;
	public FullScreenMovieScalingMode scalingMod = FullScreenMovieScalingMode.Fill;
	#endif
	// Use this for initialization
	void Start () {
		StartCoroutine(Play());
	}

	IEnumerator Play ()
	{
		yield return new WaitForSeconds(0.0f);
		#if UNITY_ANDROID || UNITY_IPHONE
		//Play full screen only
		Handheld.PlayFullScreenMovie (movieFileName,  backgroundColor, controlMod,scalingMod);
		#endif
		Application.LoadLevel("MainMenu");
	}
}
