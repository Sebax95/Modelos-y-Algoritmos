using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    CharacterModel _character;
    public Text lifes;

    private void Awake()
    {
        _character = FindObjectOfType<CharacterModel>();
    }
    // Update is called once per frame
    void Update()
    {
        lifes.text = "" + _character.life;
    }
}
