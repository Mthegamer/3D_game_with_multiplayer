using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public Camera standbyCamera;
	SpawnSpot[] spawnSpots;
	// Use this for initialization
	void Start () {

		DontDestroyOnLoad(this);
		Screen.lockCursor=true;
		spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
		Connect();
	}
	void Connect(){
		PhotonNetwork.ConnectUsingSettings("420 Blaze it~~!");
	}
	void OnGUI(){
		GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
	}
	void OnJoinedLobby(){
		Debug.Log("OnJoinedLobby");
		PhotonNetwork.JoinRandomRoom();
	}
	void OnPhotonRandomJoinFailed(){
		Debug.Log("OnPhotonRandomJoinFailed");
		PhotonNetwork.CreateRoom(null);
	}
	void OnJoinedRoom(){
		Debug.Log("OnJoinedRoom");
		SpawnPlayer();
	}
	void SpawnPlayer(){
		SpawnSpot mySpawnSpot = spawnSpots[Random.Range(0, spawnSpots.Length)];
		GameObject myPlayerGO;
		if(PhotonNetwork.countOfPlayersInRooms==0)
			{
				myPlayerGO = PhotonNetwork.Instantiate("PlayerController",mySpawnSpot.transform.position,mySpawnSpot.transform.rotation,0);
			}
			else 
			{
				myPlayerGO = PhotonNetwork.Instantiate("PlayerController2",mySpawnSpot.transform.position,mySpawnSpot.transform.rotation,0);
			}
		standbyCamera.gameObject.SetActive(false);
		((MonoBehaviour)myPlayerGO.GetComponent("MouseLook")).enabled=true;
		((MonoBehaviour)myPlayerGO.GetComponent("BotControlScript")).enabled=true;
		myPlayerGO.transform.FindChild("Main Camera").gameObject.SetActive(true);
	}
}
