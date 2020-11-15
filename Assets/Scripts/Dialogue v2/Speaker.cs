#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "New Speaker", menuName = "Dialogues/New Speaker")]
public class Speaker : ScriptableObject
{
    [SerializeField]
    private string speakerName;
    [SerializeField]
    private Sprite speakerSprite;

    public string GetName() { return speakerName; }
    public Sprite GetSprite() { return speakerSprite; }
}
