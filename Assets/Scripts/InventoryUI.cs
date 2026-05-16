using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    [SerializeField] private Image[] slotImages;

    public void UpdateUI(List<Items> items)
    {
        for (int i = 0; i < slotImages.Length; i++)
        {
            if (i < items.Count && items[i] != null)
            {
                slotImages[i].sprite = items[i].icon;
                slotImages[i].color = Color.white;
            }
            else
            {
                slotImages[i].sprite = null;
                slotImages[i].color = new Color(1f, 1f, 1f, 0.25f);
            }
        }
    }
}