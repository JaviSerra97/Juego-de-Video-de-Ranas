#pragma warning disable 0649
using UnityEngine;

[CreateAssetMenu(fileName = "New Conversation", menuName = "Dialogues/New Conversation")]
public class Conversation : ScriptableObject
{
    [SerializeField]
    private DialogueLine[] linesList;

    public DialogueLine GetLineByIndex(int index)
    {
        return linesList[index];
    }

    public int GetLength()
    {
        return linesList.Length - 1;
    }
}
