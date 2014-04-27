using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture2D logo;

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.backgroundColor = Color.clear;
		GUILayout.Box(logo);
		GUI.backgroundColor = Color.white;
		GUILayout.Box("The volcano demands blood! Push other dinosaurs into its fiery maw to delay the eruption.\n\n" + 
		              "Arrow keys move.");
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

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			Application.Quit();
		}
	}

	private void Play() {
		Application.LoadLevel("Game");
	}
}
