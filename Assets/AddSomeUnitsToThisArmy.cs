using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AddSomeUnitsToThisArmy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		UArmy armyToAdd = GetComponentInChildren<UArmy> ();
		foreach(UUnit un in GetComponentsInChildren<UUnit>())
		{
			armyToAdd.army.addUnit(un.unit);
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
