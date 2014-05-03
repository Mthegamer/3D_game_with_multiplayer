using UnityEngine;
using System.Collections;

public class Flashlight_trigger : MonoBehaviour {
	//public GameObject flash;
	// Use this for initialization
	//[RPC]

	void OnTriggerEnter(Collider other)
	{	if(other.GetComponentInChildren<axe_swing>().enabled==false){
			PhotonNetwork.Destroy(this.gameObject);
		//this.gameObject.SetActive(false);
		other.SendMessage("equip_flash");
		}
	
	}
}
