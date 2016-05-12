using UnityEngine;
using System.Collections;

public class BaseStats : MonoBehaviour {

    public float health;
	
	// Update is called once per frame
	void Update () {
        if (health <= 0)
        {
            Die();
        }
	}
    void Die()
    {
        Destroy(this.gameObject);
    }
}
