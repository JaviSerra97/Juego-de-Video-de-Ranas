using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RecepInteraction : MonoBehaviour
{
    public GameObject map;
    public GameObject note;
    public GameObject startCollider;
    public Conversation[] listOfConv;
    private InteractionManager intManager;
    private int index;
    private void Start()
    {
        intManager = GetComponent<InteractionManager>();
    }

    private void Update()
    {

    }

    void UpdateDialogue()
    {
        intManager.listOfConversations[1] = listOfConv[index];
    }

    public void GetItems()
    {
        map.SetActive(true);
        note.SetActive(true);
    }

    public void DisableCollider()
    {
        startCollider.SetActive(false);
    }
}
