using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		// TODO pick a real name
		GUILayout.Label("LD48");
		if (GUILayout.Button ("Play")) {
			Play();
        }
		if (GUILayout.Button ("Website")) {
			Application.OpenURL("http://erosson.org/games/LD48");
		}
        if (!Application.isWebPlayer && !Application.isEditor) {
			if (GUILayout.Button ("Exit")) {
				Application.Quit();
            }
        }
        GUILayout.EndArea();
	}

	private void Play() {
		Application.LoadLevel("Game");
	}
}
