using UnityEngine;
using System.Collections;

public class CaptureLogic : MonoBehaviour {

    private int ownership = 0;
    private bool player1Owns = true;
    private bool player2Owns = true;

    // Update is called once per frame
    /*void Update () {
	
	}*/

    void team1Point()
    {
        if (ownership < 1)
            ownership++;
    }

    void team2Point()
    {
        if (ownership > -1)
            ownership--;
    }



}
