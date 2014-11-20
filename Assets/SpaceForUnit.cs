using UnityEngine;
using System.Collections;

public class SpaceForUnit : MonoBehaviour {

	public int spaceForPlayer;

	public UUnit unit;

	public int xCoord;
	public int yCoord;

	// Use this for initialization
	void Start () {
		gameObject.layer = 10;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
