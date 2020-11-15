﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using TMPro;

public class DialogueManager : MonoBehaviour
{
    public TextMeshProUGUI speakerName;
    public TextMeshProUGUI dialogue;
    public Image speakerSprite;
    public float textSpeed;
    public MyCharacterController player;

    private int currentIndex;
    private Conversation currentConv;
    private static DialogueManager instance;
    private Animator anim;
    private Coroutine typing;
    private bool complete = true;

    private void Awake()
    {
        if (instance == null) 
        {
            instance = this;
            anim = GetComponent<Animator>();
        }
        else {Destroy(gameObject); } 
        }

    public static void StartConversation(Conversation conv)
    {
        instance.anim.SetBool("StartConv", true);
        instance.currentIndex = 0;
        instance.currentConv = conv;
        instance.speakerName.text = "";
        instance.dialogue.text = "";

        instance.ReadNext();
    }

    public void ReadNext()
    {
        if (complete)
        {
            if (currentIndex > currentConv.GetLength())
            {
                instance.anim.SetBool("StartConv", false);
                player.EndInteraction();
                return;
            }

            speakerName.text = currentConv.GetLineByIndex(currentIndex).speaker.GetName();

            if (typing == null)
            {
                typing = instance.StartCoroutine(TypeText(currentConv.GetLineByIndex(currentIndex).dialogue));
            }
            else
            {
                instance.StopCoroutine(typing);
                typing = null;
                typing = instance.StartCoroutine(TypeText(currentConv.GetLineByIndex(currentIndex).dialogue));
            }
            speakerSprite.sprite = currentConv.GetLineByIndex(currentIndex).speaker.GetSprite();
            currentIndex++;
        }
    }

    private IEnumerator TypeText(string text)
    {
        dialogue.text = "";
        complete = false;
        int index = 0;

        while (!complete)
        {
            dialogue.text += text[index];
            index++;
            yield return new WaitForSeconds(textSpeed);

            if(index == text.Length)
            {
                complete = true;
            }
        }
        typing = null;
    }
}
