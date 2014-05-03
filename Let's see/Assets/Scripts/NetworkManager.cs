using UnityEngine;
using System.Collections;

public class NetworkManager : MonoBehaviour {
	public Camera standbyCamera;
	SpawnSpot[] spawnSpots;
	bool executed=false;
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
	void OnLevelWasLoaded(int level)
	{
		if(level==2)if(PhotonNetwork.isMasterClient)
		{
			if(!executed){
			spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
			foreach(SpawnSpot a in spawnSpots)
			{
				PhotonNetwork.Instantiate("Enemy",a.transform.position,a.transform.rotation,0);
			}
		//	PhotonNetwork.Instantiate("flashlight",new Vector3(-0.087f,0.2734f,16.648f), new Quaternion(0f,18f,0f,0),0);
			PhotonNetwork.Instantiate("Axe_climbing",new Vector3(3.295f,0.169f,16.24f), new Quaternion(0f,333.9846f,90f,0),0);
			executed=true;
			}
			else executed=false;

		}
		if(level==3)if(PhotonNetwork.isMasterClient)
		{
			if(!executed){
			spawnSpots = GameObject.FindObjectsOfType<SpawnSpot>();
			foreach(SpawnSpot a in spawnSpots)
			{
				PhotonNetwork.Instantiate("Enemy",a.transform.position,a.transform.rotation,0);
			}
			//	PhotonNetwork.Instantiate("flashlight",new Vector3(-0.087f,0.2734f,16.648f), new Quaternion(0f,18f,0f,0),0);
			//PhotonNetwork.Instantiate("Axe_climbing",new Vector3(3.295f,0.169f,16.24f), new Quaternion(0f,333.9846f,90f,0),0);
				executed=true;
			}
			else executed=false;
	}
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
