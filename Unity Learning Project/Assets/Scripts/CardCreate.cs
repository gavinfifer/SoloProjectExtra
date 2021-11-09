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
        //if the card ID passed in exists then it calls it's discard function
        if(CardHandID < CardController.CardHandTotal)
        {
            CardController.CardInHandList[CardHandID].DiscardThisCard();
        }


    }
}

