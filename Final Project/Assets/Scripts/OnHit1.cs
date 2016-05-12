using UnityEngine;
using System.Collections;

public class OnHit1 : MonoBehaviour {
    public float damage = 1.0f;
	void OnTriggerEnter(Collider collider){
        if (collider.gameObject.tag == "Player1")
        {
            collider.GetComponent<BaseStats>().health = collider.GetComponent<BaseStats>().health - damage;
            Destroy(this.gameObject);
        }
    }
}
