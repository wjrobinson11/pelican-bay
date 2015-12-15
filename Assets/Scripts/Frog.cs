using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Frog : MonoBehaviour {
	public FireworkMovement fireworkPrefab;
	public BirdMovement birdPrefab;
	FireworkMovement currentFirework;
	public int frogBabiesRescued;
	public HashSet<BabyFrogMovement> frogBabiesArrived;

	// Use this for initialization
	void Start () {
		CreateFirework ();
		frogBabiesArrived = new HashSet<BabyFrogMovement>();
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
