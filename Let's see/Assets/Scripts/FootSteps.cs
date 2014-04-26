using UnityEngine;
using System.Collections;


public class FootSteps : MonoBehaviour {
	
	public AudioClip walk;
	public GameObject player;
	bool isWalking = false;
	float walkAudioSpeed  = 0.70f;
	private float walkAudioTimer  = 0.0f;
	private BotControlScript chCtrl;

	void Start () {
		chCtrl= player.GetComponent<BotControlScript>();
	}
	// Update is called once per frame
	void Update () {
	    if ( chCtrl.hitInfo.distance<1.7f )
		    {
		        PlayFootsteps();
		    }
	    else
		    {
		        walkAudioTimer = 0.0f;
		    }
	}
	void PlayFootsteps()
	{
	    if ( Input.GetAxis( "Horizontal" )!= 0 || Input.GetAxis( "Vertical" )!= 0 )
	    {
	         isWalking = true;
	    }
	    else
	    {
	       // Stopped
	       isWalking = false;
	    }
	    // Play Audio
	    if ( isWalking )
	    {
	       if ( audio.clip != walk )
	       {
	         audio.Stop();
	         audio.clip = walk;
	       }
	 
	       //if ( !audio.isPlaying )
	       if ( walkAudioTimer > walkAudioSpeed )
	       {
	         audio.Stop();
	         audio.Play();
	         walkAudioTimer = 0.0f;
	       }
	    }
	    else
	    {
	       audio.Stop();
	    }
	    // increment timers
	    walkAudioTimer += Time.deltaTime;
	}
}