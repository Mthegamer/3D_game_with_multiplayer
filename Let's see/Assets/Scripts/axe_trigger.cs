using UnityEngine;
using System.Collections;

public class axe_trigger: MonoBehaviour {

	// Use this for initialization
	
	void OnTriggerEnter(Collider other)
	{	if(other.GetComponentInChildren<FlashLight>().enabled==false){
			PhotonNetwork.Destroy(this.gameObject);
		//this.gameObject.SetActive(false);
		other.SendMessage("equip_axe");
		}

	}
}
