using NUnit.Framework.Interfaces;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Items item;

    private void OnMouseDown() // change to actual button for final game
    {
        Inventory.Instance.AddItem(item);
        Destroy(gameObject);
    }
}