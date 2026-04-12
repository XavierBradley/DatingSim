using UnityEngine;

public class FirstChoiceManager : MonoBehaviour
{
    public void SelectOption(ChoiceTrigger option)
    {
        // Check item requirement
        if (option.requiredItem != null)
        {
            if (!Inventory.Instance.HasItem(option.requiredItem))
            {
                Debug.Log("Missing required item.");
                return;
            }

            Inventory.Instance.RemoveItem(option.requiredItem);
        }

        // Track story choice
        switch (option.helpsCharacter)
        {
            case CharacterChoice.CharacterA:
                ChoicesTracker.Instance.characterAFirstChoice = true;
                break;

            case CharacterChoice.CharacterB:
                ChoicesTracker.Instance.characterBFirstChoice = true;
                break;
        }

        Debug.Log("Chose: " + option.helpsCharacter);
    }
}
