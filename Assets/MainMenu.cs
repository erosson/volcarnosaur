﻿using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public Texture2D logo;
	public AudioClip selectSfx;

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.backgroundColor = Color.clear;
		GUILayout.Box(logo);
		GUI.backgroundColor = Color.white;
		GUILayout.Box("The volcano demands blood! Push other dinosaurs into its fiery maw to delay the eruption.\n\n" + 
		              "Arrow keys move.");
		if (GUILayout.Button ("Play")) {
			//AudioSource.PlayClipAtPoint(selectSfx, transform.position);
			Application.LoadLevel("Game");
        }
		if (GUILayout.Button ("Website")) {
			AudioSource.PlayClipAtPoint(selectSfx, transform.position);
			Application.OpenURL("http://erosson.org/games/volcarnosaur");
		}
        if (!Application.isWebPlayer && !Application.isEditor) {
			if (GUILayout.Button ("Exit")) {
				AudioSource.PlayClipAtPoint(selectSfx, transform.position);
				Application.Quit();
            }
        }
        GUILayout.EndArea();
	}

	void Update() {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			AudioSource.PlayClipAtPoint(selectSfx, transform.position);
			Application.Quit();
		}
	}
}
