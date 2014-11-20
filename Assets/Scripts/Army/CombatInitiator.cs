using UnityEngine;
using System.Collections;

public class CombatInitiator : MonoBehaviour {

	public GameObject Combat;

	public IArmy army;

	public void Start()
	{
		army = GetComponent<UArmy>().army;
	}

	public void pressTheAttack(IArmy def)
	{
		GameObject goCombat = Instantiate(Combat) as GameObject;
		goCombat.transform.parent = Camera.main.transform;
		goCombat.transform.localPosition = new Vector3 (0, 0, 3);

		UCombat combat = goCombat.GetComponent<UCombat> ();
		combat.setUpCombat (army, def);
	}
}
