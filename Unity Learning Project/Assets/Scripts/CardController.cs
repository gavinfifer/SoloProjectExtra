using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardController : MonoBehaviour
{
    private Vector3 StartPos = new Vector3(1, -3, 0);
    public float MoveSpeed = 5;
    Vector3 TargetPos;

    // Start is called before the first frame update
    void Start()
    {
        //initially sets variables needed to determine the current position and target position for the card
        TargetPos = StartPos;
        transform.position = StartPos;
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

    //called on the top card in the player deck
    public void DrawCard()
    {
        //tells the card to move to a new position
        TargetPos = new Vector3(0, 0, 0);
    }
}
