using UnityEngine;
using System.Collections;

public class MatchMaker : MonoBehaviour {

	// Use this for initialization
	void Start () {
        PhotonNetwork.ConnectUsingSettings("0.1");
	}
	
	// Update is called once per frame
    void onGUI()
    {
        GUILayout.Label(PhotonNetwork.connectionStateDetailed.ToString());
    }
}
