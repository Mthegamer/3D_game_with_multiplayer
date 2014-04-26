using UnityEngine;
using System.Collections;

public class axe_swing : MonoBehaviour {
	public GameObject axe;
	int[] numbers = {1,2};
	int b;

	// Use this for initialization
	void Start () {
	
	}
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(1))
			if(!axe.animation.isPlaying)
		{	b=Random.Range(0, numbers.Length);
			if(b==0)axe.animation.Play("axe_swing");
			else if(b==1)axe.animation.Play("axe_swing2");}
	}
}
