using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamSlave : MonoBehaviour
{
	public Transform cam;
	public Transform player;
    // Update is called once per frame
    void Update()
    {
    transform.position=cam.transform.position;
    transform.rotation=Quaternion.Euler(player.eulerAngles.x,cam.eulerAngles.y,player.eulerAngles.z);
    }
}
