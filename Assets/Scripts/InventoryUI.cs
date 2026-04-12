using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryUI : MonoBehaviour
{
    public List<Image> slotIcons;

    private void Start()
    {
       // UpdateUI(Inventory.Instance.items);
    }

    public void UpdateUI(List<Items> items)
    {
        for (int i = 0; i < slotIcons.Count; i++)
        {
            if (i < items.Count)
            {
                slotIcons[i].sprite = items[i].icon;
                slotIcons[i].gameObject.SetActive(true);
            }

       //keeping commented out, will find a way to re-implement in a way that doesn't break inventory if/when we decide to actually expend inventory slots
         //   else
           // {
          //      slotIcons[i].gameObject.SetActive(false);
           // }
        }
    }
}