using UnityEngine;

[System.Serializable]
public class DokiDialogueLine
{
    public string characterName;
    public Sprite characterSprite;
    [TextArea(2, 5)]
    public string text;
}
