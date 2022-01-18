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
		
		if (currentIndex == combo.Length)
		{
			Destroy(GetComponent<MeshRenderer>());
			Destroy(GetComponent<BoxCollider>());
		}
	}
}