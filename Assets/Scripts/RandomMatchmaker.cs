using UnityEngine;
using System.Collections;

public class RandomMatchmaker : MonoBehaviour{

	// Use this for initialization
	void Start () {

		PhotonNetwork.ConnectUsingSettings ("0.1");
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log(PhotonNetwork.connectionStateDetailed.ToString ());
	}
	
	void OnJoinedLobby() {
		PhotonNetwork.JoinRandomRoom ();
	}

	void OnPhotonRandomJoinFailed() {
		Debug.Log ("Can't join random room!");
		PhotonNetwork.CreateRoom (null);
	}

	void OnJoinedRoom(){
		GameObject player = PhotonNetwork.Instantiate ("Player1", Vector3.zero, Quaternion.identity,0);
	}

	void OnPhotonSerializeView(PhotonStream stream, PhotonMessageInfo info)
	{
		if (stream.isWriting)
			stream.SendNext(GetComponent<Rigidbody>().transform.position);
		else
			GetComponent<Rigidbody>().transform.position = (Vector3)stream.ReceiveNext();
	}

}
