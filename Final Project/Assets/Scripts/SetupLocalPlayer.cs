using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class SetupLocalPlayer : NetworkBehaviour {

	// Use this for initialization
	void Start () {
        Camera cam = gameObject.GetComponent<Camera>();
        if (isLocalPlayer)
        {
            
            cam.enabled = true;
            gameObject.transform.position = new Vector3(0, 20, 0);
            gameObject.transform.Rotate(-Vector3.left,90.0f);
            GetComponent<SelectMultipleUnits>().enabled = true;
            GetComponent<MoveCamera>().enabled = true;
        }
        else
        {
            gameObject.transform.position = new Vector3(0, 20, 0);
            gameObject.transform.Rotate(-Vector3.left, 90.0f);
            cam.enabled = false;
        }
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
