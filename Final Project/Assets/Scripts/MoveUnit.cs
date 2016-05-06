using UnityEngine;
using System.Collections;

public class MoveUnit : MonoBehaviour {

    NavMeshAgent agent;
    GameObject player;
    Vector3 newPosition;

    public bool goAhead = false;
	// Use this for initialization
    public bool isSelected = false;
	void Start () {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("MainCamera");
        newPosition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKey(KeyCode.Mouse1) && isSelected)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                newPosition = hit.point;
            }
            agent.SetDestination(newPosition);
        }
        if (Input.GetKeyUp(KeyCode.Mouse0) && !isSelected && goAhead)
        {
            isSelected = true;
        }
        else if (Input.GetKeyUp(KeyCode.Mouse0) && isSelected)
        {
            isSelected = false;
            GetComponent<SelectUnit>().Deselect();
            goAhead = false;
        }

	}
}
