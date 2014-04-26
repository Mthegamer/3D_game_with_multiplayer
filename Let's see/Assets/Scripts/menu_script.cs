using UnityEngine;
using System.Collections;

public class menu_script : MonoBehaviour {
	public int number;
	public GameObject door1;
	public GameObject door2;
	public GameObject door3;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnMouseEnter(){
		if(number==1){
			animation.Play("selected");
			door1.gameObject.SetActive(true);
			door1.animation.Play("door1");
			audio.Play();
		}
		if(number==2){
			animation.Play("selected-options");
			door2.gameObject.SetActive(true);
			door2.animation.Play("door2");
			audio.Play();
		}
		if(number==3){
			animation.Play("selected-exit");
			door3.gameObject.SetActive(true);
			door3.animation.Play("door3");
			audio.Play();
		}
	}
	void OnMouseExit(){
		if(number==1){
			animation.Play("selected-back");
			door1.animation.Play("door1-back");	
			door1.gameObject.SetActive(false);
		}
		if(number==2){
			animation.Play("selected-options-back");
			door2.animation.Play("door2-back");	
			door2.gameObject.SetActive(false);
		}
		if(number==3){
			animation.Play("selected-exit-back");
			door3.animation.Play("door3-back");	
			door3.gameObject.SetActive(false);
		}
	}
	void OnMouseUp(){
		if(number==1)Application.LoadLevel("Island");
		if(number==3)Application.Quit();
	}
}
