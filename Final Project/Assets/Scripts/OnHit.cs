using UnityEngine;
using System.Collections;

public class OnHit : MonoBehaviour {
    public float damage = 1.0f;
	void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player2")
        {
            collider.GetComponent<Stats>().health = collider.GetComponent<Stats>().health - damage;
            Destroy(this.gameObject);
        }
    }
}
