using System;
using UnityEngine;

[Serializable]
public class ChoiceTrigger
{
    public string text;

    public Items requiredItem;

    // FLAG SETTING
    public string setsFlag;

    // PHASE CHANGE
    public bool changesPhase;
    public ChoicesTracker.StoryPhase newPhase;
}