using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour {

	public float turnSpeed = 30f;
	public float speed = 10f;

	Rigidbody rb;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		rb.AddForce (transform.forward * Time.fixedDeltaTime * speed * Input.GetAxis("Vertical") * rb.mass);
		if (Vector3.Dot(rb.velocity, transform.forward) > 0)
			transform.Rotate (Vector3.up * Time.fixedDeltaTime * turnSpeed * rb.velocity.magnitude * Input.GetAxis("Horizontal"));
		else
			transform.Rotate (Vector3.down * Time.fixedDeltaTime * turnSpeed * rb.velocity.magnitude * Input.GetAxis("Horizontal"));
	}
}
