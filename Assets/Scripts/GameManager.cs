using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int numOfInteractions = 0;


    private void Update()
    {
        /*
        if (Input.GetKeyDown(KeyCode.N)) { UnlockInteraction(); }
        if (Input.GetKeyDown(KeyCode.B)) { Debug.Log(CheckNumOfInteractions()); }
        */
    }
    public int CheckNumOfInteractions()
    {
        return numOfInteractions;
    }

    public void UnlockInteraction()
    {
        numOfInteractions++;
    }
}
