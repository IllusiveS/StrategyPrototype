using UnityEngine;
using System.Collections;

public class UArmyIsActive : MonoBehaviour {

	Army army;

	Vector3 up;
	Vector3 down;

	float t = 0;

	bool directionDown = true;

	public bool isActive;

	// Use this for initialization
	void Start () {
		army = GetComponent<UArmy> ().army;

		up = transform.position;
		down = transform.position;

		up = new Vector3 (up.x, up.y + 0.25f, up.z);
		down = new Vector3 (down.x, down.y - 0.25f, down.z);
	}
	
	// Update is called once per frame
	void Update () {
		isActive = army.getIsActive ();

		if(isActive)
		{
			transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
		}
		else
		{
			transform.localScale = new Vector3(1.0f, 1.0f, 1.0f);
		}
	}

	void move()
	{
		t += Time.deltaTime;
		if(directionDown)
		{
			moveDown(t);
		}
		else
		{
			moveUp (t);
		}

		if (t > 1.0f)
		{
			t = 0.0f;
			if(directionDown)
				directionDown = false;
			else
				directionDown = true;
		}
	}
	void moveDown(float t)
	{
		Vector3.Lerp(down, up, t);
	}
	void moveUp(float t)
	{
		Vector3.Lerp(up, down, t);
	}
}
