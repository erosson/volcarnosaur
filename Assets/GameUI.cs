using UnityEngine;
using System.Collections;

public class GameUI : MonoBehaviour {
	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			// TODO confirm quit
			Application.LoadLevel("MainMenu");
		}
	}
}
