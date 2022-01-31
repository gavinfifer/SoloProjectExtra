using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public float MinimumMoveSpeed = 0.1f;
    Vector3 TargetPos;

    //Enemy Stats
    public float HealthPoints = 50.0f;
    public List<string> StatusList = new List<string>();


    // Start is called before the first frame update
    void Start()
    {
        New_Target_Pos("Middle Screen");
    }

    // Update is called once per frame
    void Update()
    {
        //is constantly moving this card toward the new position every frame
        Vector3 CurrentTargetPos = TargetPos;

        if (transform.position != CurrentTargetPos)
        {
            float CurrentVelocity = MinimumMoveSpeed;

            //scale the CurrentVelocity based on the distance to the target position
            CurrentVelocity += (5 * (Vector3.Distance(CurrentTargetPos, transform.position)));

            transform.position = Vector3.MoveTowards(transform.position, CurrentTargetPos, Time.deltaTime * CurrentVelocity);
        }

        //---------------------------Testing User Input: REMOVE THIS SECTION LATER------------------------------------
        if (Input.GetKey("w"))
        {
            New_Target_Pos("Up");
        }
        else
        {
            New_Target_Pos("Middle Screen");
        }
        //------------------------------------------------------------------------------------------------------------
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

        //tells the card to move to a new position
        TargetPos = new Vector3(NewX, NewY, NewZ);
    }

    
}
