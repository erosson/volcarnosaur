using UnityEngine;
using System.Collections;

public class CameraTracker : MonoBehaviour {
	public Transform trackedObject;

	void Update () {
		transform.position = new Vector3(trackedObject.position.x, trackedObject.position.y, transform.position.z);
	}
}
