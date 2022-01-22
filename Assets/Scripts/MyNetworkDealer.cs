using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mirror;

public class MyNetworkDealer : NetworkManager
{


    [SerializeField] int money;
    [SerializeField] int smallBlind;

    [Header("Dealer Function")]
    [SerializeField] GameObject deck;
    [SerializeField] GameObject[] communityCards;

    int turn = 0;

    
    

    public override void OnClientConnect()
    {
        base.OnClientConnect();

        Debug.Log("I connected to a server!");   
    }

    public override void OnServerAddPlayer(NetworkConnection conn)
    {
        base.OnServerAddPlayer(conn);
        MyNetworkGambler player = conn.identity.GetComponent<MyNetworkGambler>();

        //initalize player
        player.setUsername($"Player {numPlayers}");
        player.setMoney(money);

        Debug.Log("There are now" + this.numPlayers + "players on the server" );
        
    }



    [ContextMenu("Deal Card")] private void DealCard(){ 
        Sprite sprite = deck.GetComponent<Deck>().DealCard();
        communityCards[turn].GetComponent<Image>().sprite = sprite;
        communityCards[turn].GetComponent<Image>().color = new Color(1f,1f,1f,1f);
        turn++;
    }
}