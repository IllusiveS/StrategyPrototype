using UnityEngine;
using System.Collections;

public class UNodeBoxCollider : MonoBehaviour {

	BoxCollider box;

	public bool isTrigger = true;

	public Vector3 center = new Vector3(0f, 0f, 0f);
	public Vector3 Size = new Vector3(0.5f, 0.5f, 0.5f);

	void Start () {
		box = gameObject.AddComponent<BoxCollider> ();
		box.isTrigger = isTrigger;
		box.size = Size;
		box.center = center;
	}
}
