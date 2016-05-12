using UnityEngine;
using System.Collections;

public class SelectUnit : MonoBehaviour {
    public GameObject selected;
    public bool isSelected = false;
    GameObject clone;

    void Update()
    {
        if (Input.GetKeyDown("space")&& isSelected)
        {
            GameObject.Find("FactoryManager").BroadcastMessage("getSpareParts");
            Destroy(this.gameObject);
        }
    }

    public void Select()
    {
        if (!isSelected)
        {
            clone = Instantiate(selected) as GameObject;
            clone.transform.parent = gameObject.transform;
            clone.transform.position = gameObject.transform.position;
            isSelected = true;
        }
    }
    public void Deselect()
    {
        Destroy(clone);
        isSelected = false;
    }
}
