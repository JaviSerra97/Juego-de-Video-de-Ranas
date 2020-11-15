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
    private bool canInteract = false;
    private TestConversation test;

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
        test.StartConv();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Interactable")
        {
            canInteract = true;
            test = other.gameObject.GetComponent<TestConversation>();
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Interactable") 
        {
            canInteract = false;
            test = null;
        }
    }
}
