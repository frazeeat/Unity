using UnityEngine;
using System.Collections;

public class FactoryGeneration : MonoBehaviour {

    public int partsForFactory = 4;
    public GameObject factory;
    private int spareParts = 0;

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
            spareParts = spareParts - partsForFactory;
            GameObject g = Instantiate(factory, transform.position, transform.rotation) as GameObject;

        }
    }

    void getSpareParts()
    {
        spareParts++;
    }
}
