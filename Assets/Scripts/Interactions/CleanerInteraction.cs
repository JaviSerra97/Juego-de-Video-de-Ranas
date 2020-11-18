using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CleanerInteraction : MonoBehaviour
{
    public GameObject cube;
    public float moveSpeed;
    public Transform finalPos;
    public ConversationManager conversationManager;
    public InteractionManager interactionManager;
    private Animator anim;
    private bool endInteraction = false;

    private void Start()
    {
        anim = GetComponent<Animator>();    
    }

    private void Update()
    {
        if (endInteraction)
        {
            transform.position = Vector3.MoveTowards(transform.position, finalPos.position, moveSpeed * Time.deltaTime);
            if(transform.position == finalPos.position)
            {
                NewInteraction();
            }
        }
    }

    public void FrontSprite()
    {
        anim.Play("Idle");
    }

    public void EndInteraction()
    {
        endInteraction = true;
        cube.SetActive(false);
        anim.Play("Clean");
    }

    public void NewInteraction()
    {
        endInteraction = false;
        cube.SetActive(true);
        anim.Play("Idle");
        GetComponent<InteractionManager>().enabled = false;
        GetComponent<ConversationManager>().enabled = true;
    }
}
