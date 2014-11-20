using UnityEngine;
using System.Collections;

public class UUnit : MonoBehaviour {

	public Unit unit;

	public UnitFactory factory;

	DisplayUnitDetails detailsDisplay;

	public int Xcoord;
	public int Ycoord;

	// Use this for initialization
	void Awake () {
		unit = factory.getUnit ();
		unit.unityUnit = this;
	}

	void Start()
	{
		detailsDisplay = GetComponentInChildren<DisplayUnitDetails> ();
		GetComponent<SpriteRenderer> ().sprite = unit.sprite;
	}
	
	// Update is called once per frame
	void Update () {
		Xcoord = unit.getXCoord ();
		Ycoord = unit.getYCoord ();
	}

	void OnMouseEnter()
	{
		detailsDisplay.display = true;
	}
	void OnMouseExit()
	{
		detailsDisplay.display = false;
	}
}
