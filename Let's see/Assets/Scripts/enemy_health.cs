using UnityEngine;
using System.Collections;

public class enemy_health : MonoBehaviour {

	public int health=100;
	public GameObject body;
	public AudioClip[] sounds;
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {
		if(health==0)die();
	}
	void takeDamage(int dmg)
	{
		audio.clip=sounds[0];
		if(!audio.isPlaying)audio.Play();
		body.animation["gethit"].wrapMode=WrapMode.Once;
		body.animation.Play ("gethit");
		health=health-dmg;

	}

	void die()
	{
		health=-1;
		audio.clip=sounds[1];
		if(!audio.isPlaying)audio.Play();
		body.animation["die"].wrapMode=WrapMode.Once;
		//PhotonNetwork.Destroy(gameObject);
		body.animation.Play("die");
		StartCoroutine(TestCoroutine());

	}
	IEnumerator TestCoroutine(){
		Debug.Log ("about to yield return WaitForSeconds(1)");
		yield return new WaitForSeconds(2);
		PhotonNetwork.Destroy(gameObject);
		//Destroy(gameObject);
		yield break;

	}
}
