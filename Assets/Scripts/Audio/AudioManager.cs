using UnityEngine;

public class AudioManager : MonoBehaviour
{

    [FMODUnity.EventRef]
    public string music;

    [FMODUnity.EventRef]
    public string movement;

    [FMODUnity.EventRef]
    public string closeDialogue;

    [FMODUnity.EventRef]
    public string closeNotebook;

    [FMODUnity.EventRef]
    public string draw;

    [FMODUnity.EventRef]
    public string interactArt;

    [FMODUnity.EventRef]
    public string munching;

    [FMODUnity.EventRef]
    public string openDialogue;

    [FMODUnity.EventRef]
    public string openFood;

    [FMODUnity.EventRef]
    public string openNotebook;

    [FMODUnity.EventRef]
    public string pens;

    [FMODUnity.EventRef]
    public string sitOnBench;

    [FMODUnity.EventRef]
    public string spriteTurn;

    [FMODUnity.EventRef]
    public string stepsMarble;

    [FMODUnity.EventRef]
    public string stepsWood;

    [FMODUnity.EventRef]
    public string typeWriter;

    [FMODUnity.EventRef]
    public string transformation;

    [FMODUnity.EventRef]
    public string transformationBack;

    [FMODUnity.EventRef]
    public string openMap;

    [FMODUnity.EventRef]
    public string closeMap;

    [FMODUnity.EventRef]
    public string notepad;

    [FMODUnity.EventRef]
    public string page;

    public float musicLayers = 0f;

    public Expression facepalm = new Expression("facepalm");
    public Expression fear = new Expression("fear");
    public Expression fear_loud = new Expression("fear_loud");
    public Expression gasp = new Expression("gasp");
    public Expression happy = new Expression("happy");
    public Expression happysad = new Expression("happysad");
    public Expression proud = new Expression("proud");
    public Expression sad = new Expression("sad");
    public Expression surprised = new Expression("suprised");
    public Expression thinking = new Expression("thinking");
    public Expression worried = new Expression("worried");

    public class Expression
    {
        string name = "";
        public Expression (string name)
        {
            this.name = name;
        }

        public string getName() { return this.name;  }
        public string getFullpath() { return "event:/SFX/expressions/" + name; }
    }


    FMOD.Studio.EventInstance musicEV;
    FMOD.Studio.EventInstance movementAudio;

    private bool movementActivated = false;
    private Transform cameraPos;

    void Start()
    {
        cameraPos = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Transform>();

        musicEV = FMODUnity.RuntimeManager.CreateInstance(music);
        musicEV.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
        musicEV.setParameterByName("capas", this.musicLayers);
        //musicEV.start();


        movementAudio = FMODUnity.RuntimeManager.CreateInstance(movement);
        //movementMusic.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
    }

    private void Update()
    {
        movementAudio.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
    }

    public void UnlockMusic()
    {
        musicEV.setParameterByName("Unlock", 1f);
    }
    
    public void PlayMovementAudio()
    {
        if (!movementActivated) 
        {
            movementAudio.start();
            movementActivated = true;
        }
    }
    public void StopMovementAudio()
    {
        if (movementActivated)
        {
            movementAudio.stop(FMOD.Studio.STOP_MODE.IMMEDIATE);
            movementActivated = false;
        }
    }

    public void playCloseDialogue()
    {
        playOneShot(closeDialogue);
    }

    public void playCloseNotebook()
    {
        playOneShot(closeNotebook);
    }


    public void playDraw()
    {
        playOneShot(draw);
    }

    public void playInteractArt()
    {
        playOneShot(interactArt);
    }

    public void playMunching()
    {
        playOneShot(munching);
    }

    public void playOpenDialogue()
    {
        playOneShot(openDialogue);
    }

    public void playOpenFood()
    {
        playOneShot(openFood);
    }

    public void playOpenNoteBook()
    {
        playOneShot(openNotebook);
    }

    public void playPens()
    {
        playOneShot(pens);
    }

    public void playSitOnBench()
    {
        playOneShot(sitOnBench);
    }

    public void playSpriteTurn()
    {
        playOneShot(spriteTurn);
    }

    public void playStepsMarble()
    {
        playOneShot(stepsMarble);
    }

    public void playStepsWood()
    {
        playOneShot(stepsWood);
    }

    
    public void playTypeWrite()
    {
        playOneShot(typeWriter);
    }

    public void playTransformation()
    {
        playOneShot(transformation);
    }

    public void playTransformationBack()
    {
        playOneShot(transformationBack);
    }

    public void playOpenMap()
    {
        playOneShot(openMap);
    }

    public void playCloseMap()
    {
        playOneShot(closeMap);
    }

    public void playNotepad()
    {
        playOneShot(notepad);
    }

    public void playPage()
    {
        playOneShot(page);
    }

    public void playExpression(Expression expression)
    {
        playOneShot(expression.getFullpath());
    }

    public void nextMusicLayer()
    {
        this.musicLayers += 0.2f;
        musicEV.setParameterByName("capas", this.musicLayers);
    }

    private void playOneShot(string name)
    {
        FMOD.Studio.EventInstance fmodEvent;
        fmodEvent = FMODUnity.RuntimeManager.CreateInstance(name);
        fmodEvent.set3DAttributes(FMODUnity.RuntimeUtils.To3DAttributes(cameraPos));
        fmodEvent.start();
        fmodEvent.release();
    }
    
}
