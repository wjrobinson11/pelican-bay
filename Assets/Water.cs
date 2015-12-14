using UnityEngine;
using System.Collections;

public class Water : MonoBehaviour {
	public BabyFrogMovement babyFrogPrefab;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D other) 
	{
		if (other.tag == "CapturedBabyFrog")
		{	
			GameObject fg = GameObject.FindGameObjectWithTag ("Frog");
			Frog frog = fg.GetComponent<Frog> ();
			frog.frogBabiesRescued += 1;
			GameObject bg = GameObject.FindGameObjectWithTag ("Boat");
			Boat boat = bg.GetComponent<Boat> ();
			boat.speed += 2f;
			if (frog.frogBabiesRescued == 3) {
				Debug.Log ("You Win!");
			}
			BabyFrogMovement babyFrog = (BabyFrogMovement)Instantiate (babyFrogPrefab, other.transform.position, Quaternion.identity);
			babyFrog.lilyPadNumber = frog.frogBabiesRescued;
			babyFrog.transform.localScale = new Vector3(1f,1f,0f);
			babyFrog.transform.position = new Vector3(other.transform.position.x, other.transform.position.y, 0);
			babyFrog.tag = "RescuedBabyFrog";
		}
	}
}
