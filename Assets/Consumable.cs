using UnityEngine;

[CreateAssetMenu(fileName="New Item", menuName = "Inventory/Consumables")]
public class Consumable : Item
{
	public float Value1;
	
	public override void UseItem()
	{
		PlayerStats temp=GameObject.Find("PlayerManager").GetComponent<PlayerStats>();
		if ((temp.currentHealth+Value1)<temp.Health.GetValue())
		{
		temp.currentHealth+=Value1;
		} else
			{
			temp.currentHealth=temp.Health.GetValue();	
			}
	
	Inventory.instance.RemoveItemFromInventory(this);
	Destroy(UImanager.instance.Selected);
	}
}
