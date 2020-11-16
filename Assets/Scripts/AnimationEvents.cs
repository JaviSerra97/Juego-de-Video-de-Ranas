using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationEvents : MonoBehaviour
{
    private FMODUnity.StudioEventEmitter eventEmitterRef;
    void PlaySound(string path)
    {
        FMODUnity.RuntimeManager.PlayOneShot(path, GetComponent<Transform>().position);
        //FMODUnity.RuntimeManager.PlayOneShot(path, Vector3.zero);
    }
}
