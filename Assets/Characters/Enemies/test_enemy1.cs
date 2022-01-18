using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test_enemy1 : EnemyStats
{
	private Transform target;
	//*dodane
	private float i=-4000;
	public GameObject Ammo;
	public GameObject BigAmmo;
	private Rigidbody rb;
	private bool Escape;
	private float j;
	
	void Start()
	{
	rb=GetComponent<Rigidbody>();
	target=GameObject.FindWithTag("Player").transform;	
	}
   
	//*zmiana
    public override void Update()
    {
	//*dodane	
	base.Update();
    //zauwaza gracza
	if (Vector3.Distance(transform.position, target.position)<30f&&Vector3.Distance(transform.position, target.position)>10f)
		{
		Vector3 targetDirection=(target.position+new Vector3(0,1f,0))-transform.position;
		targetDirection=new Vector3 (targetDirection.x,transform.position.y,targetDirection.z);
		Vector3 newDirection=Vector3.RotateTowards(transform.forward, targetDirection, RotationSpeed.GetValue()*Time.deltaTime, 0f);	
		transform.localRotation=Quaternion.LookRotation(newDirection);
		
		//* dodane
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
		}
	//ucieka przed graczem
	if (Vector3.Distance(transform.position, target.position)<10f)
		{
		Escape=true;
		j=0;
		}
		
	if (Escape)
		{
		Vector3 targetDirection=transform.position-(target.position+new Vector3(0,1f,0));
		targetDirection=new Vector3 (targetDirection.x,transform.position.y,targetDirection.z);	
		Vector3 newDirection=Vector3.RotateTowards(transform.forward, targetDirection, RotationSpeed.GetValue()*Time.deltaTime, 0f);	
		transform.localRotation=Quaternion.LookRotation(newDirection);
		//* dodane
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
		rb.velocity=transform.forward*Speed.GetValue()*Time.deltaTime;	
		}		
    }
	
	//*zmiana
	public override void FixedUpdate()
	{
	//*dodane
	base.FixedUpdate();	
	if (Escape)
		{
		j++;
		if (j>100)
			{
			Escape=false;
			//*dodane
			i=-4000;		
			}			
		}

	Vector3 onTarget=(target.position+new Vector3(0,1f,0))-transform.position;
	RaycastHit onMark;
	Debug.DrawRay(transform.position, onTarget,Color.red, 0.2f);
	if (Physics.Raycast(transform.position, onTarget, out onMark, 30f,1,QueryTriggerInteraction.Ignore))
		{
		if (onMark.collider.tag=="Player"&&!Escape)
			{
			i+=AttackSpeed.GetValue();
			Vector3 pociskPozycja=transform.position+transform.forward*1.4f;
			if (i>=250&&currentEnergy>=Energy.GetValue())
				{
				var pocisk=Instantiate(BigAmmo, pociskPozycja, Quaternion.LookRotation(onTarget));
				pocisk.GetComponent<Ammo>().Target="Player";
				pocisk.GetComponent<Ammo>().Damage=AttackStrength.GetValue()*3f;
				currentEnergy=0;
				}
			if (i>=500)
				{
				var pocisk=Instantiate(Ammo, pociskPozycja, Quaternion.LookRotation(onTarget));
				pocisk.GetComponent<Ammo>().Target="Player";
				pocisk.GetComponent<Ammo>().Damage=AttackStrength.GetValue();
				i=0;
				}
			} else
				{
				i=-4000;	
				}
		}
	}
}
