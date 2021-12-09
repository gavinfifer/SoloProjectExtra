using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreate : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(1, -3, 0);
    public GameObject CardPrefab;
    public static List<CardController> CardInHandList = new List<CardController>();
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
    public void DiscardCardbyID(int CardHandID)
    {
        //if the card ID passed in exists then it calls it's discard function
        if(CardHandID <= CardHandTotal && CardHandID > 0)
        {
            CardInHandList[CardHandID].DiscardThisCard();
        }
    }

    //discards all the cards in the player's hand
    public void DiscardAllCards()
    {
        for(int CardCounter = 1; CardCounter <= CardHandTotal; CardCounter++)
        {
            DiscardCardbyID(CardCounter);
        }
    }
}

