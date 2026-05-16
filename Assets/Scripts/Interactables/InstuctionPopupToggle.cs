using UnityEngine;

public class InstructionPopupToggle : MonoBehaviour
{
    [SerializeField] private GameObject instructionPopup;

    private void Start()
    {
        instructionPopup.SetActive(false);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            instructionPopup.SetActive(!instructionPopup.activeSelf);
        }
    }
}