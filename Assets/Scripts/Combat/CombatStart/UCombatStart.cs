using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UCombatStart : MonoBehaviour, ITurnSubject {

	public Transform transformCreateAttackers;
	public Transform transformCreateDefenders;

	public UArmy Attackers;
	public UArmy Defenders;

	public float offset;

	public List<ITurnObserver> units = new List<ITurnObserver> ();
	public int currentPlayer;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void setDisplay () {
		List<Unit> attackingUnits = Attackers.army.getUnits ();
		List<Unit> defendingUnits = Defenders.army.getUnits ();

		for(int i = 0; i < attackingUnits.Count; i++)
		{
			UUnit un = attackingUnits[i].unityUnit;
			un.transform.position = new Vector3 (transformCreateAttackers.position.x, transformCreateAttackers.position.y - (offset * i), transformCreateAttackers.position.z);
		
			un.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = - i * 3;
			un.gameObject.transform.FindChild("UnitDisplay").GetComponent<SpriteRenderer>().sortingOrder = - (i * 3) - 1;

			un.GetComponent<UCombatStartUnitModule>().place = new Vector3 (un.transform.position.x, un.transform.position.y, un.transform.position.z);
		}
		for(int i = 0; i < defendingUnits.Count; i++)
		{
			UUnit un =  defendingUnits[i].unityUnit;
			un.transform.position = new Vector3 (transformCreateDefenders.position.x, transformCreateDefenders.position.y - (offset * i), transformCreateDefenders.position.z);
		
			un.gameObject.GetComponent<SpriteRenderer> ().sortingOrder = - i * 3;
			un.gameObject.transform.FindChild("UnitDisplay").GetComponent<SpriteRenderer>().sortingOrder = - (i * 3) - 1;

			un.GetComponent<UCombatStartUnitModule>().place = new Vector3 (un.transform.position.x, un.transform.position.y, un.transform.position.z);
		}
	}

	public void setUp(UArmy attackers, UArmy defenders)
	{
		Attackers = attackers;
		Defenders = defenders;

		prepareDisplay ();
		setDisplay ();
		foreach(SpaceForUnitCreation crea in GetComponentsInChildren<SpaceForUnitCreation>())
		{
			crea.setUp();
		}
		Notify (Attackers.army.getUnits () [0].getPlayer ());

		currentPlayer = attackers.army.getPlayer ();
	}

	void prepareDisplay()
	{
		List<Unit> attackingUnits = Attackers.army.getUnits ();
		List<Unit> defendingUnits = Defenders.army.getUnits ();
		
		for(int i = 0; i < attackingUnits.Count; i++)
		{
			UUnit un = attackingUnits[i].unityUnit;
			UCombatStartUnitModule module = un.gameObject.AddComponent<UCombatStartUnitModule>();

			module.combatStart = this;
			Attach (module);
			
			//displayAttackers[i].unitToDisplay = Attackers.army.getUnits()[i].unityUnit;
		}
		for(int i = 0; i < defendingUnits.Count; i++)
		{
			UUnit un =  defendingUnits[i].unityUnit;
			UCombatStartUnitModule module = un.gameObject.AddComponent<UCombatStartUnitModule>();

			module.combatStart = this;
			Attach (module);
		}
	}

	public void PlaceUnit()
	{
		if(allUnitsArePlaced())
		{
			startCombat();
		}
		if(otherPlayerPlacedAll())
		{
			return;
		}
		if(currentPlayer == Attackers.army.getPlayer())
		{
			currentPlayer = Defenders.army.getPlayer();
		}
		else
		{
			currentPlayer = Attackers.army.getPlayer();
		}
		Notify (currentPlayer);
	}

	bool otherPlayerPlacedAll()
	{
		List<UCombatStartUnitModule> lista = new List<UCombatStartUnitModule> ();

		UArmy otherArmy;

		if(currentPlayer == Attackers.army.getPlayer())
		{
			otherArmy = Defenders;
		}
		else
		{
			otherArmy = Attackers;
		}

		foreach(Unit un in otherArmy.army.getUnits())
		{
			lista.Add(un.unityUnit.GetComponent<UCombatStartUnitModule>());
		}

		bool allPlaced = true;

		foreach(UCombatStartUnitModule un in lista)
		{
			if (un.isPlaced == false)
				allPlaced = false;
		}

		return allPlaced;
	}

	bool allUnitsArePlaced()
	{
		List<UCombatStartUnitModule> lista = new List<UCombatStartUnitModule> ();

		foreach(Unit un in Attackers.army.getUnits())
		{
			lista.Add(un.unityUnit.GetComponent<UCombatStartUnitModule>());
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			lista.Add(un.unityUnit.GetComponent<UCombatStartUnitModule>());
		}
		
		bool allPlaced = true;
		
		foreach(UCombatStartUnitModule un in lista)
		{
			if (un.isPlaced == false)
				allPlaced = false;
		}
		
		return allPlaced;
	}

	void startCombat()
	{
		List<UCombatStartUnitModule> lista = new List<UCombatStartUnitModule> ();
		
		foreach(Unit un in Attackers.army.getUnits())
		{
			lista.Add(un.unityUnit.GetComponent<UCombatStartUnitModule>());
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			lista.Add(un.unityUnit.GetComponent<UCombatStartUnitModule>());
		}

		foreach(UCombatStartUnitModule un in lista)
		{
			Destroy(un);
			un.gameObject.AddComponent <UCombatUnitModule>();
		}
		foreach(SpaceForUnitCreation crea in GetComponentsInChildren<SpaceForUnitCreation>())
		{
			crea.removeSpaces();
		}
		UCombat.getSingleton ().startCombat ();
	}

	public void Attach(ITurnObserver obs)
	{
		units.Add (obs);
	}
	public void Detach(ITurnObserver obs)
	{
		units.Remove (obs);
	}
	
	public void Notify(int turn)
	{
		foreach(ITurnObserver obs in units)
		{
			obs.Update (turn);
		}
	}
}
