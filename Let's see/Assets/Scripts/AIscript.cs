using UnityEngine;
using System.Collections;

public class AIscript : MonoBehaviour {
	float distance;
	public GameObject[] target;
	float nearestDist=Mathf.Infinity;
	Transform nearestObj;
	Vector3 objpos;
	float distance1;

	public float lookRange= 20f;
	public float chaseRange =15f;
	public float attackRange=2f;
	public float movespeed = 5f;
	float damping = 6f;
	public CharacterController controller;
	float gravity=20f;
	private Vector3 moveDirection= Vector3.zero;
	public GameObject body;
	public AudioClip[] sounds;

	private float attackTime;
	float attackRepeatTime=1;
	// Use this for initialization
	void Start () {
		attackTime=Time.time;
	}
	
	// Update is called once per frame
	void Update () {
		target = GameObject.FindGameObjectsWithTag("Player");
			//FindGameObjectsWithTag(Player);
			//FindObjectsOfType<BotControlScript>();
		foreach(GameObject a in target)
		{
			objpos=a.transform.position;
			distance1=(objpos-transform.position).sqrMagnitude;
			if(distance1<nearestDist)
			{
				nearestObj=a.transform;
				nearestDist=distance1;
			}
		}
		 
		
			if(gameObject.GetComponent<enemy_health>().health >0)
		{
			distance=Vector3.Distance(nearestObj.position,transform.position);

		if(distance < lookRange)
		{
			lookat();
		}
		if(distance > lookRange)
		{
			body.animation.Play("waitingforbattle");
		}
		if(distance < attackRange)
		{
			attack();
		}
		else if(distance<chaseRange)
		{
			chase();
		}
		
		}
	
	}
	void lookat()
	{
		renderer.material.color=Color.yellow;
		Quaternion rotation= Quaternion.LookRotation(nearestObj.position-transform.position);

		transform.rotation=Quaternion.Slerp(transform.rotation,rotation,Time.deltaTime * damping);
	}
	void chase()
	{
		audio.clip=sounds[0];
		if(!audio.isPlaying)audio.Play();
		//audio.Play();
		renderer.material.color=Color.red;
		moveDirection=transform.forward;
		moveDirection*=movespeed;
		moveDirection.y-=gravity*Time.deltaTime;
		controller.Move(moveDirection*Time.deltaTime);
		body.animation.Play("run");

	}
	void attack()
	{
		if(!body.animation.isPlaying){
		if(Time.time>attackTime)
		{
			audio.clip=sounds[1];
			if(!audio.isPlaying)audio.Play();
			body.animation["attack"].wrapMode=WrapMode.Once;
			body.animation.Play ("attack");
			attackTime=Time.time + attackRepeatTime;
			}}
	}
}
