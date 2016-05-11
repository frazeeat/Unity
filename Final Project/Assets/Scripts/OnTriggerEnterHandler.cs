using UnityEngine;
using System.Collections;

public class OnTriggerEnterHandler : MonoBehaviour {

	// Use this for initialization
    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player1")
        {
            other.GetComponent<SelectUnit>().Select();
        }
    }
}
