using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardCreate : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(1, -3, 0);
    public GameObject CardPrefab;

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

    public void DiscardCardbyID(int CardHandID)
    {
        //---check through each card in the player's hand for the card with the given ID---

        //for(card to check = 0; card to check < number of cards in players hand; card to check ++)
        //{
        //      if(card to check has the same CardHandID as the passed in CardHandID)
        //      {
        //          call DiscardThisCard() on the card that matches the given CardHandID
        //          exit this loop
        //      }
        //}



        ////////use a dynamic array of all the cards in the player's hand instead of the card ID variable to find each card

    }
}

