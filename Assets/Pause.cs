﻿using UnityEngine;
using System.Collections;

public class Pause : MonoBehaviour {
	public Texture2D logo;
	private Unpause unpause;

	void OnEnable() {
		// onEnable runs before start :(
		if (unpause == null) {
			unpause = DebugUtil.AssertNotNull(transform.parent.GetComponentInChildren<Unpause>());
		}
		unpause.gameObject.SetActive(false);
		Time.timeScale = 0;
	}

	void OnDisable() {
		// unpause
		unpause.gameObject.SetActive(true);
		Time.timeScale = 1;
	}

	void Update () {
		if (Input.GetKeyDown(KeyCode.Escape)) {
			gameObject.SetActive(false);
        }
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));
		GUI.backgroundColor = Color.clear;
		GUILayout.Box(logo);
		GUI.backgroundColor = Color.white;
		GUILayout.Box("PAUSED");
		if (GUILayout.Button ("Resume")) {
			gameObject.SetActive(false);
		}
		if (GUILayout.Button ("Quit")) {
			Application.LoadLevel("MainMenu");
		}
		GUILayout.EndArea();
	}
}
