using UnityEngine;
using System.Collections;

public class UCombatUnitSelectableView : MonoBehaviour {

	SpriteRenderer spriteRenderer;

	public Sprite selectable;

	public UCombatUnitModule unitModule;

	// Use this for initialization
	void Awake () {
		spriteRenderer = gameObject.AddComponent<SpriteRenderer> ();
		spriteRenderer.sortingLayerName = "CombatGUI";
		spriteRenderer.sortingOrder = 1;
		spriteRenderer.sprite = UCombat.getSingleton ().selectableSprite;
	}
	
	// Update is called once per frame
	public void UpdateDisplay () {

		transform.localPosition = new Vector3 (0, 0, 0);
		transform.localScale = new Vector3 (3.74f, 4.08f, 0);

		if(unitModule.selectable)
		{
			spriteRenderer.enabled = true;
			spriteRenderer.sprite = UCombat.getSingleton().selectableSprite;
			unitModule.attackable = false;
			return;
		}
		if(unitModule.attackable)
		{
			spriteRenderer.enabled = true;
			spriteRenderer.sprite = UCombat.getSingleton().attackableSprite;
			return;
		}

		spriteRenderer.enabled = false;
		return;
	}


}
