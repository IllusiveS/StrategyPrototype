using UnityEngine;
using System.Collections;

public class CArmy : MonoBehaviour {

	public IArmy army;

	// Use this for initialization
	void Start () {
		army = GetComponent<UArmy> ().army;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnMouseUp()
	{
		try
		{
			if(Army.selected.getPlayer() != army.getPlayer())
			{
				if(army.getNode().isReachable())
				{
					Army.selected.attackArmy(army);
					Army.selected.setCanAttack(false);
					return;
				}
			}
		}
		catch (System.NullReferenceException)
		{

		}
		if(Army.selected == army)
		{
			Army.selected.selectArmy(null);
			return;
		}

		army.selectArmy (army);
		return;

	}
}
