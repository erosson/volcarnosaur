using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 200, Screen.width, Screen.height));
		GUILayout.Label("The volcano demands blood! Throw other dinosaurs into its fiery maw to delay the eruption, but don't let others throw you in!");
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
