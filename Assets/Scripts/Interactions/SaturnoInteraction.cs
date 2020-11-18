using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaturnoInteraction : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public Transform playerPos;
    public Transform playerFinalPos;
    public Transform playerSitPos;
    public GameObject guard;
    public Transform guardPosition;
    public float guardSpeed;
    private bool goSit;
    private bool enableGuard;
    private Vector3 guardInitialPos;
    private bool isSat;
    private bool aux = false;

    public InteractionMarker marker;
    public ConversationManager convManager;

    private void Start()
    {
        guardInitialPos = guard.transform.position;
    }

    private void Update()
    {
        
        if (goSit) 
        {
            if (!aux)
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos.position, playerSpeed * Time.deltaTime);
                if (player.transform.position == playerPos.position) { aux = true; }
            }
            else
            {
                player.transform.position = Vector3.MoveTowards(player.transform.position, playerFinalPos.position, playerSpeed * Time.deltaTime);
                if (player.transform.position == playerFinalPos.position) { if (!isSat) { SitSprite(); } }
            }
        }

        if (enableGuard)
        {
            guard.transform.position = Vector3.MoveTowards(guard.transform.position, guardPosition.position, guardSpeed * Time.deltaTime);
            if(guard.transform.position == guardPosition.position) { guard.GetComponent<Animator>().Play("GuardIdle"); }
        }
        else
        {
            if (guard.activeSelf)
            {
                guard.transform.rotation = Quaternion.Euler(Vector3.zero);
                guard.transform.position = Vector3.MoveTowards(guard.transform.position, guardInitialPos, guardSpeed * Time.deltaTime);
                if(guard.transform.position == guardInitialPos) 
                {
                    marker.enabled = true;
                    convManager.enabled = true;
                    guard.SetActive(false); 
                }
            }
        }
    }

    public void SaturnoSit()
    {
        playerPos.position = new Vector3(playerPos.position.x, player.transform.position.y, playerPos.position.z);
        goSit = true;
        var anim = player.GetComponent<Animator>();
        anim.SetBool("WalkRight", false);
        anim.SetBool("WalkFront", false);
        anim.SetBool("WalkBack", false);
        anim.SetBool("Walking", true);
        anim.SetBool("WalkLeft", true);
    }

    void SitSprite()
    {
        goSit = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.transform.position = playerSitPos.position;
        player.GetComponent<Animator>().Play("Sit");
        isSat = true;
    }

    public void EnableGuard()
    {
        guard.SetActive(true);
        guard.GetComponent<Animator>().Play("GuardWalk");
        enableGuard = true;
        guardPosition.position = new Vector3(guardPosition.position.x, guard.transform.position.y, guardPosition.position.z);
    }

    public void DisableGuard()
    {
        guard.GetComponent<Animator>().Play("GuardWalk");
        enableGuard = false;
    }
}
