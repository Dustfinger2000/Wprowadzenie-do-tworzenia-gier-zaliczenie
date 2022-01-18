using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
	public Stats Character;
	public Stat Health;
	public Stat Speed;
	public Stat RotationSpeed;
	public Stat Armor;
	public Stat AttackStrength;
	public Stat AttackSpeed;
	public Stat Energy;
	
	public float currentHealth;
	public float currentEnergy;
	
	void Awake()
	{
		Health.baseValue=Character.baseHealth;
		Speed.baseValue=Character.baseSpeed;
		RotationSpeed.baseValue=Character.baseRotationSpeed;
		Armor.baseValue=Character.baseArmor;
		AttackStrength.baseValue=Character.baseAttackStrength;
		AttackSpeed.baseValue=Character.baseAttackSpeed;
		Energy.baseValue=Character.baseEnergy;
			
		currentHealth=Health.GetValue();
		currentEnergy=Energy.GetValue();
	}
	
	public virtual void isHit(float Damage)
	{
		
	}
}
