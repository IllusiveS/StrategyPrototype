using UnityEngine;
using System.Collections;

public class DisplayUnitDetails : MonoBehaviour {

	public bool display = false;

	public Unit unitToDisplay;

	public Transform noDisplay;
	public Transform yesDisplay;

	// Use this for initialization
	void Start () {
		unitToDisplay = GetComponentInParent<UUnit> ().unit;
		GetComponentInChildren<TextDetails> ().setUnit (unitToDisplay);
	}
	
	// Update is called once per frame
	void Update () {
		displayInfo (display);
	}

	public void displayInfo(bool display)
	{
		if (display)
		{
			transform.localPosition = yesDisplay.localPosition;
		}
		else
		{
			transform.localPosition = noDisplay.localPosition;
		}
		
		GetComponentInChildren<TextDetails> ().displayInfo (display);

	}
}
