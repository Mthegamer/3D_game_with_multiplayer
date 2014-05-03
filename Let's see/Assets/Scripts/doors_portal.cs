using UnityEngine;
using System.Collections;

public class doors_portal : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnTriggerEnter(Collider other) {
		PhotonNetwork.isMessageQueueRunning = false;
		Application.LoadLevel("Graveyard");
		PhotonNetwork.isMessageQueueRunning = true;
	}

}
