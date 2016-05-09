using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    Vector3 newPosition;
    public GameObject projectile;

    int shoot = 0;

    public bool goAhead = false;
    public bool isSelected = false;

    bool isAttacking = true;
    bool isAttackMove = false;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
        //player = GameObject.FindGameObjectWithTag("MainCamera");
        newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        //Move without Attacking
        if (Input.GetKey(KeyCode.Mouse1) && IsSelected())
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
            }
            agent.SetDestination(newPosition);
            isAttacking = false;
            isAttackMove = false;
        }
        //???
        /*
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isSelected && goAhead)
        {
            isSelected = true;
            isAttacking = true;
        }
         */
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsSelected() && !isAttackMove)
        {
            isSelected = false;
            GetComponent<SelectUnit>().Deselect();
            goAhead = false;
            isAttacking = true;
        }
        if (Input.GetKeyDown(KeyCode.A) && IsSelected())
        {
            isAttackMove = true;
        }
        if (Input.GetKeyDown(KeyCode.Mouse0) && IsSelected() && isAttackMove)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
            }
            agent.SetDestination(newPosition);
            isAttacking = true;
            isAttackMove = false;
        }
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
                    clone.GetComponent<OnHit>().damage = this.GetComponent<Stats>().damage;
                    Destroy(clone, 10.0f);
                }
            }
        }
        
        shoot++;
        float speed = GetComponent<Stats>().attackspeed;
        if (shoot == 100*speed)
            shoot = 0;
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
    void Shoot(GameObject target)
    {

    }
    bool IsSelected()
    {
        return GetComponent<SelectUnit>().isSelected;
    }
}
