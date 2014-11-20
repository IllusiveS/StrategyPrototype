using UnityEngine;
using System.Collections;

public class DisplayPlayerSprite : MonoBehaviour {

	public Sprite playerSprite;

	SpriteRenderer spriteRenderer;
	PlayerSpriteSelector selector;

	public IOwnable owner;

	void Start()
	{
		spriteRenderer = gameObject.AddComponent<SpriteRenderer> ();
		spriteRenderer.sortingLayerName = "Armies";
		selector = gameObject.GetComponent<PlayerSpriteSelector> ();
	}

	void Update () {
		playerSprite = PlayerSpriteSelector.GetPlayerSprite (owner.getOwner());
		if(playerSprite != null)
		{
			spriteRenderer.sprite = playerSprite;
			spriteRenderer.enabled = true;
		}
		else
			spriteRenderer.enabled = false;
	}
}
