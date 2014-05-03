using UnityEngine;
using System.Collections;

public class axe_swing : MonoBehaviour {
	public GameObject axe;
	int[] numbers = {1,2};
	int b;
	float distance;
	public float maxdistance=1.5f;
	int damage =50;
	RaycastHit hit;
	public AudioClip sounds;

	void Update () {
		if (Input.GetMouseButtonDown(0))
		{
			if(!axe.animation.isPlaying)
			{	b=Random.Range(0, numbers.Length);
				if(b==0)axe.animation.Play("axe_swing");
				else if(b==1)axe.animation.Play("axe_swing2");
				audio.clip=sounds;
				audio.Play();
				if(Physics.SphereCast(transform.position,0.6f, transform.TransformDirection(Vector3.forward),out hit))
				{
					distance=hit.distance;
					if(distance < maxdistance)
					{
						hit.transform.SendMessage("takeDamage",damage,SendMessageOptions.DontRequireReceiver);
					}
				}
			}


		}
			
	}
}
