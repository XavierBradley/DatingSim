using UnityEngine;
using System.Collections.Generic;

public class ChoicesTracker : MonoBehaviour
{
    public static ChoicesTracker Instance;

    // STORY FLAGS
    public HashSet<string> flags = new HashSet<string>();

    // STORY PHASE
    public enum StoryPhase
    {
        Early,
        Mid,
        Late
    }

    public StoryPhase currentPhase = StoryPhase.Early;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // FLAGS
    public void SetFlag(string flag)
    {
        flags.Add(flag);
        Debug.Log("Flag added: " + flag);
    }

    public bool HasFlag(string flag)
    {
        return flags.Contains(flag);
    }

    // PHASES
    public void SetPhase(StoryPhase phase)
    {
        currentPhase = phase;
        Debug.Log("Story phase set to: " + phase);
    }
}