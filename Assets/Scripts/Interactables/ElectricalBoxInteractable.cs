using UnityEngine;

public class ElectricalBoxInteractable : MonoBehaviour, IInteractable
{
    public void Interact()
    {
        if (LightManager.Instance == null)
        {
            Debug.LogWarning("No LightManager found in scene.");
            return;
        }

        LightManager.Instance.ToggleLights();
    }

    public string GetInteractText()
    {
        return "Press E to toggle lights";
    }
}