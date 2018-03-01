using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BirdScript : MonoBehaviour
{

	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;

	private float bounceSpeed = 4f;

	private bool didFlap;

	public bool isAlive;

	private Button flatButton;

	[SerializeField]
	private AudioSource audioSource;

	[SerializeField]
	private AudioClip flapClick, pointClip, diedClip;

	public int score;

	void Awake ()
	{
		if (instance == null) {
			instance = this;
		}
		isAlive = true;
		score = 0;
		flatButton = GameObject.FindGameObjectWithTag ("FlapButton").GetComponent<Button> ();
		flatButton.onClick.AddListener (() => FlapTheBird ());

		SetCamerasX ();
	}
		
	void FixedUpdate ()
	{
		if (isAlive) {
			Vector3 temp = transform.position;
			temp.x += forwardSpeed * Time.deltaTime;
			transform.position = temp;

			if (didFlap) {
				didFlap = false;
				myRigidBody.velocity = new Vector2 (0, bounceSpeed);
				audioSource.PlayOneShot (flapClick);
				anim.SetTrigger ("Flap");
			}

			if (myRigidBody.velocity.y >= 0) {
				transform.rotation = Quaternion.Euler (0, 0, 0);
			} else {
				float angle = 0;
				angle = Mathf.Lerp (0, -90, -myRigidBody.velocity.y / 7);
				transform.rotation = Quaternion.Euler (0, 0, angle);
			}
		}
			
	}

	void SetCamerasX ()
	{
		CameraScript.offsetX = (Camera.main.transform.position.x - transform.position.x) - 1f;
	}

	public float GetPositionX ()
	{
		return transform.position.x;
	}

	public void FlapTheBird ()
	{
		didFlap = true;
	}

	//If both collision target and source are not set to isTrigger, need to use OnCollisionEnter2D
	void OnCollisionEnter2D (Collision2D target)
	{
		if (target.gameObject.tag == "Ground" || target.gameObject.tag == "Pipe") {
			if (isAlive) {
				isAlive = false;
				anim.SetTrigger ("Bird Died");
				audioSource.PlayOneShot (diedClip);
				GamePlayController.instance.PlayerDiedShowScore (score);
			}
		}
	}

	//Eiter collision target or source set to isTrigger
	void OnTriggerEnter2D (Collider2D target)
	{
		if (target.tag == "PipeHolder") {
			audioSource.PlayOneShot (pointClip);
			score++;
			GamePlayController.instance.SetScore (score);
		}
	}
}
