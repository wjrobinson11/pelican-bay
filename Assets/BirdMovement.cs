using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
	bool dead;

	// Use this for initialization
	void Start () {
		dead = false;
		var rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (
			2.0f,
			0
		);
	}
	
	// Update is called once per frame
	void Update () {
		var rb = GetComponent<Rigidbody2D>();
		Vector2 theScale = transform.localScale;
		theScale.x = (rb.velocity.x < 0f ? -0.2f : 0.2f);
		transform.localScale = theScale;

		if (dead) {
			rb.gravityScale = 1.0f;
		} else {
			if(transform.position.x > 8.2) {
				rb.velocity = new Vector2 (
					-2.0f,
					0
				);
			}
			if(transform.position.x < -8.2) {
				rb.velocity = new Vector2 (
					2.0f,
					0
				);
			}
		}
	}
}
