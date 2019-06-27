using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUD : MonoBehaviour
{
    CharacterModel _character;
    public Text lifes;
    public Text restat;

    private void Awake()
    {
        restat.enabled = false;
        _character = FindObjectOfType<CharacterModel>();
    }
    // Update is called once per frame
    void Update()
    {
        lifes.text = "" + _character.life;
        if (_character.life == 0)
            Text();
    }

    void Text()
    {
        restat.enabled = true;
    }
}