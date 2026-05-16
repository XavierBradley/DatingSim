using UnityEngine;

public class ItemPickupInteractable : MonoBehaviour, IInteractable
{
    [SerializeField] private Items itemToGive;
    [SerializeField] private bool canOnlyCollectOnce = true;

    private bool hasCollected = false;

    public void Interact()
    {
        if (canOnlyCollectOnce && hasCollected)
        {
            Debug.Log("Nothing left here.");
            return;
        }

        if (itemToGive == null)
        {
            Debug.LogWarning("No item assigned.");
            return;
        }

        if (Inventory.Instance == null)
        {
            Debug.LogWarning("No Inventory found in scene.");
            return;
        }

        Inventory.Instance.AddItem(itemToGive);
        hasCollected = true;

        Debug.Log("Picked up: " + itemToGive.itemName);
    }

    public string GetInteractText()
    {
        if (canOnlyCollectOnce && hasCollected)
        {
            return "Nothing left here";
        }

        if (itemToGive == null)
        {
            return "Press E to interact";
        }

        return "Press E to take " + itemToGive.itemName;
    }
}