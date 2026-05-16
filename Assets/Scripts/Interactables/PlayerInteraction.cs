using UnityEngine;

public class PlayerInteraction : MonoBehaviour
{
    [SerializeField] private float interactRange = 1.2f;
    [SerializeField] private GameObject interactPrompt;

    private IInteractable currentInteractable;

    private void Update()
    {
        FindClosestInteractable();

        if (interactPrompt != null)
        {
            interactPrompt.SetActive(currentInteractable != null);
        }

        if (currentInteractable != null && Input.GetKeyDown(KeyCode.E))
        {
            currentInteractable.Interact();
        }
    }

    private void FindClosestInteractable()
    {
        currentInteractable = null;

        Collider2D[] hits = Physics2D.OverlapCircleAll(transform.position, interactRange);

        foreach (Collider2D hit in hits)
        {
            IInteractable interactable = hit.GetComponent<IInteractable>();

            if (interactable != null)
            {
                currentInteractable = interactable;
                return;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, interactRange);
    }
}