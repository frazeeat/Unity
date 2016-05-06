﻿using UnityEngine;
using System.Collections;

public class SelectMultipleUnits : MonoBehaviour {
    Vector3 firstPosition, secondPosition;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                firstPosition = hit.point;
            }

        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                secondPosition = hit.point;
            }
            RaycastHit[] hits;
            hits = Physics.CapsuleCastAll(firstPosition, secondPosition, 1.0f, transform.forward, 10);
            for (int i = 0; i < hits.Length; i++)
            {
                RaycastHit hit2 = hits[i];
                if (hit2.collider.tag == "Unit")
                {
                    if (!hit2.collider.GetComponent<SelectUnit>().isSelected)
                    {
                        hit2.collider.GetComponent<SelectUnit>().Select();
                    }
                }
            }

        }
	}
}
