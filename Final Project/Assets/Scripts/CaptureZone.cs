using UnityEngine;
using System.Collections;

public class CaptureZone : MonoBehaviour {

    public float captureTime = 3.0f;
    private float nextCapture = 0.0f;
    public int team1 = 0;
    public int team2 = 0;

    void Update()
    {
        if (team1 > team2 && Time.time > nextCapture)
        {
            nextCapture = Time.time + captureTime;
            this.GetComponent<CaptureLogic>().team1Point();
        }

        if (team1 < team2 && Time.time > nextCapture)
        {
            nextCapture = Time.time + captureTime;
            this.GetComponent<CaptureLogic>().team2Point();
        }
     
    }

    void OnTriggerEnter(Collider obj)
    {
        if (obj.tag == "Player1")
        {
            team1++;
        }

        if (obj.tag == "Player2")
        {
            team2++;
        }
    }

    void OnTriggerExit(Collider obj)
    {
        if (obj.tag == "Player1")
        {
            team1--;
        }

        if (obj.tag == "Player2")
        {
            team2--;
        }
    }

}
