using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyCreate : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(6, 5, 0);
    public GameObject EnemyPrefab;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create_Enemy()
    {
        //creates a new enemy at the start location
        GameObject NewEnemy = Instantiate(EnemyPrefab) as GameObject;
        NewEnemy.transform.position = StartPos;
    }
}
