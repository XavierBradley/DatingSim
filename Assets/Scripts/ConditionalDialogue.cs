using System;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class ConditionalDialogue
{
    [TextArea]
    public string text;

    public List<string> requiredFlags = new List<string>();
    public List<string> blockedFlags = new List<string>();

    public bool usePhaseRequirement;
    public ChoicesTracker.StoryPhase requiredPhase;
}