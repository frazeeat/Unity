using UnityEngine;
using Photon;
using System.Collections;

public class FUCK : Photon.PunBehaviour
{

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	    if (Input.GetKeyDown("h")){
            CmdSpawn();
        }
	}

    [PunRPC]
    public void CmdSpawn()
    {
        //GameObject go = (GameObject)Instantiate(g) as GameObject;
        GameObject monster = PhotonNetwork.Instantiate("Unit", Vector3.zero, Quaternion.identity, 0);
    }
}
