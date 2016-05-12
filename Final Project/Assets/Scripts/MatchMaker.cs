using UnityEngine;
using System.Collections;
using Photon;

public class MatchMaker : Photon.PunBehaviour
{

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
    }
	
	// Update is called once per frame
    void onGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }

    public override void OnJoinedLobby()
    {
        PhotonNetwork.JoinRandomRoom();
    }
    void OnPhotonRandomJoinFailed()
    {
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null);
    }
    public override void OnJoinedRoom()
    {
        Quaternion rot= Quaternion.identity;
        rot.eulerAngles = new Vector3(90, 0, 0);

        GameObject camera = PhotonNetwork.Instantiate("Main Camera", new Vector3(0,20,0), rot, 0);
        //camera.transform.Rotate(-Vector3.left, 90.0f);
        //camera.transform.position = new Vector3(0, 20, 0);
        camera.GetComponent<Camera>().enabled = true;

        GameObject monster = PhotonNetwork.Instantiate("Unit", Vector3.zero, Quaternion.identity, 0);
        monster.GetComponent<MoveUnit>().enabled = true;

        Debug.Log("On joined Room ran");
    }
}
