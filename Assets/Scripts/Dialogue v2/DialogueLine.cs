#pragma warning disable 0649
using UnityEngine;

[System.Serializable]
public class DialogueLine
{
    public Speaker speaker;
    [TextArea(3, 10)]
    public string dialogue;
}
