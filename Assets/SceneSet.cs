using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.Characters.FirstPerson;

public class SceneSet : MonoBehaviour {

	// Use this for initialization
	void Start () {
        Physics.IgnoreCollision(GetComponent<Collider>(), FindObjectOfType<FirstPersonController>().gameObject.GetComponent<Collider>());
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
