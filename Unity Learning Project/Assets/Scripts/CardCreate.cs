using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreate : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(10, -1, 0);
    public GameObject CardPrefab;
    public static List<CardController> HandList = new List<CardController>();
    public static int HandTotal = 0;
    public static List<CardController> DiscardPileList = new List<CardController>();
    public static int DiscardPileTotal = 0;
    public static List<CardController> DrawPileList = new List<CardController>();
    public static int DrawPileTotal = 0;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Create_New_Card_In_Draw_Pile()
    {
        //creates a new card at the start location
        GameObject NewCard = Instantiate(CardPrefab) as GameObject;
        NewCard.transform.position = StartPos;
    }
    public void Create_Card_Deck(int DeckSize)
    {
        for(int CardCount = 0; CardCount < DeckSize; CardCount++)
        {
            Create_New_Card_In_Draw_Pile();
        }
    }

    public void Draw_Top_Card_Of_Draw_Pile()
    {
        if(DrawPileList.Count != 0)
        {
            DrawPileList[0].To_Player_Hand();
        }
        else
        {
            Debug.Log("!---Draw Pile Empty---!");
        }
    }

    public void Place_Card_On_Top_Draw_Pile(int ListPos, int DrawPileListPos)
    {
        
    }

    //Discards the card with the passed ID in hand
    public void Discard_By_Pos(int ListPos)
    {
        //if the card ID passed in exists then it calls it's discard function
        if(ListPos < HandTotal && ListPos >= 0)
        {
            HandList[ListPos].To_Discard_Pile();
        }
    }

    //discards all the cards in the player's hand
    public void Discard_Hand()
    {
        int HandTotalAtCall = HandTotal;
        for(int ListPos = 0; ListPos < HandTotalAtCall; ListPos++)
        {
            HandList[0].To_Discard_Pile();
        }
    }

    public void Delete_All_Card_Objects()
    {
        ////////////////////////////////////////////USe the delete object cod in the card controller cs file on every existing Card Object
    }
}

