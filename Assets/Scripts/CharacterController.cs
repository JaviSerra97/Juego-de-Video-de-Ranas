using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MonoBehaviour
{
    public string vAxis;
    public string hAxis;
    public string actionAxis;

    public float moveSpeed;
    
    private Rigidbody rb;
    private Vector3 desp;
    public bool canInteract = false;
    private ConversationManager convManager;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        desp = new Vector3(Input.GetAxisRaw(hAxis),0,Input.GetAxisRaw(vAxis)) * moveSpeed * Time.deltaTime;
        rb.MovePosition(rb.position + desp);
    }

    private void Update()
    {
        if(Input.GetAxisRaw(actionAxis) != 0 && canInteract)
        {
            StartInteraction();
        }
    }

    void StartInteraction()
    {
        canInteract = false;
        convManager.StartConv();
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
        if (other.tag == "Interactable") 
        {
            canInteract = false;
            convManager = null;
        }
    }
}
