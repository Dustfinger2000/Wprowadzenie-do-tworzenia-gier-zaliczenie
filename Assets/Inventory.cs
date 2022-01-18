using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
	public static Inventory instance;
	
	public GameObject InventorySlot;
	public GameObject InventoryUI;
	
	void Awake()
	{
		if (instance!=null)
		{
		Debug.Log("Więcej niż jedno inventory!");		
		}
		instance=this;
	}
	
	public List<Item> ItemsInInventory=new List<Item>();
	
	public void AddItemToInventory(Item newItem)
	{
		ItemsInInventory.Add(newItem);
		var ItemUI=Instantiate(InventorySlot,InventoryUI.transform);
		ItemUI.GetComponent<InventorySlot>().item=newItem;
	}
	
	public void RemoveItemFromInventory(Item newItem)
	{
		ItemsInInventory.Remove(newItem);
	}

}
