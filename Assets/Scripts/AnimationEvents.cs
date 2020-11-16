using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    private Transform cameraPos;

    private void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();
    }

    void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, cameraPos.position);
        //FMODUnity.RuntimeManager.PlayOneShot(path, Vector3.zero);
    }
}
