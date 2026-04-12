using UnityEngine;

public class SecondChoiceManager : MonoBehaviour
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
                ChoicesTracker.Instance.characterASecondChoice = true;
                break;

            case CharacterChoice.CharacterB:
                ChoicesTracker.Instance.characterBSecondChoice = true;
                break;
        }

        Debug.Log("Chose: " + option.helpsCharacter);
    }
}
