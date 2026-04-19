using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class DialogueOption
{
    public string optionText;
    public DialogueNode nextNode;

    public ChoiceTrigger choiceTrigger;

    // MULTIPLE REQUIRED FLAGS (ALL must be true)
    public List<string> requiredFlags = new List<string>();

    //  BLOCKED FLAGS (NONE of these can be true)
    public List<string> blockedFlags = new List<string>();

    // PHASE REQUIREMENT
    public bool usePhaseRequirement;
    public ChoicesTracker.StoryPhase requiredPhase;
}