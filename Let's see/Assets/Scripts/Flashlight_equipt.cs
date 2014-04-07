using UnityEngine;
using System.Collections;

public class Flashlight_equipt : MonoBehaviour {
	public GameObject flash;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other)
	{	this.gameObject.SetActive(false);
		//other.gameObject.GetComponent("flashlight").
		flash.gameObject.SetActive(true);
	}
}
