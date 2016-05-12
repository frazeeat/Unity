using UnityEngine;
using System.Collections;
using Photon;

public class MatchMaker : Photon.PunBehaviour
{
    private bool spawned = false;

    // Use this for initialization
    void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
        
        //PhotonNetwork.logLevel = PhotonLogLevel.Full;
    }

    // Update is called once per frame
    void Update()
    {
        if (!spawned)
        {
            if (PhotonNetwork.playerList.Length == 2)
            {
                spawnPlayer();
                spawned = true;
            }
        }
    }
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
        RoomOptions room = new RoomOptions();
        room.maxPlayers = 2;
        Debug.Log("Can't join random room!");
        PhotonNetwork.CreateRoom(null,room, TypedLobby.Default);
    }
    public override void OnJoinedRoom()
    {
        if (PhotonNetwork.playerList.Length == 2)
        {
            spawnPlayer();
            turnOffCam();
        }

        Debug.Log("On joined Room ran");
    }
    void spawnPlayer()
    {
        Quaternion rot = Quaternion.identity;
        rot.eulerAngles = new Vector3(90, 0, 0);

        GameObject camera = PhotonNetwork.Instantiate("Main Camera", new Vector3(0, 20, 0), rot, 0);
        camera.GetComponent<Camera>().enabled = true;
    }
    [PunRPC]
    void turnOffCam()
    {
        GameObject.FindGameObjectWithTag("loadingcam").SetActive(false);
    }
}
