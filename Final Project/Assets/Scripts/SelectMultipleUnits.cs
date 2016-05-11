using UnityEngine;
using System.Collections;

public class SelectMultipleUnits : MonoBehaviour {
    Vector3 firstPosition, secondPosition;
    private Camera cam;
    bool isMouseDown = false;
    GameObject select;
    public GameObject objectToSelect;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Camera>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 10.0f, false);

            if (Physics.Raycast(ray, out hit))
            {
                firstPosition = hit.point;
                objectToSelect.transform.position = firstPosition;
                objectToSelect.transform.localScale = new Vector3(0.0f, 0.0f, 0.0f);
                select = Instantiate(objectToSelect);
                
            }
            isMouseDown = true;

        }
        if (isMouseDown)
        {
            RaycastHit hit;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            Debug.DrawRay(ray.origin, ray.direction * 10, Color.green, 10.0f, false);

            if (Physics.Raycast(ray, out hit))
            {
                secondPosition = hit.point;
                Vector3 topLeft = new Vector3(firstPosition.x, firstPosition.y, secondPosition.z);
                Vector3 betweenz = topLeft - firstPosition;
                Vector3 betweenx = topLeft - secondPosition;
                float distancez = betweenz.magnitude;
                float distancex = betweenx.magnitude;
                select.transform.localScale = new Vector3(distancex, 10.0f,distancez)/10.0f;
                select.transform.position = firstPosition + new Vector3(-(betweenx.x / 2.0f),1.5f,(betweenz.z/2.0f));
            
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            isMouseDown = false;
            Destroy(select.gameObject);

        }
	}
}
