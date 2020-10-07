using UnityEngine;
using System.Collections;

public class InsetCollider : MonoBehaviour {
	public Insects _Insects;
	public bool OnInsectsTrigger;
	public string NameTagPlayer;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter (Collider other) {
		if (other.gameObject.tag == NameTagPlayer) {
			if(OnInsectsTrigger == true)
			{
				_Insects.enabled = true;
			}
		}
	}
}
