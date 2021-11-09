using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/// <summary>
/// Current Issues: 
/// -The discard only works one time and then stops working (I think i am not removing anything from the list and only adding so once 
///     the second card is discarded the third doesn't replace it as the new second card)
/// -The discard has issues when it translates the ID it is supposed to discard to the actual card it discards from the list
/// </summary>



public class CardController : MonoBehaviour
{
    
    public float MoveSpeed = 5;
    Vector3 TargetPos;
    public static List<CardController> CardInHandList = new List<CardController>();
    public static int CardHandTotal = 0;
    private int MyCardHandID;

    // Start is called before the first frame update
    void Start()
    {
        DrawCard();
        NewTargetPos("Player Hand");
    }

    // Update is called once per frame
    void Update()
    {
        //is constantly moving this card toward the new position every frame
        Vector3 CurrentTargetPos = TargetPos;
        if(transform.position != CurrentTargetPos)
        {
            transform.position = Vector3.MoveTowards(transform.position, CurrentTargetPos, Time.deltaTime * MoveSpeed);
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
        TargetPos = new Vector3(-1, 1, 0);

        //tell all cards in the player's hand to reset their ID in the hand and if that ID and sets this cards ID to 0
        for (int CardToCall = 0; CardToCall < CardHandTotal; CardToCall++)
        {
            CardInHandList[CardToCall].ResetCardHandID(MyCardHandID);
        }

        CardHandTotal--;

    }

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
