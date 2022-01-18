using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class EquipmentSlot : MonoBehaviour, IPointerClickHandler
{
	public Equipment item;
	public Image highlight;
	
	public void UnequipItem()
	{
	EquipmentSystem.instance.UnequipItem(item);
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
		UnequipItem();
		}
    }
}
