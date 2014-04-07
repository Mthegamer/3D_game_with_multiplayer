using UnityEngine;
using System.Collections;

public class mouse_movement : MonoBehaviour {

	// Use this for initialization
	void Start () {

	
	}
	void Awake(){
		Screen.lockCursor = true;
		
		Screen.showCursor = false;
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		
		// 10 meters in front of the camera:
		
		transform.position = ray.GetPoint(10) ;
	}
}
