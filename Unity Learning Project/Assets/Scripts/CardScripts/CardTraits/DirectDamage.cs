using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectDamage : MonoBehaviour
{
    public int DamageValue;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //When deals damage to the object passed in
    public void ThisCardPlayed(GameObject TargetObject)
    {
        //deal damage to the TargetObject
        TargetObject.GetComponent<EnemyController>().HealthPoints -= DamageValue;
    }

}
