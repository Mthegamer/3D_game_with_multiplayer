using UnityEngine;
using System.Collections;

public class NetworkController : Photon.MonoBehaviour {

	Vector3 RealPosition = Vector3.zero;
	Quaternion RealRotation = Quaternion.identity;
	Animator anim;
	public int health=100;
	// Use this for initialization
	void Start () {
		DontDestroyOnLoad(this);
		anim=GetComponent<Animator>();
	}
	// Update is called once per frame
	void Update () {
		if(photonView.isMine)
			{
				//do nothing
			}
		else {
			transform.position=Vector3.Lerp(transform.position,RealPosition, 0.1f);
			transform.rotation=Quaternion.Lerp(transform.rotation,RealRotation, 0.1f);
			}
	}
	void OnLevelWasLoaded(int level) {
		if (level == 2)
		{
			if(PhotonNetwork.isMasterClient)transform.position= new Vector3(-1.325348f,3.4429392f,24.69591f);
			else transform.position=new Vector3(4.5444218f,3.4429392f,24.69591f);
		}
		
	}
	public void OnPhotonSerializeView( PhotonStream stream, PhotonMessageInfo info){
		if(stream.isWriting)
		{
			stream.SendNext(transform.position);
			stream.SendNext(transform.rotation);
			stream.SendNext(anim.GetFloat("Speed"));
			stream.SendNext(anim.GetFloat("Direction"));
			stream.SendNext(anim.GetFloat("ColliderHeight"));
			stream.SendNext(anim.GetBool("Jump"));
		}
		else
		{
			RealPosition=(Vector3)stream.ReceiveNext();
			RealRotation=(Quaternion)stream.ReceiveNext();
			anim.SetFloat("Speed",(float)stream.ReceiveNext());
			anim.SetFloat("Direction",(float)stream.ReceiveNext());
			anim.SetFloat("ColliderHeight",(float)stream.ReceiveNext());
			anim.SetBool("Jump",(bool)stream.ReceiveNext());
		}
	}
}
