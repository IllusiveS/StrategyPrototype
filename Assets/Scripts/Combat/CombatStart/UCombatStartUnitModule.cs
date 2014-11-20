using UnityEngine;
using System.Collections;

public class UCombatStartUnitModule : MonoBehaviour, ITurnObserver {

	public Vector3 place;

	public bool isActive = false;
	public bool isPlaced;

	Vector3 offset;
	Vector3 screenPoint;

	public UCombatStart combatStart;

	// Use this for initialization
	void Start () {
		isPlaced = false;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void Update(int player)
	{
		if (player == GetComponent<UUnit>().unit.getPlayer() && !isPlaced)
			isActive = true;
		else
			isActive = false;
	}

	void OnMouseDown()
	{
		if(isActive)
		{
			screenPoint = Camera.main.WorldToScreenPoint(gameObject.transform.position);
			
			offset = gameObject.transform.position - Camera.main.ScreenToWorldPoint(
				new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z));
		}
	}
	void OnMouseDrag()
	{
		if(isActive)
		{
			Vector3 curScreenPoint = new Vector3(Input.mousePosition.x, Input.mousePosition.y, screenPoint.z);
			
			Vector3 curPosition = Camera.main.ScreenToWorldPoint(curScreenPoint) + offset;
			transform.position = curPosition;
		}
	}
	void OnMouseUp()
	{
		if(isActive)
		{
			try
			{
				RaycastHit[] hit = Physics.RaycastAll(transform.position, new Vector3(0, 0, 1), 3.0f, 1 << 10);
				if(hit[0].collider.gameObject.GetComponent<SpaceForUnit>().spaceForPlayer == gameObject.GetComponent<UUnit>().unit.getPlayer() && hit[0].collider.gameObject.GetComponent<SpaceForUnit>().unit == null)
				{
					transform.position = hit[0].collider.gameObject.transform.position;

					GetComponent<UUnit>().unit.setXCoord(hit[0].collider.gameObject.GetComponent<SpaceForUnit>().xCoord);
					GetComponent<UUnit>().unit.setYCoord(hit[0].collider.gameObject.GetComponent<SpaceForUnit>().yCoord);

					GetComponent<UUnit>().gameObject.GetComponent<SpriteRenderer> ().sortingOrder = - hit[0].collider.gameObject.GetComponent<SpaceForUnit>().yCoord * 3;
					
					GetComponent<UUnit>().gameObject.transform.FindChild("UnitDisplay").GetComponent<SpriteRenderer>().sortingOrder = - (hit[0].collider.gameObject.GetComponent<SpaceForUnit>().yCoord * 3) - 1;

					hit[0].collider.gameObject.GetComponent<SpaceForUnit>().unit = GetComponent<UUnit>();

					isPlaced = true;
					combatStart. PlaceUnit();

					isActive = false;
				}
				else
				{
					transform.position = place;
				}

			}
			catch (System.IndexOutOfRangeException)
			{
				transform.position = place;
			}
		}
	}
}
