using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ForceStart : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public Transform playerPos;
    private bool interact = false;
    private bool isInteracting = false;
    public InteractionManager intManager;

    private void Update()
    {
        if (interact)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos.position, playerSpeed * Time.deltaTime);
            if (player.transform.position == playerPos.position) { if (!isInteracting) { Interact(); } }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            ForceInteraction();
        }
    }

    void Interact()
    {
        isInteracting = true;
        var anim = player.GetComponent<Animator>();
        anim.SetBool("Walking", false);
        anim.Play("FrontIdle");
        intManager.StartConv();
    }

    void ForceInteraction()
    {
        player.GetComponent<MyCharacterController>().isInteracting = true;
        var anim = player.GetComponent<Animator>();
        anim.SetBool("WalkRight", false);
        anim.SetBool("WalkFront", false);
        anim.SetBool("WalkBack", false);
        anim.SetBool("WalkLeft", true);
        interact = true;
    }
}
