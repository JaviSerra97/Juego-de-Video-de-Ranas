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
    private InteractionManager intManager;
    public DialogueManager diaManager;
    private bool axisPressed = false;
    public bool isInteracting = false;
    private Animator anim;
    public AudioManager audioManager;
    private bool isInInteraction = false;

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    
    private void FixedUpdate()
    {
        if (isInteracting) { return; }

        desp = new Vector3(Input.GetAxisRaw(hAxis), 0, Input.GetAxisRaw(vAxis));

        if (desp.x < 0.2f && desp.x > -0.2f) { desp.x = 0; }
        if (desp.z < 0.2f && desp.z > -0.2f) { desp.z = 0; }

        rb.MovePosition(rb.position + (desp * moveSpeed * Time.deltaTime));

        MovementAnimations(desp);
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
        anim.SetBool("Walking", false);
        isInteracting = true;
        canInteract = false;
        if (convManager) { convManager.StartConv(); }
        if (intManager) { intManager.StartConv(); }
    }

    public void EndInteraction()
    {
        isInteracting = false;
        if (isInInteraction) { canInteract = true; }
        else
        {
            convManager = null;
            intManager = null;
        }
    }

    void MovementAnimations(Vector3 desp)
    {
        if (desp == Vector3.zero) 
        {
            audioManager.StopMovementAudio();
            anim.SetBool("Walking", false); 
        }
        else 
        {
            // Careful with this...
            audioManager.PlayMovementAudio();
            anim.SetBool("Walking", true);
            if (desp.x > 0.2f)
            {
                anim.SetBool("WalkFront", false);
                anim.SetBool("WalkBack", false);
                anim.SetBool("WalkLeft", false);
                anim.SetBool("WalkRight", true);
            }
            else if (desp.x < -0.2f)
            {
                anim.SetBool("WalkFront", false);
                anim.SetBool("WalkBack", false);
                anim.SetBool("WalkRight", false);
                anim.SetBool("WalkLeft", true);
            }
            else
            {
                if ((desp.z > 0.2f))
                {
                    anim.SetBool("WalkBack", false);
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkFront", true);
                }
                if ((desp.z < -0.2f))
                {
                    anim.SetBool("WalkRight", false);
                    anim.SetBool("WalkLeft", false);
                    anim.SetBool("WalkFront", false);
                    anim.SetBool("WalkBack", true);
                }
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "NPC")
        {
            canInteract = true;
            if (other.gameObject.GetComponent<ConversationManager>())
            {
                other.gameObject.GetComponent<ConversationManager>().enabled = true;
                convManager = other.gameObject.GetComponent<ConversationManager>();
            }
            if (other.gameObject.GetComponent<InteractionManager>())
            {
                other.gameObject.GetComponent<InteractionManager>().enabled = true;
                intManager = other.gameObject.GetComponent<InteractionManager>();
            }
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "NPC")
        {
            isInInteraction = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "NPC") 
        {
            canInteract = false;
            isInInteraction = false;
            if (other.gameObject.GetComponent<ConversationManager>() && !isInteracting)
            {
                other.gameObject.GetComponent<ConversationManager>().enabled = false;
                convManager = null;
            }
            if (other.gameObject.GetComponent<InteractionManager>() && !isInteracting)
            {
                other.gameObject.GetComponent<InteractionManager>().enabled = false;
                intManager = null;
            }
        }
    }
}
