using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Deck : MonoBehaviour
{
    [Header("Deck")]
    [SerializeField] List<Sprite> deck = new List<Sprite>();


    public Sprite DealCard(){
        int newCard = UnityEngine.Random.Range(0,deck.Count);
        Sprite card = deck[newCard];
        deck.Remove(deck[newCard]);
        
        return card;
    }
}
