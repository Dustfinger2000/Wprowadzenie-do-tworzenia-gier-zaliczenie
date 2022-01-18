using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ammo : MonoBehaviour
{
    public float ProjectileSpeed;
	public float Damage;
	public string Target;
	public int lifeExpectancy;
	private int i;
	private Rigidbody rb;
	
	void Start()
	{
	rb=GetComponent<Rigidbody>();	
	}
	
    // Update is called once per frame
    void Update()
    {
    rb.velocity=transform.forward*ProjectileSpeed*Time.deltaTime;
    }
	
	void OnTriggerEnter(Collider Hit)
	{
	if (Hit.tag==Target)
		{
		Hit.gameObject.GetComponent<CharacterStats>().isHit(Damage);
		HitEffect();
		}
		
	//*dodane	
	if (Hit.isTrigger==false)
		{
		Destroy(gameObject);	
		}
	}
	
	void FixedUpdate()
	{
	i++;
	if (i>lifeExpectancy)
		{
		Destroy(gameObject);	
		}
	}
	
	public virtual void HitEffect()
	{
		
	}
}
