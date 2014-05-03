using UnityEngine;
using System.Collections;

public class key_portal : MonoBehaviour {

	// Use this for initialization
	void OnTriggerEnter(Collider other) {
		PhotonNetwork.isMessageQueueRunning = false;
		Application.LoadLevel("Island");
		PhotonNetwork.isMessageQueueRunning = true;
	}
}
