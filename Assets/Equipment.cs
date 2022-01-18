using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName = "Inventory/Equipment")]
public class Equipment : Item
{	
	public EquipmentType Type;
	public float modifierHealth;
	public float modifierSpeed;
	public float modifierArmor;
	public float modifierAttackStrength;
	public float modifierAttackSpeed;
	public float modifierEnergy;
	
	public override void UseItem()
	{
	EquipmentSystem.instance.EquipItem(this);
	Inventory.instance.RemoveItemFromInventory(this);
	Destroy(UImanager.instance.Selected);
	}
}
public enum EquipmentType{Weapon,Armor,Accessory};

