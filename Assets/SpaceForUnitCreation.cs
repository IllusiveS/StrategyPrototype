using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SpaceForUnitCreation : MonoBehaviour {

	public sideEnum state;

	public float xOffset;
	public float yOffset;
	
	public List<SpaceForUnit> createdSpaces = new List<SpaceForUnit>();

	public GameObject prefab;
	
	// Use this for initialization
	void Start () {

	}

	public void setUp()
	{
		createdSpaces.Add(GetComponent<SpaceForUnit> ());
		GetComponent<SpaceForUnit> ().spaceForPlayer = CombatStartPlayerGetter.getPlayer (state);
		
		for(int i = 0; i < 5; i++)
		{
			GameObject obj = Instantiate(prefab) as GameObject;
			createdSpaces.Add(obj.GetComponent<SpaceForUnit>());
			obj.transform.parent = this.transform.parent;
			obj.transform.localScale = new Vector3(1, 1, 1);
			obj.GetComponent<SpaceForUnit>().spaceForPlayer = CombatStartPlayerGetter.getPlayer(state);
		}
	}
	
	// Update is called once per frame
	void Update () {

		Vector3 startingPlace = createdSpaces [0].transform.position;

		Vector3 place;

		float xOffset;
		float yOffset;

		for(int i = 1; i < createdSpaces.Count; i++)
		{
			xOffset = this.xOffset * (i%2);
			yOffset = this.yOffset * (i%3);

			if(state == sideEnum.Defender)
			{
				place = new Vector3(startingPlace.x - xOffset, startingPlace.y + yOffset, startingPlace.z);
			}else
			{
				place = new Vector3(startingPlace.x + xOffset, startingPlace.y + yOffset, startingPlace.z);
			}
			createdSpaces[i].transform.position = place;

			createdSpaces[i].xCoord = (i+1)%2;
			createdSpaces[i].yCoord = i%3;
		}
	}
	public void removeSpaces()
	{
		foreach(SpaceForUnit un in createdSpaces)
		{
			Destroy(un.gameObject);
		}
	}
}
