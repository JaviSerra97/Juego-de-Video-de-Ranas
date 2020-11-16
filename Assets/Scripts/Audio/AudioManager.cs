using UnityEngine;

public class AudioManager : MonoBehaviour
{
    [FMODUnity.EventRef]
    public string music;
    [FMODUnity.EventRef]
    public string movement;

    FMOD.Studio.EventInstance musicEV;
    FMOD.Studio.EventInstance movementMusic;

    private bool movementActivated = false;
    private Transform cameraPos;

    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        musicEV = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEV.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
        musicEV.start();
        
        
        movementMusic = FMODUnity.RuntimeManager.CreateInstance(movement);
        //movementMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
    }

    private void Update()
    {
        movementMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
    }

    public void UnlockMusic()
    {
        musicEV.setParameterByName("Unlock", 1f);
    }
    
    public void PlayMovementAudio()
    {
        if (!movementActivated) 
        {
            movementMusic.start();
            movementActivated = true;
        }
    }
    public void StopMovementAudio()
    {
        if (movementActivated)
        {
            movementMusic.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            movementActivated = false;
        }
    }
    
}
