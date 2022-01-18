using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Treasure : MonoBehaviour
{
	public float Radius=2f;
	
	public List<Item> ItemsInContainer=new List<Item>();
	
	public void TakeItem(Item item)
	{
		Inventory.instance.AddItemToInventory(item);
		ItemsInContainer.Remove(item);
	}
	
	public void TakeAll()
	{
		for (int i=0; i<=ItemsInContainer.Count-1; i++)
		{
		Inventory.instance.AddItemToInventory(ItemsInContainer[i]);	
		}
		ItemsInContainer.Clear();
	}
	
	void Awake()
	{
		GetComponent<SphereCollider>().radius=Radius;
	}
	
	void OnTriggerStay(Collider sphere)
	{
		if (Input.GetButtonDown("Use"))
			{
			TakeAll();	
			}
	}
	
}
