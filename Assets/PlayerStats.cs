using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : CharacterStats
{
	void Update()
	{
	if (currentHealth<0)
		{
		UImanager.instance.DeathScreen.enabled=true;	
		Time.timeScale=0;
		}		
	}
	
	public override void isHit(float Damage)
	{
	if (Damage-Armor.GetValue()>0)
		{
		currentHealth=currentHealth-(Damage-Armor.GetValue());
		}		
	}
}
