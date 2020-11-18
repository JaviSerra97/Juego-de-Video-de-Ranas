using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VenusInteraction : MonoBehaviour
{
    public GameObject player;
    public float playerSpeed;
    public Transform playerPos;
    public Transform layPos;
    private bool goLay;
    private bool isLaid;

    private void Update()
    {
        if (goLay)
        {
            player.transform.position = Vector3.MoveTowards(player.transform.position, playerPos.position, playerSpeed * Time.deltaTime);
            if (player.transform.position == playerPos.position) { if (!isLaid) { LaySprite(); } }
        }
    }

    public void VenusLay()
    {
        goLay = true;
        var anim = player.GetComponent<Animator>();
        anim.SetBool("WalkRight", false);
        anim.SetBool("WalkFront", false);
        anim.SetBool("WalkLeft", false);
        anim.SetBool("WalkBack", true);
        anim.SetBool("Walking", true);
    }

    void LaySprite()
    {
        goLay = false;
        GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePosition;
        player.transform.position = layPos.position;
        player.GetComponent<Animator>().Play("Lay");
        isLaid = true;
    }
}
