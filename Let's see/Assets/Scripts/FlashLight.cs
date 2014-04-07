using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){
			if(light.enabled==true)light.enabled=false;
		else light.enabled=true;}
	}
}
