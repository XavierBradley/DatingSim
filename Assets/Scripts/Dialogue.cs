using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public GameObject dialogueUI;
    public GameObject livingRoomText;
    private bool playerInRange = false;

    void Update()
    {
        if (playerInRange && Input.GetKeyDown(KeyCode.E))
        {
            dialogueUI.SetActive(true);
            livingRoomText.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            playerInRange = false;
            dialogueUI.SetActive(false);
            livingRoomText.SetActive(true);
        }
    }
}
