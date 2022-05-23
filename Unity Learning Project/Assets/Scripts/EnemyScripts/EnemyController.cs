using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MinimumMoveSpeed = 0.1f;
    Vector3 TargetPos;
    public Renderer renderer_;

    //Enemy Stats
    public float HealthPoints = 50.0f;
    //No Status effect
    public int CurrentStatus = 0;

    // Start is called before the first frame update
    void Start()
    {
        New_Target_Pos("Middle Screen");
    }

    // Update is called once per frame
    void Update()
    {
        //is constantly moving this enemy toward the new position every frame
        Vector3 CurrentTargetPos = TargetPos;

        if (transform.position != CurrentTargetPos)
        {
            float CurrentVelocity = MinimumMoveSpeed;

            //scale the CurrentVelocity based on the distance to the target position
            CurrentVelocity += (5 * (Vector3.Distance(CurrentTargetPos, transform.position)));

            transform.position = Vector3.MoveTowards(transform.position, CurrentTargetPos, Time.deltaTime * CurrentVelocity);
        }

        if(HealthPoints <= 0.0f)
        {
            Destroy(gameObject);
        }

        if(CurrentStatus > 0)
        {
            //change circle color
            renderer_.material.color = new Color(1, 0, 0);
        }
        else
        {
            //reset circle color
            renderer_.material.color = new Color(1, 1, 1);
        }
    }

    public void New_Target_Pos(string InputTarget)
    {
        //establishes the variables used in Vector3 later
        int NewX = 0;
        int NewY = 0;
        int NewZ = 0;

        if (InputTarget == "Middle Screen")
        {
            NewX = 0;
            NewY = 0;
        }
        else if (InputTarget == "Up")
        {
            NewX = 1;
            NewY = 7;
        }

        //tells the enemy to move to a new position
        TargetPos = new Vector3(NewX, NewY, NewZ);
    }

}
