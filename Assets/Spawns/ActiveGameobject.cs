using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveGameobject : MonoBehaviour
{
    public GameObject _enemy;

    private void Awake()
    {
        _enemy.SetActive(true);

    }
}
