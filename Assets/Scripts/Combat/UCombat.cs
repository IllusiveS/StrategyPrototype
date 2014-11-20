using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class UCombat : MonoBehaviour, ITurnSubject {

	public Sprite selectableSprite;
	public Sprite attackableSprite;

	public static UCombat singleton;

	public static UCombat getSingleton()
	{
		return singleton;
	}

	public ICombat combat;
	public ICombatSituation situation;

	public UArmy Attackers;
	public UArmy Defenders;

	public int currentPlayer;

	public List<ITurnObserver> units = new List<ITurnObserver> ();

	public int numberOfUnits;

	UCombatStart start;
	
	// Use this for initialization
	void Start () {
		singleton = this;


		start = GetComponent<UCombatStart> ();
		start.setUp (Attackers, Defenders);

		currentPlayer = Attackers.army.getPlayer ();
		
		setUpCombat (Attackers.army, Defenders.army);

	}

	// Update is called once per frame
	void Update () {
		numberOfUnits = units.Count;
	}

	public void setUpCombat(IArmy atk, IArmy def)
	{
		Combat com = new Combat ();
		combat = com;
		situation = com;
		combat.setUp (this, atk, def);

		Attackers = atk.getUArmy ();
		Defenders = def.getUArmy ();
	}

	public void startCombat()
	{
		Notify (currentPlayer);
	}

	///
	///ITURNSUBJECT
	///
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
	public void checkAttackable(UCombatUnitModule attacker)
	{
		UArmy armyToCheck;
		try
		{
			if(attacker.GetComponent<UUnit>().unit.getPlayer() == Attackers.army.getPlayer())
			{
				armyToCheck = Defenders;
			}
			else
			{
				armyToCheck = Attackers;
			}
		}
		catch(System.NullReferenceException)
		{
			if(UCombatUnitModule.selected.GetComponent<UUnit>().unit.getPlayer() == Attackers.army.getPlayer())
			{
				armyToCheck = Defenders;
			}
			else
			{
				armyToCheck = Attackers;
			}
		}

		foreach(Unit un in armyToCheck.army.getUnits())
		{
			try
			{
				if(attacker.GetComponent<UUnit>().unit.canAttack(un))
				{
					un.unityUnit.GetComponent<UCombatUnitModule>().attackable = true;
					un.unityUnit.GetComponent<UCombatUnitModule>().selectableView.UpdateDisplay();
				}
			}
			catch(System.NullReferenceException)
			{
				un.unityUnit.GetComponent<UCombatUnitModule>().attackable = false;
				un.unityUnit.GetComponent<UCombatUnitModule>().selectableView.UpdateDisplay();
			}
		}
	}

	public void changePlayer()
	{
		UArmy nextPlayer;

		if (currentPlayer == Attackers.army.getPlayer())
		{
			nextPlayer = Defenders;
		}else
		{
			nextPlayer = Attackers;
		}
		if(IsThereAWinner())
		{
			EndCombat();
			return;
		}
		if(AllUnitsHaveMoved())
		{
			EndCombat();
			return;
		}
		if(NextPlayerHaveMoved(nextPlayer))
		{
			Notify(currentPlayer);
		}else
		{
			currentPlayer = nextPlayer.army.getPlayer();
			Notify(currentPlayer);
		}
	}

	public bool NextPlayerHaveMoved(UArmy nextPlayer)
	{
		bool allMoved = true;
		foreach(Unit un in nextPlayer.army.getUnits())
		{
			if(!un.unityUnit.GetComponent<UCombatUnitModule>().used)
			{
				allMoved = false;
			}
		}
		return allMoved;
	}
	public bool AllUnitsHaveMoved()
	{
		List<UUnit> units = new List<UUnit> ();

		bool allMoved = true;

		foreach(Unit un in Attackers.army.getUnits())
		{
			units.Add(un.unityUnit);
		}
		foreach(Unit un in Defenders.army.getUnits())
		{
			units.Add(un.unityUnit);
		}
		foreach(UUnit un in units)
		{
			if(!un.GetComponent<UCombatUnitModule>().used)
			{
				allMoved = false;
			}
		}

		return allMoved;
	}

	public bool IsThereAWinner()
	{
		List<UUnit> units = new List<UUnit> ();
		
		bool allMoved = false;
		
		if (Attackers.army.getUnits().Count == 0)
		{
			allMoved = true;
		}
		if(Defenders.army.getUnits().Count == 0)
		{
			allMoved = true;
		}

		return allMoved;
	}

	public void EndCombat()
	{
		int attackerGlory = 0;
		int defenderGlory = 0;

		foreach(Unit un in Attackers.army.getUnits())
		{
			attackerGlory += un.getGlory();
		}

		foreach(Unit un in Defenders.army.getUnits())
		{
			defenderGlory += un.getGlory();
		}

		if(attackerGlory > defenderGlory)
		{
			DeclareWinner(Attackers, attackerGlory - defenderGlory);
		}
		else
		{
			DeclareWinner(Defenders, defenderGlory - attackerGlory);
		}


		foreach(Unit un in Attackers.army.getUnits())
		{
			Destroy(un.unityUnit.GetComponent<UCombatUnitModule>());
			un.unityUnit.transform.position = new Vector3(900, 990, 900);
			un.unityUnit.GetComponent<SpriteRenderer>().sprite = un.sprite;
		}
		
		foreach(Unit un in Defenders.army.getUnits())
		{
			Destroy(un.unityUnit.GetComponent<UCombatUnitModule>());
			un.unityUnit.transform.position = new Vector3(900, 990, 900);
			un.unityUnit.GetComponent<SpriteRenderer>().sprite = un.sprite;
		}

		if (Attackers.army.getUnits().Count == 0)
		{
			Destroy (Attackers.gameObject);
		}
		if(Defenders.army.getUnits().Count == 0)
		{
			Destroy (Defenders.gameObject);
		}

		Destroy (gameObject);
	}

	public void DeclareWinner(UArmy winner, int points)
	{
		Player.getPlayer (winner.army.getPlayer ()).Glory += points + 1;
	}

	public void CheckDeaths()
	{
		List<UUnit> dupa = new List<UUnit> ();

		foreach(Unit un in Attackers.army.getUnits())
		{
			dupa.Add(un.unityUnit);
		}
		
		foreach(Unit un in Defenders.army.getUnits())
		{
			dupa.Add(un.unityUnit);
		}

		foreach(UUnit un in dupa)
		{
			if (un.unit.Die())
			{
				UCombat.getSingleton().Detach(un.GetComponent<UCombatUnitModule>());
				un.unit.owner.army.getUnits().Remove(un.unit);
				Destroy(un.gameObject);
			}
			un.GetComponent<UCombatUnitModule>().attackable = false;
		}
	}

	void OnGUI()
	{
		string str;
		if(Attackers.army.getGlory() > Defenders.army.getGlory())
		{
			str = Attackers.army.getGlory().ToString() + " <<<< " + Defenders.army.getGlory();
		}
		else
		{
			str = Attackers.army.getGlory().ToString() + " >>>> " + Defenders.army.getGlory();
		}
		GUI.Label(new Rect(Screen.height/15*13, Screen.height/15*14, Screen.width/7*3, Screen.width/7*3), str);
	}

	void OnDestroy()
	{
		singleton = null;
	}
}
