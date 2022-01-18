using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
	private float player_speed=300;
	private Rigidbody rb;
	private Transform target;
	private Vector3 move;
	private float rotateSpeed=180;
	public Transform cam;
	public Animator anim;
    
	// Start is called before the first frame update
    void Start()
    {
    rb=GetComponent<Rigidbody>();    
    }

    // Update is called once per frame
    void Update()
    {
	if (Input.GetKeyDown(KeyCode.C))
		{
		Inventory.instance.ItemsInInventory[0].UseItem();
		}
		
	rb.useGravity=true;	
	if (target==null)
		{
		Vector3 podlogaRaycast=transform.position+new Vector3(0,0.1f,0);	
		Vector3 sufitRaycast=transform.position+new Vector3(0,2.5f,0);	
		if (Physics.Raycast(sufitRaycast,transform.up, 0.3f)||Physics.Raycast(podlogaRaycast,-transform.up, 0.3f))
			{
			move=Input.GetAxis("Vertical")*player_speed*Time.deltaTime*cam.transform.forward+Input.GetAxis("Horizontal")*player_speed*Time.deltaTime*cam.transform.right;			
			if (Physics.Raycast(podlogaRaycast,transform.forward, 0.4f))
				{
				move+=Input.GetAxis("Climbing")*player_speed*Time.deltaTime*transform.up;
				rb.velocity=move;
				rb.useGravity=false;
				} else
					{
					Vector3 playerDirection=Vector3.RotateTowards(transform.forward, move, 2f*Time.deltaTime, 0.0f);
					transform.rotation=Quaternion.LookRotation(playerDirection);	
					rb.useGravity=true;
					rb.velocity=move+new Vector3(0,rb.velocity.y,0);
					}	
			} else if (Physics.Raycast(podlogaRaycast,transform.forward, 0.4f))
						{
						move=Input.GetAxis("Horizontal")*player_speed*Time.deltaTime*cam.transform.right+Input.GetAxis("Climbing")*player_speed*Time.deltaTime*transform.up;
						rb.velocity=move;
						rb.useGravity=false;
						}
			
			
		}else 
			{
			move=Input.GetAxis("Vertical")*player_speed*Time.deltaTime*transform.forward;
			transform.Rotate(0,Input.GetAxis("Horizontal")*rotateSpeed*Time.deltaTime,0);
			}
	anim.SetFloat("Walking", transform.InverseTransformDirection(rb.velocity).z);
	}
}
