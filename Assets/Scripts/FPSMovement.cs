using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FPSMovement : MonoBehaviour
{
	private Rigidbody rb;
	public float MouseSensitivity;
	public float MoveSpeed;
	public float JumpForce;

	private void Start()
	{
		rb = GetComponent<Rigidbody>();
	}
	void Update ()
	{
		rb.MoveRotation( rb.rotation * Quaternion.Euler( new Vector3( 0, Input.GetAxis( "Mouse X" ) * MouseSensitivity, 0 ) ) );
		rb.MovePosition( transform.position + ( transform.forward * Input.GetAxis( "Vertical" ) * MoveSpeed ) + ( transform.right * Input.GetAxis( "Horizontal" ) * MoveSpeed ) );
	}
}
