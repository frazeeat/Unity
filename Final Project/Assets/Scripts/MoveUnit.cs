using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    Vector3 newPosition;


    public bool goAhead = false;
    public bool isSelected = false;

    bool isAttackMove = false;

	void Start () {
        agent = GetComponent<NavMeshAgent>();
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
            isAttackMove = false;
        }

        if (Input.GetKeyDown(KeyCode.Mouse0) && IsSelected() && !isAttackMove)
        {
            isSelected = false;
            GetComponent<SelectUnit>().Deselect();
            goAhead = false;
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
            isAttackMove = false;
        }

	}
    bool IsSelected()
    {
        return GetComponent<SelectUnit>().isSelected;
    }
}
