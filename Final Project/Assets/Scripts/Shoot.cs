using UnityEngine;
using System.Collections;

public class Shoot : MonoBehaviour {
    int shoot = 0;
    public GameObject projectile;
	// Update is called once per frame
	void Update () {
        if ( shoot == 0)
        {
            GameObject[] enemies = GameObject.FindGameObjectsWithTag("Player1");
            if (enemies.Length != 0)
            {
                GameObject target = GetClosestEnemy(enemies);
                if (Vector3.Distance(target.transform.position, this.transform.position) < 10.0f)
                {
                    this.transform.Rotate(new Vector3(0.0f,1.0f,0.0f),15.0f);
                    GameObject clone = Instantiate(projectile, this.transform.forward + transform.position, this.transform.rotation) as GameObject;
                    clone.GetComponent<Rigidbody>().velocity = (this.transform.forward);
                    clone.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone, 10.0f);
                    GameObject clone1 = Instantiate(projectile, this.transform.right + transform.position, this.transform.rotation) as GameObject;
                    clone1.GetComponent<Rigidbody>().velocity = (this.transform.right);
                    clone1.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone1, 10.0f);
                    GameObject clone2 = Instantiate(projectile, -this.transform.right + transform.position, this.transform.rotation) as GameObject;
                    clone2.GetComponent<Rigidbody>().velocity = (-this.transform.right);
                    clone2.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone2, 10.0f);
                    GameObject clone3 = Instantiate(projectile, -this.transform.forward + transform.position, this.transform.rotation) as GameObject;
                    clone3.GetComponent<Rigidbody>().velocity = (-this.transform.forward);
                    clone3.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone3, 10.0f);
                    GameObject clone4 = Instantiate(projectile, (this.transform.forward + this.transform.right)/2.0f + transform.position, this.transform.rotation) as GameObject;
                    clone4.GetComponent<Rigidbody>().velocity = ((this.transform.forward + this.transform.right) / 2.0f);
                    clone4.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone4, 10.0f);
                    GameObject clone5 = Instantiate(projectile, (-this.transform.forward + this.transform.right) / 2.0f + transform.position, this.transform.rotation) as GameObject;
                    clone5.GetComponent<Rigidbody>().velocity = ((-this.transform.forward + this.transform.right) / 2.0f);
                    clone5.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone5, 10.0f);
                    GameObject clone6 = Instantiate(projectile, (this.transform.forward + -this.transform.right) / 2.0f + transform.position, this.transform.rotation) as GameObject;
                    clone6.GetComponent<Rigidbody>().velocity = ((this.transform.forward + -this.transform.right) / 2.0f);
                    clone6.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone6, 10.0f);
                    GameObject clone7 = Instantiate(projectile, (-this.transform.forward + -this.transform.right) / 2.0f + transform.position, this.transform.rotation) as GameObject;
                    clone7.GetComponent<Rigidbody>().velocity = ((-this.transform.forward + -this.transform.right) / 2.0f);
                    clone7.GetComponent<OnHit1>().damage = this.GetComponent<AttackStats>().damage;
                    Destroy(clone7, 10.0f);
                }
            }
        }
        shoot++;
        if (shoot == 100 * GetComponent<AttackStats>().attackspeed)
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
