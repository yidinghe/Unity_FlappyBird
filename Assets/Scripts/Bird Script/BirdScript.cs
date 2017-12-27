using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BirdScript : MonoBehaviour {

	public static BirdScript instance;

	[SerializeField]
	private Rigidbody2D myRigidBody;

	[SerializeField]
	private Animator anim;

	private float forwardSpeed = 3f;

	private float bounceSpeed = 4f;

	private bool didFlap;

	public bool isAlive;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		
	}
}
