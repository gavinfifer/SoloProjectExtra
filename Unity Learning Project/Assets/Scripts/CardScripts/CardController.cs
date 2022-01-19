using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardController : MonoBehaviour
{
    
    public float MinimumMoveSpeed = 0.1f;
    Vector3 TargetPos;
    string StringTarget = "";
    
    // Start is called before the first frame update
    void Start()
    {
        To_Draw_Pile_At_Pos(-1);
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

        New_Target_Pos(StringTarget);

    }

    //changes the target position of the card this is attached to
    public void New_Target_Pos(string InputTarget)
    {
        //establishes the variables used in Vector3 later
        int NewX = 0;
        int NewY = 0;
        int NewZ = 0;

        if (InputTarget == "Player Hand")
        {

            //create each position for the cards to go to based off of the amount of cards in hand
            //pass through the array of cards in the hand from first to last and send them to a position from left to right

            //create spacing for cards based on dividing the max space for the hand
            //check the position within the array in hand for this
            //set the NewX based off of that position found in relation to the total
            int IndexOfThis = CardCreate.HandList.IndexOf(this);
            
            NewX = (IndexOfThis + 1 / CardCreate.HandTotal + 1);
            

            NewY = -3;

            TargetPos = new Vector3(NewX, NewY, NewZ);
            




        }
        else if(InputTarget == "Draw Pile")
        {
            NewX = 5;
            NewY = 0;
            TargetPos = new Vector3(NewX, NewY, NewZ);
        }
        else if(InputTarget == "Discard Pile")
        {
            NewX = -5;
            NewY = 0;
            TargetPos = new Vector3(NewX, NewY, NewZ);
        }
        
        //tells the card to move to a new position
        
    }

    public void Remove_This_From_Every_List_TO(List <CardController> TargetList)
    {
        //remove from all other lists this object could be in and add it to the correct list

        if (CardCreate.DrawPileList.Contains(this) && TargetList != CardCreate.DrawPileList)
        {
            CardCreate.DrawPileList.Remove(this);
            CardCreate.DrawPileTotal--;
        }
        if (CardCreate.HandList.Contains(this) && TargetList != CardCreate.HandList)
        {
            CardCreate.HandList.Remove(this);
            CardCreate.HandTotal--;
        }
        if (CardCreate.DiscardPileList.Contains(this) && TargetList != CardCreate.DiscardPileList)
        {
            CardCreate.DiscardPileList.Remove(this);
            CardCreate.DiscardPileTotal--;
        }
    }

    //called on the card when it is first drawn
    public void To_Player_Hand()
    {
        //go to player hand, gameplay stuff yatta yatta
        StringTarget = "Player Hand";



        //remove from all other lists this object could be in and add it to the correct list
        Remove_This_From_Every_List_TO(CardCreate.HandList);
        CardCreate.HandList.Add(this);
        CardCreate.HandTotal++;
    }

    public void To_Draw_Pile_At_Pos(int ListPos)
    {
        //go to draw pile, gameplay stuff yatta yatta
        StringTarget = "Draw Pile";


        
        //remove from all other lists this object could be in and add it to the correct list
        Remove_This_From_Every_List_TO(CardCreate.DrawPileList);
        if (ListPos == -1)
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
        StringTarget = "Discard Pile";



        //remove from all other lists this object could be in and add it to the correct list
        Remove_This_From_Every_List_TO(CardCreate.DiscardPileList);
        CardCreate.DiscardPileList.Add(this);
        CardCreate.DiscardPileTotal++;
    }
    public void OnDestroy()
    {
        Remove_This_From_Every_List_TO(new List<CardController>());
    }
}
