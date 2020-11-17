using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionManager : MonoBehaviour
{
    [System.Serializable]
    public class NewInteraction
    {
        public int lineInteraction;
        public string interactionFunction;
    }
    [Header("Conversations List")]
    public Conversation[] listOfConversations;
    [Header("Interactions List")]
    public NewInteraction[] interactionsList;

    private int limitOfConversations;
    private int convIndex = 0;
    private DialogueManager dialogueManager;
    private int currentDialogueLine;
    private bool startedFunction = false;
    private int nextInteraction = 0;
    private Animator anim;
    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        convIndex = 0;
        limitOfConversations = listOfConversations.Length;
        anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
    }

    private void Update()
    {
        currentDialogueLine = dialogueManager.GetConversationLine();

        if(nextInteraction >= interactionsList.Length) { return; }
        if(currentDialogueLine == interactionsList[nextInteraction].lineInteraction) 
        {
            if (!startedFunction)
            {
                startedFunction = true;
                Invoke(interactionsList[nextInteraction].interactionFunction, 0f);
                nextInteraction++;
            }
        }
        else { startedFunction = false; }
    }

    public void StartConv()
    {
        DialogueManager.StartConversation(listOfConversations[convIndex]);
        if (convIndex < limitOfConversations - 1) { convIndex++; }
    }

    void NormalToCubism()
    {
        anim.Play("NormalToCubism");
    }
    void CubismToNormal()
    {
        anim.Play("CubismToNormal");
    }

    void SaturnoGuard()
    {

    }

    void SitSprite()
    {

    }

    void SpriteToEat()
    {

    }

    void EatingSprite()
    {

    }
}
