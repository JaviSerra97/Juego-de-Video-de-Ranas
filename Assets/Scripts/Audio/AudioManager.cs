using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string music;
    [FMODUnity.EventRef]
    public string movement;

    FMOD.Studio.EventInstance musicEV;
    //FMOD.Studio.EventInstance movementMusic;

    private bool movementActivated = false;

    void Start()
    {
        musicEV = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEV.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        musicEV.start();
        
        /*
        movementMusic = FMODUnity.RuntimeManager.CreateInstance(movement);
        movementMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(gameObject.transform));
        */
    }

    /*public void UnlockMusic()
    {
        musicEV.setParameterByName("Unlock", 1f);
    }
    
    public void PlayMovementAudio()
    {
        if (!movementActivated) 
        {
            movementMusic.start();
            movementActivated = true;
            Debug.Log("Play");
        }
    }
    public void StopMovementAudio()
    {
        if (movementActivated)
        {
            movementMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            movementActivated = false;
            Debug.Log("Stop");
        }
    }
    */
}
