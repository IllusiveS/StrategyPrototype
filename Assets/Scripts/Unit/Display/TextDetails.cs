using UnityEngine;
using System.Collections;

public class TextDetails : MonoBehaviour {

	public Unit unit;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void setUnit(Unit unit)
	{
		this.unit = unit;
		GetComponentInChildren<DisplayGlory> ().setUnit (unit);
		GetComponentInChildren<DisplayStrength> ().setUnit (unit);
		GetComponentInChildren<DisplayName> ().setUnit (unit);
		GetComponentInChildren<DisplayDescription> ().setUnit (unit);
	}

	public void displayInfo(bool display)
	{
		GetComponentInChildren<DisplayGlory> ().displayInfo (display);
		GetComponentInChildren<DisplayStrength> ().displayInfo (display);
		GetComponentInChildren<DisplayName> ().displayInfo (display);
		GetComponentInChildren<DisplayDescription> ().displayInfo (display);
	}

}
