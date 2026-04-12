using NUnit.Framework.Interfaces;
using System;

public enum CharacterChoice
{
    None,
    CharacterA,
    CharacterB
}

[Serializable]

//might need to rework to actually implement it in a specific dialogue option
public class ChoiceTrigger
{
    public string text;
    public Items requiredItem;
    public CharacterChoice helpsCharacter;
}