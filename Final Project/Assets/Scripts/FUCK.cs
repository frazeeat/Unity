using UnityEngine;
using UnityEngine.Networking;
using System.Collections;

public class FUCK : NetworkBehaviour {

    public GameObject g;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("h")){
            CmdSpawn();
        }
	}

    [Command]
    public void CmdSpawn()
    {
        GameObject go = (GameObject)Instantiate(g) as GameObject;
        NetworkServer.SpawnWithClientAuthority(go, connectionToClient);
    }
}
