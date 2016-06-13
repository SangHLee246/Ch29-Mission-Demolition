using UnityEngine;
using System.Collections;

public class FollowCam : MonoBehaviour {
	static public FollowCam S; //a FollowCam Singleton
	public float easing = 0.05f;
	public Vector2 minXY;
	public bool _______________________________;

	public GameObject poi;
	public float camZ;

	void Awake() {
		S = this;
		camZ = this.transform.position.z;
	}
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		if (poi == null)
			return;
		Vector3 destination = poi.transform.position;
		this.camera.orthographicSize = destination.y + 10;
		destination.x = Mathf.Max (minXY.x, destination.x);
		destination.y = Mathf.Max (minXY.y, destination.y);
		destination = Vector3.Lerp (transform.position, destination, easing);
		destination.z = camZ;
		transform.position = destination;
	}
}
