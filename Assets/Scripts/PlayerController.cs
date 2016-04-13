using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float default_speed;
	private float speed;
	public Text resultText;

	private Rigidbody rb;

	public float minSwipeDistY;
	public float minSwipeDistX;
	public float tiltSpeed;

	public GameObject bombBall;
	public GameObject rocket;
	public GameObject explosion;
	private GameObject shot;
	public Transform shot_spawn;

	private Vector2 startPos;

	public bool hasKey = false;

	public AudioSource shootSound;
	public AudioSource swipeSound;
	public AudioSource hurtSound;

	public IconProgressBar healthBar;
	public static float currentHealth;
	public static int HEALTH_MAX = 5;

	public Image targetImage;
	public Sprite treasureBox;

	public GameObject targetTreasureBox;

	public static bool hasRocket = false;
	public static int RocketInStock = 0;
	public static int ROCKET_MAX = 3;
	public Text rocketText;


	public static bool RocketHint;
	public static bool HealthHint;

	private Image KeyHint;
	public GameObject canvas;

	Animator anim;
	void Start ()
	{
		shot = bombBall;
		Debug.Log ("Start");
		rb = GetComponent<Rigidbody>();
		speed = default_speed;
//		healthBar.currentValue = 1;
		currentHealth = HEALTH_MAX;
//		arrow.GetComponents<WaitForSecondsExample> () [0].show = false;
//		Debug.Log (currentHealth);

//		Debug.Log(arrow.GetComponents<ArrowController> ()[0].ToString ());

		anim = GetComponent<Animator> ();
	}

	void Update ()
	{
		healthBar.currentValue = currentHealth;
		rocketText.text = "X " + RocketInStock;

//		Debug.Log (speed);

		if (hasRocket && RocketInStock > 0) {
			shot = rocket;
		} else 
		{
			shot = bombBall;
		}
		//throw bomb
		// comment for PC

		if (Input.GetButtonDown("Fire1")) {
			Instantiate (shot, shot_spawn.position, shot_spawn.rotation);
//			Debug.Log (shot_spawn.rotation);

			//used a rocket
			if(RocketInStock > 0)
				RocketInStock -- ;

			shootSound.Play ();
	        }

		//float moveHorizontal = Input.GetAxis ("Horizontal");
		//float moveVertical = Input.GetAxis ("Vertical");


		// keep moving forward

			transform.Translate (Vector3.forward * speed * Time.deltaTime);


		// press keyboard to turn left and right

		if (Input.GetKeyDown (KeyCode.RightArrow)) {
			speed = default_speed;
			transform.Rotate (0, 90, 0, Space.Self);
			swipeSound.Play();
		}
		if (Input.GetKeyDown (KeyCode.LeftArrow)) {
			speed = default_speed;
			transform.Rotate (0, -90, 0, Space.Self);
			swipeSound.Play();
		}
	
		// mobile device swipe to turn left and right

		if (Input.touchCount > 0) {

			Touch touch = Input.touches [0];

			switch (touch.phase) {

			case TouchPhase.Began:

				startPos = touch.position;

				break;

			case TouchPhase.Ended:
				float swipeDistVertical = (new Vector3 (0, touch.position.y, 0) - new Vector3 (0, startPos.y, 0)).magnitude;
				float swipeDistHorizontal = (new Vector3 (0, touch.position.x, 0) - new Vector3 (0, startPos.x, 0)).magnitude;

				if (swipeDistVertical > minSwipeDistY) {
					float swipeValueVertical = Mathf.Sign (touch.position.y - startPos.y);
					if (swipeValueVertical > 0) {
//						transform.Translate (Vector3.forward * speed * Time.deltaTime);
//						flag = 3;
						Instantiate (shot, shot_spawn.position, shot_spawn.rotation);
						shootSound.Play ();

						//used a rocket
						if(RocketInStock > 0)
							RocketInStock -- ;
					} 
					else if (swipeValueVertical < 0) {
//						transform.Translate (Vector3.back * speed * Time.deltaTime);
//						flag = 4;
					}
				}
				else if (swipeDistHorizontal > minSwipeDistX) {
					float swipeValueHorizontal = Mathf.Sign (touch.position.x - startPos.x);
					if (swipeValueHorizontal > 0) {
						speed = default_speed;
						transform.Rotate(0, 90, 0, Space.Self);
//						transform.Translate (Vector3.right * speed * Time.deltaTime);
//						flag = 1;
						swipeSound.Play();
					} 
					else if (swipeValueHorizontal < 0) {
						speed = default_speed;
						transform.Rotate(0, -90, 0, Space.Self);
//						transform.Translate (Vector3.left * speed * Time.deltaTime);
//						flag = 2;
						swipeSound.Play();
					}
				}
				break;
			}
		}

		//tilt
		Vector3 tiltVec = new Vector3(Input.acceleration.x, 0, 0);
		transform.Translate(tiltVec * tiltSpeed * Time.deltaTime);

		// gyro

//		transform.Translate (Vector3.forward * tiltSpeed * Time.deltaTime);
//		Vector3 pos = transform.position;
//		pos.y = Vector3.Dot(Input.gyro.gravity, Vector3.up) * tiltSpeed;
//		transform.position = pos;

		//show key hint
		if (KeyHint != null) 
		{
			KeyHint.transform.position = Vector3.MoveTowards (KeyHint.transform.position, targetImage.transform.position, 5);
		}
		if (KeyHint!=null && KeyHint.transform.position.Equals (targetImage.transform.position)) 
		{
			targetImage.sprite = treasureBox;
			KeyHint.gameObject.SetActive (false);
			KeyHint = null;
		}

	}

	void OnCollisionEnter(Collision collision)
	{
		speed = 0;
		if (collision.gameObject.CompareTag ("Enermies"))
		{
//			rb.gameObject.SetActive (false);
			currentHealth -= 1;
			Debug.Log (currentHealth);
//			currentHealth = 0;
			hurtSound.Play();
			healthBar.currentValue = currentHealth;
			speed = default_speed;
			if (currentHealth <= 0) {
				speed = 0;
				anim.SetTrigger("RabbitGameOver");
			}
//			healthBar.currentValue = GUILayout.HorizontalSlider(healthBar.currentValue, currentHealth, healthBar.maxValue);
//			Application.LoadLevel (Application.loadedLevel);
		}
		if (collision.gameObject.CompareTag ("Door") && hasKey)
		{
			speed = default_speed;
			Destroy(collision.gameObject.GetComponent<BoxCollider>());
			collision.gameObject.transform.GetChild (0).GetChild (1).gameObject.transform.Rotate (0, 90, 0);
			collision.gameObject.transform.GetChild (1).GetChild (1).gameObject.transform.Rotate (0, -90, 0);
		}
	}

	void OnTriggerEnter(Collider other) 
	{

//		Debug.Log ("there");
		if (other.gameObject.CompareTag ("Treasure Box"))
		{
			speed = 0;
			//other.gameObject.SetActive (false);
			other.gameObject.GetComponent<Animator>().SetBool("Open",true);
			other.gameObject.GetComponent<TreasureBoxManager>().open = 1;
			anim.SetTrigger("RabbitGameSuccess");
//			Debug.Log ("Here");
			//showWin ();
			//hasKey = true;
		}
		if (other.gameObject.CompareTag ("Key"))
		{
			other.gameObject.SetActive (false);
			hasKey = true;

			KeyHint = Instantiate (targetImage) as Image;
			KeyHint.transform.SetParent (canvas.transform);
			KeyHint.transform.localPosition = new Vector3 (0, 0, 0);

			//targetImage.sprite = treasureBox;

			GameObject arrow = transform.FindChild ("arrow").gameObject;
			arrow.GetComponents<ArrowController> () [0].target = targetTreasureBox;
		}
		if (other.gameObject.CompareTag ("Arrow"))
		{
//			print ("here");
			other.gameObject.SetActive (false);

			GameObject arrow = transform.FindChild ("arrow").gameObject;
			arrow.GetComponents<WaitForSecondsExample> () [0].show = true;
		}
		if (other.gameObject.CompareTag ("Rocket"))
		{
			//			print ("here");
			other.gameObject.SetActive (false);

//			GameObject arrow = transform.FindChild ("arrow_z").gameObject;
//			arrow.GetComponents<WaitForSecondsExample> () [0].show = true;

//			hasRocket = true;
//			RocketInStock = ROCKET_MAX;

			RocketHint = true;
		}
		if (other.gameObject.CompareTag ("AidBox")) 
		{
			other.gameObject.SetActive (false);
//			currentHealth = HEALTH_MAX;
//			healthBar.currentValue = currentHealth;
			HealthHint = true;
		}
//		if (other.gameObject.CompareTag ("SteinMamba")) {
//			other.gameObject.SetActive (false);
//			transform.GetChild (0).gameObject.SetActive (false);
//			transform.GetChild (1).gameObject.SetActive (true);
//		}
//			
	}

//	void showWin(){
//		resultText.text = "Loading Next Level ...";
//		speed = 0;
//	}
}
