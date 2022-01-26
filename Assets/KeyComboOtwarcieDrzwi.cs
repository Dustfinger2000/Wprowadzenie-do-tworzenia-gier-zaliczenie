using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyComboOtwarcieDrzwi : MonoBehaviour
{
	public float Radius=1f;
    public KeyCode[] combo;
	public int currentIndex = 0;
	public bool Open = false;
 
		//Do miejsca oznaczonego gwiazdką kod można kopiować dzięki czemu tę sekcję można wykorzystać do różnych rzeczy np Eastereggi czy wywyoływanie zaklęć
		void Update() 
		{
			if (currentIndex < combo.Length) 
			{
				if(Input.GetKeyDown(combo[currentIndex]))
				{
					currentIndex++;
				}
			}
			
			if(currentIndex>0&&currentIndex<3&&Input.GetButtonDown("Use"))
			{
				Debug.Log("To zaklęcie jest za krótkie! Muszę je powtórzyć...");
				currentIndex = 0;
			}
			
			if(Input.GetButtonDown("Use"))
			{
				currentIndex = 0;
				Open = false;
			}
		}
		//*
	
		void Awake()
		{
			GetComponent<SphereCollider>().radius=Radius;
		}
	
		void OnTriggerStay(Collider sphere)
		{
			
			if (currentIndex==combo.Length)
			{
				Open = true;
			}
			
			if(Open==true&&Input.GetButtonDown("Use"))
			{
				Destroy(GetComponent<MeshRenderer>());
				Destroy(GetComponent<BoxCollider>());
				Debug.Log("Ordi, Dissmo, Ostis!");
				Open = false;
			}
		}
}