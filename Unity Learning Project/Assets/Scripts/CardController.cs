using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Current Issues: 
/// -I am incorrectly accessing the CardInHandList as it starts at 0 not 1. The code doesn't show an error about this but it is the cause of the discard issues.
/// -The DiscardThisCard code is also trying to discard cards that don't exist
/// </summary>

public class CardController : MonoBehaviour
{
    
    public float MinimumMoveSpeed = 0.1f;
    Vector3 TargetPos;
    
    // Start is called before the first frame update
    void Start()
    {
        
        New_Target_Pos("Draw Pile");


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
            CurrentVelocity +=  (5 * (Vector3.Distance(CurrentTargetPos, transform.position)));

            transform.position = Vector3.MoveTowards(transform.position, CurrentTargetPos, Time.deltaTime * CurrentVelocity);
        }
    }

    //changes the target position of the card this is attached to
    public void New_Target_Pos(string InputTarget)
    {
        //establishes the variables used in Vector3 later
        int NewX = 0;
        int NewY = 0;
        int NewZ = 0;

        //---write code here to change what the 'new Vector' is based on the 'CardCount'---

        if (InputTarget == "Player Hand")
        {
            NewX = 0;
            NewY = -3;
        }
        else if(InputTarget == "Draw Pile")
        {
            NewX = 5;
            NewY = 0;
        }
        else if(InputTarget == "Discard Pile")
        {
            NewX = -5;
            NewY = 0;
        }
        
        //tells the card to move to a new position
        TargetPos = new Vector3(NewX, NewY, NewZ);
    }

    //called on the card when it is first drawn
    public void To_Player_Hand()
    {
        //go to player hand, gameplay stuff yatta yatta
        New_Target_Pos("Draw Pile");



        //remove from all other lists this object could be in and add it to the correct list
        if (CardCreate.DrawPileList.Contains(this))
        {
            CardCreate.DrawPileList.Remove(this);
            CardCreate.DrawPileTotal--;
        }
        if (CardCreate.DiscardPileList.Contains(this))
        {
            CardCreate.DiscardPileList.Remove(this);
            CardCreate.DiscardPileTotal--;
        }

        CardCreate.HandList.Add(this);
        CardCreate.HandTotal++;
    }

    public void To_Draw_Pile(int ListPos)
    {
        //go to draw pile, gameplay stuff yatta yatta
        New_Target_Pos("Draw Pile");



        //remove from all other lists this object could be in and add it to the correct list
        if (CardCreate.HandList.Contains(this))
        {
            CardCreate.HandList.Remove(this);
            CardCreate.HandTotal--;
        }
        if (CardCreate.DiscardPileList.Contains(this))
        {
            CardCreate.DiscardPileList.Remove(this);
            CardCreate.DiscardPileTotal--;
        }

        if(ListPos == -1)
        {
            CardCreate.DrawPileList.Add(this);
            CardCreate.DrawPileTotal++;
        }
        else
        {
            CardCreate.DrawPileList.Insert(ListPos, this);
            CardCreate.DrawPileTotal++;
        }
        
    }

    public void To_Discard_Pile()
    {
        //go to discard pile, gameplay stuff yatta yatta
        New_Target_Pos("Discard Pile");



        //remove from all other lists this object could be in and add it to the correct list
        if (CardCreate.DrawPileList.Contains(this))
        {
            CardCreate.DrawPileList.Remove(this);
            CardCreate.DrawPileTotal--;
        }
        if (CardCreate.HandList.Contains(this))
        {
            CardCreate.HandList.Remove(this);
            CardCreate.HandTotal--;
        }

        CardCreate.DiscardPileList.Add(this);
        CardCreate.DiscardPileTotal++;
    }

}
