using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class BabyFrogMovement : MonoBehaviour {
	public int lilyPadNumber;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (tag == "RescuedBabyFrog") {
			float step = 2 * Time.deltaTime;
			GameObject target = GameObject.FindGameObjectWithTag (string.Format("EmptyLilyPad{0}", lilyPadNumber));
			Vector3 targetPosition = new Vector3 (target.transform.position.x,target.transform.position.y + 0.3f, target.transform.position.z);
			transform.position = Vector3.MoveTowards(transform.position, targetPosition, step);
			if (transform.position.x == target.transform.position.x ) {
				GameObject fg = GameObject.FindGameObjectWithTag ("Frog");
				Frog frog = fg.GetComponent<Frog> ();
				frog.frogBabiesArrived.Add (this);
				if (frog.frogBabiesArrived.Count == 3) {
					SceneManager.LoadScene ("Winners Page");
				}
				target.GetComponent<SpriteRenderer> ().enabled = false;
				GetComponent<SpriteRenderer> ().enabled = false;
				GameObject occupiedLilyPad = GameObject.FindGameObjectWithTag (string.Format("OccupiedLilyPad{0}", lilyPadNumber));
				occupiedLilyPad.transform.position = new Vector3 (occupiedLilyPad.transform.position.x,occupiedLilyPad.transform.position.y, -1f);
			}
		}
	}


}
