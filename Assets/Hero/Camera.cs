using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera : MonoBehaviour {
    CharacterModel hero;
    // Use this for initialization
    void Start () {
        hero = FindObjectOfType<CharacterModel>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.position = hero.transform.position + new Vector3(0, 3, -30);

    }
}
