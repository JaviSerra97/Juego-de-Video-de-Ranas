using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractionMarker : MonoBehaviour
{
    public Material outlineMaterial;
    public Material interactableOutline;
    private SpriteRenderer myRenderer;

    void Start()
    {
        myRenderer = GetComponent<SpriteRenderer>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            myRenderer.material = interactableOutline;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            myRenderer.material = outlineMaterial;
        }
    }
}
