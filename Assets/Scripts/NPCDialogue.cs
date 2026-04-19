using UnityEngine;

public class NPCDialogue : MonoBehaviour
{
    public DialogueNode earlyNode;
    public DialogueNode midNode;
    public DialogueNode lateNode;

    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            DialogueNode nodeToStart = GetNodeForCurrentPhase();

            if (nodeToStart != null)
            {
                DialogueManager.Instance.StartDialogue(nodeToStart);
            }
            else
            {
                Debug.LogWarning("No dialogue node assigned for current phase!");
            }
        }
    }

    DialogueNode GetNodeForCurrentPhase()
    {
        switch (ChoicesTracker.Instance.currentPhase)
        {
            case ChoicesTracker.StoryPhase.Early:
                return earlyNode;

            case ChoicesTracker.StoryPhase.Mid:
                return midNode != null ? midNode : earlyNode;

            case ChoicesTracker.StoryPhase.Late:
                return lateNode != null ? lateNode : midNode;

            default:
                return earlyNode;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = true;
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
            playerInRange = false;
    }
}