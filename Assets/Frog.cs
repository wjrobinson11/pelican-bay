using UnityEngine;
using System.Collections;

public class Frog : MonoBehaviour {
	public FireworkMovement fireworkPrefab;
	public BirdMovement birdPrefab;
	FireworkMovement currentFirework;
	public int frogBabiesRescued;

	// Use this for initialization
	void Start () {
		CreateFirework ();

	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("x")) {
			if (currentFirework.launched) {
				ExplodeFirework ();
			} else {
				currentFirework.Launch ();
			}
		}
	}

	public void FireworkExploded () {
		CreateFirework ();
	}

	void ExplodeFirework () {
		currentFirework.Explode ();
	}

	void CreateFirework() {
		currentFirework = Instantiate (fireworkPrefab);
		currentFirework.frog = this;
	}
}
