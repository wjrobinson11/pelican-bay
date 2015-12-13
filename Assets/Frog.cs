using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour {
	public FireworkMovement fireworkPrefab;
	FireworkMovement currentFirework;

	// Use this for initialization
	void Start () {
		CreateFirework ();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("space")) {
			Debug.Log ("shooting firework");
			if (currentFirework.launched) {
				ExplodeFirework ();
			} else {
				LaunchFirework ();
			}
		}
	}

	public void FireworkExploded () {
		CreateFirework ();
	}

	void ExplodeFirework () {
		currentFirework.Explode ();
	}

	void LaunchFirework () {
		currentFirework.Launch ();
	}

	void CreateFirework() {
		currentFirework = Instantiate (fireworkPrefab);
		currentFirework.frog = this;
	}
}
