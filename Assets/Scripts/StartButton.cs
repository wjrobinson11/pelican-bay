using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class StartButton : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("z") || Input.GetKeyDown("x")){
			if (SceneManager.GetActiveScene ().name == "Title Page") {
				InstructionsPage ();
			} else {
				StartGame ();
			}
		}
	}

	public void InstructionsPage() {
		SceneManager.LoadScene ("Instructions Page");
	}

	public void StartGame() {
		SceneManager.LoadScene ("Bad Pelicans");
	}
}
