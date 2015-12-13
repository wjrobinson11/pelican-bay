using UnityEngine;
using System.Collections;

public class FireworkBlast : MonoBehaviour {
	private float initializationTime;
	public FireworkMovement fireworkMovement;

	// Use this for initialization
	void Start () {
		initializationTime = Time.realtimeSinceStartup;
	}
	
	// Update is called once per frame
	void Update () {
		var timeSinceInitialized = Time.realtimeSinceStartup - initializationTime;
		if (timeSinceInitialized > 0.5) {
			Destroy (gameObject);
		}
	}
}
