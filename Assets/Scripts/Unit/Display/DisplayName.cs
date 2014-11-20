using UnityEngine;
using System.Collections;

public class DisplayName : MonoBehaviour {
	
	public Unit unit;
	
	TextMesh text; 
	MeshRenderer mesh; 
	
	// Use this for initialization
	void Start () {
		text = GetComponent<TextMesh>();
		mesh = GetComponent<MeshRenderer>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	public void displayInfo(bool display)
	{
		mesh.enabled = display;
		text.text = unit.name;
	}
	
	public void setUnit(Unit unit)
	{
		this.unit = unit;
	}
	
}
