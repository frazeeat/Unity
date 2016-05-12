using UnityEngine;
using System.Collections;

public class UnitShoot : MonoBehaviour {

    int shoot = 0;
    public bool isAttacking = true;
    public GameObject projectile;

	// Update is called once per frame
	void Update () {
        if (isAttacking && shoot == 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player2");
            if (enemies.Length != 0)
            {
                GameObject target = GetClosestEnemy(enemies);
                if (Vector3.Distance(target.transform.position, this.transform.position) < 10.0f)
                {
                    transform.LookAt(target.transform);
                    GameObject clone = Instantiate(projectile, this.transform.forward + transform.position, this.transform.rotation) as GameObject;
                    clone.GetComponent<Rigidbody>().velocity = (this.transform.forward);
                    clone.GetComponent<OnHit>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone, 10.0f);
                }
            }
        }

        shoot++;
        float speed = GetComponent<AttackStats>().attackspeed;
        if (shoot == 100 * speed)
        {
            shoot = 0;
        }
	}
    GameObject GetClosestEnemy(GameObject[] enemies)
    {
        GameObject gMin = null;
        float minDist = Mathf.Infinity;
        Vector3 currentPos = transform.position;
        foreach (GameObject t in enemies)
        {
            float dist = Vector3.Distance(t.transform.position, currentPos);
            if (dist < minDist)
            {
                gMin = t;
                minDist = dist;
            }
        }
        return gMin;
    }
}
