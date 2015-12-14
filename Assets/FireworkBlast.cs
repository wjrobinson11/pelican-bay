using UnityEngine;
using System.Collections;

public class FireworkBlast : MonoBehaviour {
	private float initializationTime;
	public FireworkMovement fireworkMovement;

	// Use this for initialization
	void Start () {
		initializationTime = Time.realtimeSinceStartup;
		GetComponent<SpriteRenderer>().color = Color.HSVToRGB(Random.value, 1f, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		ShowBabyFrogs ();
		var timeSinceInitialized = Time.realtimeSinceStartup - initializationTime;
		if (timeSinceInitialized > 0.5) {
			Destroy (gameObject);
			HideBabyFrogs ();
		}
	}

	public void HideBabyFrogs() {
		var babyFrogs = GameObject.FindGameObjectsWithTag ("CapturedBabyFrog");
		foreach (GameObject element in babyFrogs) {
			element.GetComponent<SpriteRenderer> ().enabled = false;
		}
	}

	public void ShowBabyFrogs() {
		var babyFrogs = GameObject.FindGameObjectsWithTag ("CapturedBabyFrog");
		foreach (GameObject element in babyFrogs) {
			element.GetComponent<SpriteRenderer> ().enabled = true;
		}
	}
}
