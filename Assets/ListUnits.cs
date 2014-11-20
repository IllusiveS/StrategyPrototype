using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ListUnits : MonoBehaviour {

	private static ListUnits Singleton;

	public static ListUnits getInstance()
	{
		return Singleton;
	}

	public UArmy armyToDisplay;

	private List<Unit> units = new List<Unit>();

	public float distance;


	void Awake()
	{
		ListUnits.Singleton = this;
	}
	// Use this for initialization
	void Start () {
	
	}
	
	public void displayArmy(UArmy army)
	{
		try
		{
			for(int i = 0; i < units.Count; i++)
			{
				Vector3 place = new Vector3 (90.0f, 90.0f, 90.0f);
				UUnit unitToMove = units[i].unityUnit;
				unitToMove.transform.position = place;
			}
		}
		catch (System.NullReferenceException)
		{

		}
		units = new List<Unit> ();
		try
		{
			Unit[] asd = new Unit[army.army.getUnits().Count];
			army.army.getUnits ().CopyTo(asd);

			foreach(Unit un in asd)
			{
				units.Add(un);
			}
		}
		catch (System.NullReferenceException)
		{
			units =  new List<Unit>();
		}

	}

	// Update is called once per frame
	void Update () {
		try
		{

			for(int i = 0; i < units.Count; i++)
			{
				UUnit movedUnit = units[i].unityUnit;

				Vector3 place = new Vector3(transform.position.x, transform.position.y - (distance * i), transform.position.z);

				movedUnit.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = - i * 3;

				movedUnit.gameObject.transform.FindChild("UnitDisplay").GetComponent<SpriteRenderer>().sortingOrder = - (i * 3) - 1;

				movedUnit.transform.position = place;
			}
		}
		catch (System.NullReferenceException)
		{

		}
	}
}
