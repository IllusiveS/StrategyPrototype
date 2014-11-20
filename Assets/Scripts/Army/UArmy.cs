using UnityEngine;
using System.Collections;

public class UArmy : MonoBehaviour {

	public Army army;

	public int iPlayer;
	public int iSpeed;

	[System.NonSerialized]
	public UNode node;

	void Awake()
	{
		army = new Army (iPlayer, iSpeed, this);
	}

	// Use this for initialization
	void Start () {
		army.attachToPlayer ();

		gameObject.AddComponent<UArmyIsActive> ();

		try
		{
			node = Physics.OverlapSphere (new Vector3(transform.position.x, transform.position.y, transform.position.z + 0.5f), 0.2f, 1 << 8) [0].GetComponent<UNode> ();
			army.setNode (node.node);
		}
		catch (System.IndexOutOfRangeException)
		{

		}
		GetComponentInChildren<DisplayArmyMovement> ().army = army;

		GetComponentInChildren<DisplayPlayerSprite> ().owner = army;

		foreach(UUnit un in GetComponentsInChildren<UUnit>())
		{
			army.addUnit(un.unit);
		}
	}

	public void UpdateMovementDisplay()
	{
		GetComponentInChildren<DisplayArmyMovement> ().DisplayMovement ();
	}

	// Update is called once per frame
	void Update () {
	
	}

	void OnDestroy()
	{
		army.getNode ().Leave (null);
		//node.node.Leave (null);
		army.detachFromPlayer ();
	}
}
