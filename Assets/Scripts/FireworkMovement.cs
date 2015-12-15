using UnityEngine;
using System.Collections;

public class FireworkMovement : MonoBehaviour {
	public bool launched = false;
	public Frog frog;
	public FireworkBlast fireworkBlastPrefab;
	float arcWidth = 90f;
	float offsetAngle = 45f;
	float rotationSpeed = 80f;
	static float rotateTime;

	// Use this for initialization
	void Start () {
		
	}

	
	// Update is called once per frame
	void Update () {
		if (transform.position.y > 10) {
			Explode ();
		}

		if (Input.GetKey ("z") && !launched) {
			rotateTime += Time.deltaTime;
		}
		var angle = -offsetAngle + Mathf.PingPong (offsetAngle-(rotateTime * rotationSpeed), arcWidth);
		transform.eulerAngles = Vector3.forward * angle;
	}

	public void Launch () {
		GameObject fg = GameObject.FindGameObjectWithTag ("Frog");
		Frog frog = fg.GetComponent<Frog> ();
		if (frog.frogBabiesRescued == 2) {
			var birdMovements = FindObjectsOfType<BirdMovement>();
			foreach(BirdMovement element in birdMovements){
				if(!element.dead){
					var rb = element.GetComponent<Rigidbody2D> ();
					rb.velocity = new Vector2 (-rb.velocity.x, rb.velocity.y);
				}
			}
		}
		GetComponent<Rigidbody2D> ().mass = 1;
		var cf = GetComponent<ConstantForce2D> ();
		cf.relativeForce = (Vector2.up * 20);
		launched = true;
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		var bm = other.GetComponent<BirdMovement>();
		if (bm != null && launched == true)
		{	
			Explode ();
		}
	}

	public void Explode() {
		var fireworkCenterPos = transform.position + new Vector3(0f,1f,0f);
		var arr = Physics2D.OverlapCircleAll (fireworkCenterPos, 1.2f, LayerMask.GetMask("Pelican"));
		foreach (Collider2D element in arr) {
			var blastDisplacement = new Vector2(element.transform.position.x - fireworkCenterPos.x, element.transform.position.y - fireworkCenterPos.y);
			element.GetComponent<BirdMovement>().dead = true;
			element.attachedRigidbody.AddForce(blastDisplacement * 3, ForceMode2D.Impulse);
			var maxTorque = 4.0f;
			var torque = ((Random.value+2) * maxTorque) - maxTorque;
			element.attachedRigidbody.AddTorque (torque, ForceMode2D.Impulse);
		}
		var animationPos = transform.position - new Vector3 (0.3f,-1f,0f);
		Instantiate (fireworkBlastPrefab, animationPos, Quaternion.identity);
		frog.FireworkExploded ();
		Destroy (gameObject);
	}
}
