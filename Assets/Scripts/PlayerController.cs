using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float speed = 100f;
	public Rigidbody rb;
	// Update is called once per frame

	
	void FixedUpdate ()
	{
		float moveVertical = Input.GetAxis ("Vertical");
		float moveHorizontal = Input.GetAxis ("Horizontal");

		Vector3 movement = new Vector3 (moveHorizontal, 0.0f, moveVertical);
		
		rb = GetComponent<Rigidbody>();


		rb.AddForce (movement * speed * Time.deltaTime);
		

	}
}