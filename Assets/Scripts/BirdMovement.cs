using UnityEngine;
using System.Collections;

public class BirdMovement : MonoBehaviour {
	public bool dead;
	public float absoluteSpeed;

	// Use this for initialization
	void Start () {
		absoluteSpeed = ((Random.value + 1) * 2.0f);
		dead = false;
		var rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (
			absoluteSpeed,
			0
		);
	}
	
	// Update is called once per frame
	void Update () {			
		var rb = GetComponent<Rigidbody2D>();
		if (dead) {
			rb.gravityScale = 1.0f;
		} else {
			Vector2 theScale = transform.localScale;
			theScale.x = (rb.velocity.x < 0f ? -0.2f : 0.2f);
			transform.localScale = theScale;

			if(transform.position.x > 7.5) {
				rb.velocity = new Vector2 (
					-absoluteSpeed,
					0
				);
			}
			if(transform.position.x < -7.5) {
				rb.velocity = new Vector2 (
					absoluteSpeed,
					0
				);
			}
		}
	}
}
