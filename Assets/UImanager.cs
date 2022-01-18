using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UImanager : MonoBehaviour
{
	public GameObject MainMenu;
	public GameObject InventoryScreen;
	public bool isPaused=false;
	
	public Text SelectedName;
	public Text SelectedDescription;
	
	public Item SelectedItem;
	public GameObject Selected;
	public Image SelectedHighlight;

	public Button UseButton;

	public static UImanager instance;

	public Text DeathScreen;


	void Awake()
	{
	instance=this;	
	}

    // Update is called once per frame
    void Update()
    {
    if (Input.GetKeyDown(KeyCode.Escape))
		{
		if (MainMenu.activeSelf==false)	
			{
			Cursor.lockState=CursorLockMode.None;
			InventoryScreen.SetActive(false);
			MainMenu.SetActive(true);
			isPaused=true;
			Time.timeScale=0;
			} else
				{
				ResumeButton();
				}	
		}
	
	if (Input.GetButtonDown("Inventory"))
		{
			if (InventoryScreen.activeSelf==false)
			{
			InventoryButton();
			} else
				{
				ResumeButton();
				}
		}
	
	if (Selected==null)
		{
		SelectedName.text="";
		SelectedDescription.text="";
		SelectedItem=null;
		UseButton.enabled=false;
		} else
			{
			UseButton.enabled=true;	
			}
    }
	
	public void ResumeButton()
	{
		Cursor.lockState=CursorLockMode.Locked;
		MainMenu.SetActive(false);
		InventoryScreen.SetActive(false);
		isPaused=false;
		Time.timeScale=1;
	}
	
	public void InventoryButton()
	{
		Cursor.lockState=CursorLockMode.None;
		MainMenu.SetActive(false);
		InventoryScreen.SetActive(true);
		isPaused=true;
		Time.timeScale=0;
	}
	
	public void QuitButton()
	{
		Application.Quit();
	}
	
	public void SelectItem(Item item, Image highlight, GameObject selectedObject)
	{
	if (SelectedHighlight!=null)
		{
		SelectedHighlight.enabled=false;
		}
	SelectedHighlight=highlight;
	SelectedHighlight.enabled=true;
	Selected=selectedObject;
	SelectedItem=item;
	SelectedName.text=SelectedItem.name;
	SelectedDescription.text=SelectedItem.description;
	}
	
	public void UseSelectedItem()
	{
	SelectedItem.UseItem();	
	}
	
}
