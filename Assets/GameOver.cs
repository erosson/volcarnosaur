using UnityEngine;
using System.Collections;

public class GameOver : MonoBehaviour {
	private GameOverParams args;

	// Use this for initialization
	void Start () {
		var obj = GameObject.Find("/GameOverParams");
		if (obj == null) {
			obj = GameObject.Find("/DefaultGameOverParams");
		}
		DebugUtil.Assert(obj != null);
		args = obj.GetComponent<GameOverParams>();
		DebugUtil.Assert(args != null);
		Destroy(obj);
	}

	void OnGUI() {
		GUILayout.BeginArea(new Rect(0, 100, Screen.width, Screen.height-100));
		GUILayout.Box(string.Format ("Survived {0} seconds", args.elapsedSeconds));
		if (GUILayout.Button ("Return to Main Menu")) {
			Application.LoadLevel("MainMenu");
		}
		GUILayout.EndArea();
	}
}
