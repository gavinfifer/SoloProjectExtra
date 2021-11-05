using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    
    public float MoveSpeed = 5;
    Vector3 TargetPos;
    static private int CardCount = 0;
    private int MyCardHandID;
    // Start is called before the first frame update
    void Start()
    {
        DrawCard();
        NewTargetPos();
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
    public void NewTargetPos()
    {
        //---write code here to change what the 'new Vector' is based on the 'CardCount'---
        int NewX = 0;
        int NewY = 0;
        int NewZ = 0;

        //tells the card to move to a new position
        TargetPos = new Vector3(NewX, NewY, NewZ);
    }

    public void DrawCard()
    {
        CardCount += 1;
        MyCardHandID = CardCount;
    }


    //---code below needs to contact each seperate script on every single card in the players hand from 'DiscardCard' and call every script's 'ResetCardHandID'---


    ////////use a dynamicly changing array of all the cards in the player's hand instead of the card ID variable to find and organize each card in the hand


    public void DiscardThisCard()
    {
        //go to discard pile, gameplay stuff yatta yatta


        //tell all other cards in the players hand to change their ID and lower the card count by 1

        //get a list of all the cards in the player's hand in order
        //for(card to call = 0; card to call < number of cards in players hand; card to call ++)
        //{
        //      call 'ResetCardHandID' on the currently targeted card
        //}

        ResetCardHandID(MyCardHandID);


        CardCount -= 1;

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
