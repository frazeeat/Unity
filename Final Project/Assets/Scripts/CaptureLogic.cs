using UnityEngine;
using System.Collections;

public class CaptureLogic : MonoBehaviour {

    public float spawnTimer = 5.0f;
    public GameObject ObjectToSpawn;
    public GameObject ObjectToSpawn2;
    private float nextSpawn = 0.0f;
    private int ownership = 0;


    void Update () {
        if (ownership>0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnTimer;
            GameObject g = Instantiate(ObjectToSpawn, transform.position, transform.rotation) as GameObject;
        }

        if (ownership<0 && Time.time > nextSpawn)
        {
            nextSpawn = Time.time + spawnTimer;
            GameObject g = Instantiate(ObjectToSpawn2, transform.position, transform.rotation) as GameObject;
        }
     
	}

   public void team1Point()
    {
        if (ownership < 1)
            ownership++;
    }

    public void team2Point()
    {
        if (ownership > -1)
            ownership--;
    }



}
