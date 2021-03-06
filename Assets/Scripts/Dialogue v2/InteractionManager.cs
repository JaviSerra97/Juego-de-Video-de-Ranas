﻿using System.Collections;
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
    private bool aux = false;
    private AudioManager audioManager;

    void Start()
    {
        dialogueManager = GameObject.FindObjectOfType<DialogueManager>().GetComponent<DialogueManager>();
        audioManager = GameObject.FindObjectOfType<AudioManager>().GetComponent<AudioManager>();
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
        if(convIndex > 0) { aux = true; }
        if (convIndex < limitOfConversations - 1) { convIndex++; }
    }

    void NormalToCubism()
    {
        anim.Play("NormalToCubism");
        audioManager.playTransformation();
    }
    void CubismToNormal()
    {
        audioManager.playTransformationBack();
        anim.Play("CubismToNormal");
    }
    void NormalToBlanchard()
    {
        audioManager.playTransformation();
        anim.Play("NormalToBlanchard");
    }
    void BlanchardToNormal()
    {
        audioManager.playTransformationBack();
        anim.Play("BlanchardToNormal");
    }

    void SaturnoSit()
    {
       GetComponent<SaturnoInteraction>().SaturnoSit();
    }

    void VenusLay()
    {
        GetComponent<VenusInteraction>().VenusLay();
    }

    void SitSprite()
    {
        anim.Play("Sit");
        anim.SetBool("Walking", false);
    }

    public void NormalSprite()
    {
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;

        anim.Play("BackIdle");
    }

    void ToEatSprite()
    {
        anim.Play("ToEat");
    }

    void EatingSprite()
    {
        audioManager.playMunching();
        anim.Play("Eating");
    }

    void EnableGuard()
    {
        GetComponent<SaturnoInteraction>().EnableGuard();
    }

    void DisableGuard()
    {
        GetComponent<SaturnoInteraction>().DisableGuard();
    }

    void CleanerSprite()
    {
        if (aux) { GetComponent<Animator>().Play("Idle"); }
        else { nextInteraction--; }
    }

    void EndCleanerInteraction()
    {
        GetComponent<CleanerInteraction>().EndInteraction();
        this.enabled = false;
    }

    void MeninasPaint()
    {
        //Aqui se activa el sonido de pintar y se desbloquea el dibujo.
    }

    void VenusPaint()
    {
        //Aqui se activa el sonido de pintar y se desbloquea el dibujo.
    }

    void GetItems()
    {
        GetComponent<RecepInteraction>().GetItems();
    }

    void DisableCollider()
    {
        GetComponent<RecepInteraction>().DisableCollider();
    }
}
