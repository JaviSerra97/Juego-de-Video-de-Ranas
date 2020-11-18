using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    public Conversation[] listOfConversations;
    private int limitOfConversations;
    private int convIndex = 0;
    
    void Start()
    {
        convIndex = 0;
        limitOfConversations = listOfConversations.Length;
    }

    public void StartConv()
    {
        DialogueManager.StartConversation(listOfConversations[convIndex]);
        if(convIndex < limitOfConversations - 1) { convIndex++; }
    }
}
