using UnityEngine;
using System.Collections;

public class UCombatUnitModule : MonoBehaviour, ITurnObserver {

	public bool selectable = false;
	public bool used = false;
	public bool attackable = false;

	public UCombatUnitSelectableView selectableView;

	public static UCombatUnitModule selected;

	// Use this for initialization
	void Start () {
		GameObject obj = new GameObject ("Selectablility view");
		obj.transform.parent = transform;
		obj.AddComponent<UCombatUnitSelectableView> ();

		selectableView = obj.GetComponent<UCombatUnitSelectableView> ();
		selectableView.unitModule = this;
		selectableView.UpdateDisplay ();

		GetComponent<UUnit>().unit.setCombatSituation(UCombat.getSingleton().situation);

		UCombat.getSingleton ().Attach (this);
		UCombat.getSingleton ().Notify (UCombat.getSingleton ().currentPlayer);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetMouseButtonDown(1))
		{
			UCombat.getSingleton().Notify(selected.GetComponent<UUnit>().unit.getPlayer());
			UCombat.getSingleton().checkAttackable(null);
			selected = null;
		}
	}

	public void Update(int turn)
	{
		if(turn == gameObject.GetComponent<UUnit>().unit.getPlayer())
		{
			if(!used)
			{
				selectable = true;
			}
			else
			{
				selectable = false;
			}
		}
		else
		{
			selectable = false;
		}

		if(selected == this)
		{
			selectable = true;
		}

		if(used)
		{
			GetComponent<SpriteRenderer>().sprite = GetComponent<UUnit>().unit.desaturated;
		}
		else
		{
			GetComponent<SpriteRenderer>().sprite = GetComponent<UUnit>().unit.sprite;
		}
		selectableView.UpdateDisplay ();
	}

	void OnMouseDown()
	{
		if(selectable)
		{
			if(selected == this)
			{
				used = true;
				selectable = false;
				selected = null;
				UCombat.getSingleton().changePlayer();
				return;
			}
			selected = this;
			checkPossibleAttacks();
		}
		if(attackable)
		{
			attackable = false;

			selected.used = true;
			selected.GetComponent<UUnit>().unit.attack(GetComponent<UUnit>().unit);

			selected = null;

			UCombat.getSingleton().CheckDeaths();
			UCombat.getSingleton().changePlayer();
		}
	}

	public void checkPossibleAttacks()
	{
		UCombat.getSingleton ().Notify (5);
		UCombat.getSingleton ().checkAttackable (this);
	}

	void OnDestroy()
	{
		Destroy (selectableView.gameObject);
	}
}
