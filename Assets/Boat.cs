using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {
	public float speed = 1.5f;

	// Use this for initialization
	void Start () {
		var rb = GetComponent<Rigidbody2D>();
		rb.velocity = new Vector2 (
			speed,
			0
		);
	}
	
	// Update is called once per frame
	void Update () {
		var rb = GetComponent<Rigidbody2D>();

		Vector2 theScale = transform.localScale;
		theScale.x = (rb.velocity.x < 0f ? -1.3f : 1.3f);
		transform.localScale = theScale;

		if(transform.position.x > 7.5) {
			rb.velocity = new Vector2 (
				-speed,
				0
			);
		}
		if(transform.position.x < -7.5) {
			rb.velocity = new Vector2 (
				speed,
				0
			);
		}
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		var bm = other.GetComponent<BirdMovement>();
		if (bm != null && bm.tag == "BirdWithFrog")
		{	
			Debug.Log ("Game Over");
		}
	}
}
