﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	Rigidbody2D rb2d;
	public float speed;
	public float Jump;
	public GameObject groundcheckleft;
	public GameObject groundcheckright;
	private SpriteRenderer spriteRenderer;
	private Animator animator;
	public float groundCheckTolerance;


	// Use this for initialization
	void Start () {
		rb2d = GetComponent<Rigidbody2D>();
		spriteRenderer = GetComponent<SpriteRenderer>();
		animator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {


		float Horizontal = Input.GetAxis ("Horizontal");

		rb2d.velocity = new Vector2(Horizontal * speed, rb2d.velocity.y);


		RaycastHit2D hitInfo1 = Physics2D.Raycast (groundcheckleft.transform.position, Vector2.down, groundCheckTolerance, LayerMask.GetMask("Ground"));
		RaycastHit2D hitInfo2 = Physics2D.Raycast (groundcheckright.transform.position, Vector2.down, groundCheckTolerance, LayerMask.GetMask("Ground"));
		if (hitInfo1||hitInfo2.collider != null) {
			if (Input.GetButtonDown ("Jump"))
			{
				rb2d.AddForce (Vector2.up * Jump); 

			}
		
		


		
		}

		bool flipSprite = (spriteRenderer.flipX ? (Horizontal > 0f) : (Horizontal < 0f));
		if (flipSprite) 
		{
			spriteRenderer.flipX = !spriteRenderer.flipX;

		}

		//animator.SetBool ("grounded", grounded);
		//animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);

	}
}
