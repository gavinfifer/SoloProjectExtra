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
    public static List<CardController> CardInHandList = new List<CardController>();
    //CardHandTotal is 1 greater than the amount of cards actually in the player's hand
    public static int CardHandTotal = 1;
    private int MyCardHandID;
    

    // Start is called before the first frame update
    void Start()
    {
        DrawCard();
        NewTargetPos("Player Hand");
        Debug.Log("Card position in list on spawn: " + CardInHandList[0]);

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
    public void NewTargetPos(string InputTarget)
    {
        //establishes the variables used in Vector3 later
        int NewX = 0;
        int NewY = 0;
        int NewZ = 0;

        //---write code here to change what the 'new Vector' is based on the 'CardCount'---

        if (InputTarget == "Player Hand")
        {
            NewX = 0;
            NewY = 0;
        }
        else if(InputTarget == "Draw Pile")
        {
            NewX = 1;
            NewY = 1;
        }
        else if(InputTarget == "Discard Pile")
        {
            NewX = -1;
            NewY = -1;
        }
        
        //tells the card to move to a new position
        TargetPos = new Vector3(NewX, NewY, NewZ);
    }

    //called on the card when it is first drawn
    public void DrawCard()
    {
        CardInHandList.Add(this);
        CardHandTotal++;
        MyCardHandID = CardHandTotal;
    }

    public void DiscardThisCard()
    {
        //go to discard pile, gameplay stuff yatta yatta
        NewTargetPos("Discard Pile");

        //tell all cards in the player's hand to reset their ID in the hand and if that ID and sets this cards ID to 0
        for (int CardToCall = 0; CardToCall < (CardHandTotal); CardToCall++)
        {
            CardInHandList[CardToCall].ResetCardHandID(MyCardHandID);
        }
        CardHandTotal--;
    }


    /// <summary>
    /// - I think ResetCardHandID is not working correctly and is not changing the actuall list at all
    /// </summary>

    public void ResetCardHandID(int DiscardedCardHandID)
    {
        //if this cards ID is less then don't do anything but if it is more then decrement it by 1, if equal then reset it to 0
        if(DiscardedCardHandID < MyCardHandID)
        {
            MyCardHandID -= 1;
        }
        else if(DiscardedCardHandID == MyCardHandID)
        {
            MyCardHandID = 0;
        }
    }
}
