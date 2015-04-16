using UnityEngine;
using System.Collections;

public class PlayerMovement : Photon.MonoBehaviour {
	Rigidbody body;
	public float speed;
	// Use this for initialization
	void Awake () {
		body = this.gameObject.GetComponent<Rigidbody> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (photonView.isMine)
		Movement ();
	}

	void Movement() {
		float moveHorizontal = Input.GetAxis ("Horizontal");
		float moveVertical = Input.GetAxis ("Vertical");

		Vector3 movement = new Vector3 (moveHorizontal, 0, moveVertical);
		body.AddForce (movement * speed * Time.deltaTime);
	}
}
