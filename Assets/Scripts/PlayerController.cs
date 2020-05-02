using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerController : MonoBehaviour
{

	[Space]
	[Header("Movement Properties")]
	public float movementSpeed = 12f;
	public float jumpHeight = 12f;
	public float gravity = -9.8f;

	[Space]
	[Header("Ground Check Properties")]
	public Transform groundCheck;
	public float groundCheckRadius = .4f;
	public LayerMask groundMask;

	CharacterController characterController;
	Vector3 movement;
	float xMove;
	float zMove;

	Vector3 velocity;

	bool isGrounded = true;

	void Start() {
		characterController = GetComponent<CharacterController>();
	}

	void Update()
    {
		isGrounded = IsGrounded();
		Move(Time.deltaTime);
		Jump();
		ApplyGravity(Time.deltaTime);
	}

	private bool IsGrounded() {
		if (groundCheck == null) return true;

		return Physics.CheckSphere(groundCheck.position, groundCheckRadius, groundMask);
	}

	private void Move(float deltaTime) {
		xMove = Input.GetAxis("Horizontal");
		zMove = Input.GetAxis("Vertical");

		movement = transform.right * xMove + transform.forward * zMove;

		characterController.Move(movement * movementSpeed * deltaTime);
	}

	private void Jump() {
		if (Input.GetKeyDown(KeyCode.Space) && isGrounded) {
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}
	}

	private void ApplyGravity(float deltaTime) {
		if (isGrounded && velocity.y < 0)
			velocity.y = -2f;

		velocity.y += .5f * gravity * deltaTime;

		characterController.Move(velocity * deltaTime);
	}
}
