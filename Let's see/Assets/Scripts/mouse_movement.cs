using UnityEngine;
using System.Collections;

public class mouse_movement : MonoBehaviour {

	public Texture2D cursor;
	// Use this for initialization
	void Start () {
		//Screen.showCursor = false;
		//Cursor.SetCursor(cursor,Vector2.zero,CursorMode.Auto);
	}
	
	// Update is called once per frame
	void Update () {
		Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
		transform.position = ray.GetPoint(10) ;
	}

}