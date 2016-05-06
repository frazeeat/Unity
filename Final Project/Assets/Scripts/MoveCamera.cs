using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public float speed = 5.0f;
	
	// Update is called once per frame
	void Update () {

        if (Input.mousePosition.x < 2 && gameObject.transform.position.x > -38.0f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        else if (Input.mousePosition.x > Screen.width - 2 && gameObject.transform.position.x < 38.0f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        if (Input.mousePosition.y < 2 && gameObject.transform.position.z > -38.0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
        else if (Input.mousePosition.y > Screen.height - 2 && gameObject.transform.position.z < 38.0f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

        }
	}
}
