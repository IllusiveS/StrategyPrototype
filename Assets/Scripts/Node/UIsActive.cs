using UnityEngine;
using System.Collections;

public class UIsActive : MonoBehaviour {

	public bool isActive = false;

	public void setActive(bool b)
	{
		isActive = b;
	}

	void Update()
	{
		GetComponent<SpriteRenderer> ().enabled = isActive;
	}

}
