using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

    public float health, attackspeed, damage;

	// Use this for initialization
	void Start () {
        health = 2.0f;
        attackspeed = 1.0f;
        damage = 1.0f;
	}
	
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
