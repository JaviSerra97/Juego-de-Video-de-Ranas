using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConversationManager : MonoBehaviour
{
    public Conversation[] listOfConversations;
    public int limitOfConversations;
    private int convIndex = 0;

    public void StartConv()
    {
        DialogueManager.StartConversation(listOfConversations[convIndex]);
        if(convIndex < limitOfConversations - 1) { convIndex++; }
    }
}
