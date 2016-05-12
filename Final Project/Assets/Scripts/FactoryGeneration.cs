using UnityEngine;
using System.Collections;

public class FactoryGeneration : MonoBehaviour {

    public int partsForFactory = 4;
    public Camera cam;
    public GameObject factory;
    private int spareParts = 0;
    Vector3 position = new Vector3(0.0f,0.0f,0.0f);


    void Update()
    {
        if (Input.GetKeyDown("b"))
        {
            buildFactory();
        }
    }

    void buildFactory()
    {
        if (spareParts >= partsForFactory)
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                position = hit.point;
            }
                spareParts = spareParts - partsForFactory;
            GameObject g = Instantiate(factory, position, transform.rotation) as GameObject;

        }
    }

    void getSpareParts()
    {
        spareParts++;
    }
}
