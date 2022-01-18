using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : CharacterStats
{
	
	//*zmiana
    public virtual void Update()
    {
    if (currentHealth<0)
		{
		Destroy(gameObject);
		}
    }
	
	//*zmiana
	public virtual void FixedUpdate()
	{
	if (currentEnergy<Energy.GetValue())
		{
		currentEnergy++;	
		}		
	}
}
