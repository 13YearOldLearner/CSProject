using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mirror;

public class MyNetworkGambler : NetworkBehaviour
{
    [SyncVar (hook = nameof(HandleDisplayUsernameUpdated))][SerializeField] string UserName;
    [SyncVar (hook = nameof(HandleDisplayMoneyUpdated))][SerializeField] int money;
    
    //private SyncList<string> blacklist;

    #region Server
    [Server]public void setUsername(string name){

        /*foreach(string s in blacklist){
            if(name.Contains(s)){
                Debug.Log("the fuck is wrong with you");
                return;
            }
        }*/

        this.UserName = name;
    }

    [Server] public void setMoney(int money){
        this.money = money;
    }

    /*[Server] public void setCards(int i, GameObject card){
        this.communityCards[i] = card;
    }*/

    #endregion
    
    #region Client
    private void HandleDisplayUsernameUpdated(string oldUsername, string newUsername){
        //UserName = newUsername;
    }

    private void HandleDisplayMoneyUpdated(int oldMoney, int newMoney){
        //money = newMoney;
    }

    private void HandleDisplayCardUpdated(GameObject[] oldcard, GameObject[] newCard){
        
    }
    #endregion

    
}
