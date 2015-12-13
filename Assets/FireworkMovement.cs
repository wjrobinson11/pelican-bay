using UnityEngine;
using System.Collections;

public class FireworkMovement : MonoBehaviour {
	public bool launched = false;
	public Frog frog;
	public FireworkBlast fireworkBlastPrefab;

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 10) {
			Explode ();
		}
	}

	public void Launch () {
		var cf = GetComponent<ConstantForce2D> ();
		cf.relativeForce = (transform.up * 20);
		launched = true;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		var bm = other.GetComponent<BirdMovement>();
		if (bm != null)
		{	
			Explode ();
		}
	}

	public void Explode() {
		var noseConePosition = transform.position;
		var arr = Physics2D.OverlapCircleAll (noseConePosition, 1.5f);
		foreach (Collider2D element in arr) {
			var vector2 = new Vector2(element.transform.position.x - noseConePosition.x, element.transform.position.y - noseConePosition.y);
			element.attachedRigidbody.gravityScale = 1.0f;
			element.attachedRigidbody.AddForce(vector2 * 3, ForceMode2D.Impulse);
			var maxTorque = 4.0f;
			var torque = (Random.value * 2 * maxTorque) - maxTorque;
			element.attachedRigidbody.AddTorque (torque, ForceMode2D.Impulse);
		}
		Instantiate (fireworkBlastPrefab, transform.position, Quaternion.identity);
		frog.FireworkExploded ();
		Destroy (gameObject);
	}
}
