using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpwnPoint : MonoBehaviour
{
    public Transform target;
    public int amount;
    bool algo;
    public GameObject Enemy;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(transform.position, target.transform.position) < 10 && !algo)
        {
            for (int i = 0; i < amount; i++)
            {
                var enemy = Instantiate(Enemy);
                enemy.transform.position = transform.position;
            }
           
            algo = true;
        }
        else if (Vector2.Distance(transform.position, target.transform.position) > 10 && algo)
        {
            algo = false;
        }
    }
}
