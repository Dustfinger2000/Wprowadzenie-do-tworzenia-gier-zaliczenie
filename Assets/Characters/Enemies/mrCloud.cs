using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mrCloud : EnemyStats
{
	public Vector4 Sector;
	private bool Activate;
	private bool inProgress;
	private Transform player;
	private Vector3 StartPosition;
	private ParticleSystem aura;
	private Rigidbody rb;
	private float i;
	public Light lightning;
	private bool light;
	public Transform sphere;
	
    // Start is called before the first frame update
    void Start()
    {
    Activate=false;
	player=GameObject.FindWithTag("Player").transform;
	StartPosition=transform.position;
	aura=GetComponent<ParticleSystem>();
	rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    public override void Update()
    {
	base.Update();
	if (player.position.x>Sector.x&&player.position.x<Sector.z)
		{
		if (player.position.z>Sector.y&&player.position.z<Sector.w)
			{
			Activate=true;	
			} else Activate=false;
		} else Activate=false;
	
	if (!Activate)
		{
		transform.position=Vector3.MoveTowards(transform.position,StartPosition,Speed.GetValue()*Time.deltaTime);	
		}
		
	//aktywowany przeciwnik	
	if (Activate)
		{
		Vector3 targetDirection=(player.position+new Vector3(0,1f,0))-transform.position;
		targetDirection=new Vector3 (targetDirection.x,transform.position.y,targetDirection.z);
		Vector3 newDirection=Vector3.RotateTowards(transform.forward, targetDirection, RotationSpeed.GetValue()*Time.deltaTime, 0f);	
		transform.localRotation=Quaternion.LookRotation(newDirection);
		rb.velocity=transform.forward*Speed.GetValue()*Time.deltaTime;
		transform.localEulerAngles = new Vector3(0, transform.localEulerAngles.y, 0);
		if (Vector3.Distance(transform.position, player.position)<10f)
			{
			aura.Play();
			if (Vector3.Distance(transform.position, player.position)<5f)
				{
				i+=AttackSpeed.GetValue()*Time.deltaTime;
				if (i>100)
					{
					player.gameObject.GetComponent<CharacterStats>().isHit(AttackStrength.GetValue());
					i=0;
					}
				}
			
			if (currentEnergy>=Energy.GetValue())
				{
				sphere.gameObject.SetActive(true);	
				sphere.localScale+=new Vector3(0.75f,0.75f,0.75f)*Time.deltaTime;
				
				if (sphere.localScale.x>1.2f)
					{
					currentEnergy=0;
					lightning.enabled=true;
					light=true;
					player.gameObject.GetComponent<CharacterStats>().isHit(AttackStrength.GetValue()*10);
					sphere.localScale=new Vector3(0.1f,0.1f,0.1f);
					sphere.gameObject.SetActive(false);
					}
				}
			}else
				{
				aura.Stop();
				sphere.localScale=new Vector3(0.1f,0.1f,0.1f);
				sphere.gameObject.SetActive(false);	
				}
		}
    }
	
	public override void FixedUpdate()
	{
	base.FixedUpdate();
	if (light&&currentEnergy<8)
		{
		if (lightning.isActiveAndEnabled)
			{
			lightning.enabled=false;	
			} else lightning.enabled=true;
		} else light=false;
	}
}
