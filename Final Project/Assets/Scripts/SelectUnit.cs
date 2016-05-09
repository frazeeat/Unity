using UnityEngine;
using System.Collections;

public class SelectUnit : MonoBehaviour {
    public GameObject selected;
    public bool isSelected = false;
    GameObject clone;

    
  //  void OnMouseDown() {
  //      if (!isSelected)
  //      {
  //          Select();
  //      }
  //  }

    public void Select()
    {
        clone = Instantiate(selected) as GameObject;
        clone.transform.parent = gameObject.transform;
        clone.transform.position = gameObject.transform.position;
        isSelected = true;
        //GetComponent<MoveUnit>().isSelected = true;
        //GetComponent<MoveUnit>().goAhead = true;
    }
    public void Deselect()
    {
        Destroy(clone);
        isSelected = false;
    }
}
