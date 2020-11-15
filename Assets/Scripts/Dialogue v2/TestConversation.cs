using UnityEngine;

public class TestConversation : MonoBehaviour
{
    public Conversation conv;

    public void StartConv()
    {
        DialogueManager.StartConversation(conv);
    }
}
