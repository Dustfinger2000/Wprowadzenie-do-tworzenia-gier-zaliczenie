using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EquipmentSystem : MonoBehaviour
{
	public static EquipmentSystem instance;
	
	public GameObject EquipmentSlot;
	public GameObject[] EquipmentUI;
	public PlayerStats Statistics;
	
	void Awake()
	{
		if (instance!=null)
		{
		Debug.Log("Więcej niż jedno inventory!");		
		}
		instance=this;
	}
	
	public Equipment[] currentEquipment;
	
	void Start()
	{
	int EquipmentSlots = System.Enum.GetNames(typeof(EquipmentType)).Length;
	currentEquipment=new Equipment[EquipmentSlots];
	}
	
	public void EquipItem(Equipment newItem)
	{
	int EquipmentSlotIndex=(int)newItem.Type;
	Equipment oldItem=null;
		if (currentEquipment[EquipmentSlotIndex]!=null)
			{
			oldItem=currentEquipment[EquipmentSlotIndex];
			Statistics.Health.RemoveModifier(oldItem.modifierHealth);
			Statistics.currentHealth-=oldItem.modifierHealth;
			if (Statistics.currentHealth<=0)
				{
				Statistics.currentHealth=1;
				}
			Statistics.Speed.RemoveModifier(oldItem.modifierSpeed);
			Statistics.Armor.RemoveModifier(oldItem.modifierArmor);
			Statistics.AttackStrength.RemoveModifier(oldItem.modifierAttackStrength);
			Statistics.AttackSpeed.RemoveModifier(oldItem.modifierAttackSpeed);
			Statistics.Energy.RemoveModifier(oldItem.modifierEnergy);
			Inventory.instance.AddItemToInventory(oldItem);
			}
	currentEquipment[EquipmentSlotIndex]=newItem;
	Statistics.Health.AddModifier(newItem.modifierHealth);
	Statistics.currentHealth+=newItem.modifierHealth;
	Statistics.Speed.AddModifier(newItem.modifierSpeed);
	Statistics.Armor.AddModifier(newItem.modifierArmor);
	Statistics.AttackStrength.AddModifier(newItem.modifierAttackStrength);
	Statistics.AttackSpeed.AddModifier(newItem.modifierAttackSpeed);
	Statistics.Energy.AddModifier(newItem.modifierEnergy);

	var EquipUI=Instantiate(EquipmentSlot,EquipmentUI[EquipmentSlotIndex].transform);
	EquipUI.GetComponent<EquipmentSlot>().item=newItem;
	}
	
	public void UnequipItem(Equipment oldItem)
	{
	int EquipmentSlotIndex=(int)oldItem.Type;
	Statistics.Health.RemoveModifier(oldItem.modifierHealth);
	Statistics.currentHealth-=oldItem.modifierHealth;
		if (Statistics.currentHealth<=0)
			{
			Statistics.currentHealth=1;
			}
	Statistics.Speed.RemoveModifier(oldItem.modifierSpeed);
	Statistics.Armor.RemoveModifier(oldItem.modifierArmor);
	Statistics.AttackStrength.RemoveModifier(oldItem.modifierAttackStrength);
	Statistics.AttackSpeed.RemoveModifier(oldItem.modifierAttackSpeed);
	Statistics.Energy.RemoveModifier(oldItem.modifierEnergy);
	Inventory.instance.AddItemToInventory(oldItem);
	currentEquipment[EquipmentSlotIndex]=null;
	}	
}
