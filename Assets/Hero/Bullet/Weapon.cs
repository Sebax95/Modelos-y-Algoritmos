using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour, IObserver
{
    
    CharacterModel _characterModel;
    // Start is called before the first frame update
    void Start()
    {
        _characterModel = FindObjectOfType<CharacterModel>();
        _characterModel.Subscribe(this);
    }
   
    public void OnNotify(string action)
    {
        if (action == "Normal1") { transform.position = _characterModel.transform.position + new Vector3(0.5f, 0.70f, 0); }
        if (action == "Normal2") { transform.position = _characterModel.transform.position + new Vector3(-0.5f, 0.70f, 0); }
        if (action == "Up1") { transform.position = _characterModel.transform.position + new Vector3(0.1f, 1.35f, 0); }
        if (action == "Up2") { transform.position = _characterModel.transform.position + new Vector3(-0.1f, 1.35f, 0); }
        if (action == "Down1") { transform.position = _characterModel.transform.position + new Vector3(0.5f, 0.2f, 0); }
        if (action == "Down2") { transform.position = _characterModel.transform.position + new Vector3(-0.5f, 0.2f, 0); }
        if (action == "UF1") { transform.position = _characterModel.transform.position + new Vector3(0.35f, 1, 0); }
        if (action == "UF2") { transform.position = _characterModel.transform.position + new Vector3(-0.45f, 1.1f, 0); }
        if (action == "DF1") { transform.position = _characterModel.transform.position + new Vector3(0.45f, 0.4f, 0); }
        if (action == "DF2") { transform.position = _characterModel.transform.position + new Vector3(-0.45f, 0.4f, 0); }
    }
}
