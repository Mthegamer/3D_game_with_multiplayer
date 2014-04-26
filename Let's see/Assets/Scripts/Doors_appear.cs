using UnityEngine;
using System.Collections;

public class Doors_appear : MonoBehaviour {
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	private int activated=0;
	void OnTriggerEnter(Collider other) {
		//Application.LoadLevel("Demo6");
		if(activated==0){
		activated=1;
		door1.animation.Play("Lifting_door2");
		door2.animation.Play("Lifting_door1");
		door3.animation.Play("Lifting_door3");
		door1.audio.Play();
		door2.audio.Play();
		door3.audio.Play();
		}
	}
}
