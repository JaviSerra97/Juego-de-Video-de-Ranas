using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyCharacterController : MonoBehaviour
{
    public string vAxis;
    public string hAxis;
    public string actionAxis;

    public float moveSpeed;
    
    private Rigidbody rb;
    private Vector3 desp;
    public bool canInteract = false;
    private ConversationManager convManager;
    public DialogueManager diaManager;
    private bool axisPressed = false;
    private bool isInteracting = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        if (isInteracting) { return; }
        desp = new Vector3(Input.GetAxisRaw(hAxis),0,Input.GetAxisRaw(vAxis)) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + desp);
    }

    private void Update()
    {
        if(Input.GetAxisRaw(actionAxis) != 0)
        {
            axisPressed = true;
            if (canInteract) { StartConversation(); }
        }
        else
        {
            if (axisPressed && isInteracting)
            {
                axisPressed = false;
                diaManager.ReadNext();
            }
        }
    }

    void StartConversation()
    {
        isInteracting = true;
        canInteract = false;
        convManager.StartConv();
    }

    public void EndInteraction()
    {
        isInteracting = false;
        canInteract = true;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            canInteract = true;
            convManager = other.gameObject.GetComponent<ConversationManager>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC") 
        {
            canInteract = false;
            convManager = null;
        }
    }
}
