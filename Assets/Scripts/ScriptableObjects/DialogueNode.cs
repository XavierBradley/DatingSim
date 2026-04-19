using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DialogueNode", menuName = "Dialogue/Node")]
public class DialogueNode : ScriptableObject
{
    [TextArea]
    public string defaultText;

    public List<ConditionalDialogue> conditionalTexts = new List<ConditionalDialogue>();

    public Sprite locationImage;
    public Sprite playerSprite;
    public Sprite npcSprite;

    public List<DialogueOption> options = new List<DialogueOption>();
}