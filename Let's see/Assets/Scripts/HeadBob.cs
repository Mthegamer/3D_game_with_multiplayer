using UnityEngine;
using System.Collections;

public class HeadBob : MonoBehaviour {
	private float timer = 0.0f;
	float bobbingSpeed = 0.18f;
	float bobbingAmount = 0.2f;
	float midpoint = 2.0f;
	float waveslice;
	float horizontal;
	float vertical;
	float totalAxes;
	float translateChange;
	 
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		waveslice=0.0f;
		horizontal = Input.GetAxis("Horizontal");
		vertical = Input.GetAxis("Vertical");
		Vector3 cSharpConversion = transform.localPosition; 
		if(Mathf.Abs(horizontal)==0 && Mathf.Abs(vertical) ==0){
			timer = 0.0f;
		}
		else {
			waveslice = Mathf.Sin(timer);
			timer=timer + bobbingSpeed;
			if(timer>Mathf.PI*2)timer = timer - (Mathf.PI*2);
		}
		if (waveslice != 0) { 
		      translateChange = waveslice * bobbingAmount; 
		      totalAxes = Mathf.Abs(horizontal) + Mathf.Abs(vertical); 
		      totalAxes = Mathf.Clamp (totalAxes, 0.0f, 1.0f); 
		      translateChange = totalAxes * translateChange; 
		      cSharpConversion.y = midpoint + translateChange; 
		   } 
		   else { 
		       cSharpConversion.y = midpoint;
		   }
		 transform.localPosition = cSharpConversion;
	}
}