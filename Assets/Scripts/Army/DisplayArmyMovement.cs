using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class DisplayArmyMovement : MonoBehaviour {

	private class MovementLeftList : List<MovementLeftDisplay> {}

	public IArmy army;

	MovementLeftList lista = new MovementLeftList();

	public float unitOffset;

	public GameObject displayer;

	// Use this for initialization
	void Start () {
		for(int i = 0; i < 8; i++)
		{
			GameObject current = Instantiate(displayer) as GameObject;
			MovementLeftDisplay Display = current.GetComponent<MovementLeftDisplay>();
			lista.Add(Display);
		}
		foreach(MovementLeftDisplay mov in lista)
		{
			mov.transform.parent = transform;
		}
		if(army == null)
		{
			army = GetComponentInParent<UArmy>().army;
		}
	}
	
	// Update is called once per frame
	void Update () {
		DisplayMovement ();
		for(int i = 0; i < lista.Count; i++)
		{
			MovementLeftDisplay current = lista[i];
			current.transform.position = new Vector3(this.transform.position.x, this.transform.position.y + (unitOffset * i), -0.6f);
			current.GetComponent<SpriteRenderer>().sortingLayerName = "Armies";
		}
	}
			
	public void DisplayMovement()
	{
		foreach(MovementLeftDisplay mov in lista)
		{
			mov.GetComponent<SpriteRenderer>().enabled = false;
		}

		for(int i = 0; i < lista.Count; i++)
		{
			if (i < army.getSpeed())
				lista[i].GetComponent<SpriteRenderer>().enabled = true;
		}
	}
}
