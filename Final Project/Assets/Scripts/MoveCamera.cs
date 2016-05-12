using UnityEngine;
using System.Collections;

public class MoveCamera : MonoBehaviour {

    public float speed = 5.0f;
     float minFov= 15f;
    float maxFov= 90f;
    float sensitivity= 10f;
	
	// Update is called once per frame
	void Update () {

           float fov = Camera.main.fieldOfView;
   fov -= Input.GetAxis("Mouse ScrollWheel") * sensitivity;
   fov = Mathf.Clamp(fov, minFov, maxFov);
   Camera.main.fieldOfView = fov;

        if (Input.mousePosition.x < 2 && gameObject.transform.position.x > -45.0f)
        {
            transform.Translate(Vector3.left * Time.deltaTime * speed);

        }
        else if (Input.mousePosition.x > Screen.width - 2 && gameObject.transform.position.x < 45.0f)
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);

        }
        if (Input.mousePosition.y < 2 && gameObject.transform.position.z > -45.0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime * speed);

        }
        else if (Input.mousePosition.y > Screen.height - 2 && gameObject.transform.position.z < 45.0f)
        {
            transform.Translate(Vector3.up * Time.deltaTime * speed);

        }
	}
}
