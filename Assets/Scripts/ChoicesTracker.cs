using UnityEngine;

public class ChoicesTracker : MonoBehaviour
{
    public static ChoicesTracker Instance;
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

    public bool characterAFirstChoice = false;
    public bool characterBFirstChoice = false;
    public bool characterASecondChoice = false;
    public bool characterBSecondChoice = false;
}
