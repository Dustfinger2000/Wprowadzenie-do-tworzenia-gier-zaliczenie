using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventorySlot : MonoBehaviour, IPointerClickHandler
{
	public Item item;
	public Text itemName;
	public Image highlight;
	
	void Start()
	{
	itemName.text=item.name;	
	}
	
	public void DestroyItem()
	{
	Inventory.instance.RemoveItemFromInventory(item);
	Destroy(gameObject);
	}
	
	public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
		{
		UImanager.instance.SelectItem(item, highlight, gameObject);
		}
        if (eventData.button == PointerEventData.InputButton.Right)
		{
		UImanager.instance.SelectItem(item, highlight, gameObject);
		item.UseItem();
		}
    }			
}
