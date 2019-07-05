using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnPoint : MonoBehaviour
{
    CharacterModel _character;
    bool isSpawn;
    public int amountEnemy1;
    public GameObject enemy1;
    public int amountEnemy2;
    public GameObject enemy2;
    public int amountEnemy3;
    public GameObject enemy3;
    void Start()
    {
        _character = FindObjectOfType<CharacterModel>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, _character.transform.position) < 10 && !isSpawn)
        {
            Enemy1();
            Enemy2();
            Enemy3();
           
            isSpawn = true;
        }
        else if (Vector2.Distance(transform.position, _character.transform.position) > 10 && isSpawn)
        {
            isSpawn = false;
        }
    }

    void Enemy1()
    {
        for (int i = 0; i < amountEnemy1; i++)
        {
            var enemy = Instantiate(enemy1);
            enemy.transform.position = transform.position;
        }
    }
    void Enemy2()
    {
        for (int i = 0; i < amountEnemy2; i++)
        {
            var enemy = Instantiate(enemy2);
            enemy.transform.position = transform.position;
        }
    }
    void Enemy3()
    {
        for (int i = 0; i < amountEnemy3; i++)
        {
            var enemy = Instantiate(enemy3);
            enemy.transform.position = transform.position;
        }
    }
}
