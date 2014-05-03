using UnityEngine;
using System.Collections;

public class FlashLight : MonoBehaviour {
	public AudioClip[] sounds;
	public bool on=false;
	// Use this for initialization

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)){

			if(light.enabled==true){
				audio.clip=sounds[1];
				audio.Play();
				light.enabled=false;
				on=false;
			}
		else {
				light.enabled=true;
				audio.clip=sounds[0];
				audio.Play();
				on=true;
			}
	}
}
}
