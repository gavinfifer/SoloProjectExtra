using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreate : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(1, -3, 0);
    public GameObject CardPrefab;
    public static List<CardController> CardHandList = new List<CardController>();
    public static int CardHandTotal = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DrawCard()
    {
        //creates a new card at the start location
        GameObject NewCard = Instantiate(CardPrefab) as GameObject;
        NewCard.transform.position = StartPos;
    }

    //Discards the card with the passed ID in hand
    public void DiscardbyPos(int CardListPos)
    {
        //if the card ID passed in exists then it calls it's discard function
        if(CardListPos < CardHandTotal && CardListPos >= 0)
        {
            CardHandList[CardListPos].DiscardThisCard();
        }
    }

    //discards all the cards in the player's hand
    public void DiscardHand()
    {
        int TempCardHandTotal = CardHandTotal;
        for(int CardListPos = 0; CardListPos < TempCardHandTotal; CardListPos++)
        {
            CardHandList[0].DiscardThisCard();
        }
    }
}

