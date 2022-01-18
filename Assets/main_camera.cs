using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class main_camera : MonoBehaviour
{
	public Vector3 offset;
	public Vector2 cameraPosition;
	public float sensitivity;
	public Transform gracz;

    // Start is called before the first frame update
    void Start()
    {
	Cursor.lockState=CursorLockMode.Locked;	
    transform.position=gracz.position+offset;    
    }

    // Update is called once per frame
    void FixedUpdate()
    {
	Vector2 mouseMove=new Vector2(Input.GetAxis("Mouse X"),Input.GetAxis("Mouse Y"))*sensitivity;
	cameraPosition+=mouseMove;
	cameraPosition.y=Mathf.Clamp(cameraPosition.y,-70,70);
	Quaternion angle=Quaternion.Euler(-cameraPosition.y,cameraPosition.x,0);
	transform.position=gracz.position+angle*offset;

	transform.LookAt(gracz.position);
	}
}
