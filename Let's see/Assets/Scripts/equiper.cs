using UnityEngine;
using System.Collections;

public class equiper : MonoBehaviour {
	public GameObject flash;
	public GameObject axe;
	bool equip=false;
	// Use this for initialization
	//[RPC]
	void equip_flash()
	{
		if(!equip)
		{
			flash.GetComponentInChildren<MeshRenderer>().enabled=true;
			flash.GetComponentInChildren<FlashLight>().enabled=true;
			equip=true;
		}
	}
	void equip_axe()
	{
		if(!equip)
		{
			axe.GetComponentInChildren<MeshRenderer>().enabled=true;
			axe.GetComponentInChildren<axe_swing>().enabled=true;
			equip=true;
		}
	}
}
