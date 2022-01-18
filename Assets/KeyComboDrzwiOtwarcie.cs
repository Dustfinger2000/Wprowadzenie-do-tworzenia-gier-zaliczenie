using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyComboDrzwiOtwarcie : MonoBehaviour
{
    public KeyCode[] combo;
	public int currentIndex = 0;
 
	void Update() 
	{
		if (currentIndex < combo.Length) 
		{
			if (Input.GetKeyDown(combo[currentIndex]) ) 
			{
				currentIndex++;
			}
		}
		//Do tego miejsca kod można kopiować do różnych obiektów
		//Koncówkę trzeba dopisywać w zależności co dane combo ma robić
		//Jak np w tym przypadku otwiera drzwi.
		
		if (currentIndex == combo.Length)
		{
			Destroy(GetComponent<MeshRenderer>());
			Destroy(GetComponent<BoxCollider>());
		}
	}
}