using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System.Collections.Generic;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;

    public GameObject dialogueUI;
    public TMP_Text dialogueText;

    public Transform optionsContainer;
    public GameObject optionButtonPrefab;

    public Image locationImageUI;
    public Image playerImageUI;
    public Image npcImageUI;

    private DialogueNode currentNode;

    public List<DialogueOption> options = new List<DialogueOption>();

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void StartDialogue(DialogueNode startNode)
    {
        dialogueUI.SetActive(true);
        Time.timeScale = 0f;
        ShowNode(startNode);
    }

    string GetDialogueText(DialogueNode node)
    {
        foreach (var variant in node.conditionalTexts)
        {
            if (!CanShowConditional(variant))
                continue;

            return variant.text;
        }

        return node.defaultText;
    }

    void ShowNode(DialogueNode node)
    {
        currentNode = node;

        dialogueText.text = GetDialogueText(node);
        locationImageUI.sprite = node.locationImage;
        locationImageUI.gameObject.SetActive(node.locationImage != null);

        playerImageUI.sprite = node.playerSprite;
        playerImageUI.gameObject.SetActive(node.playerSprite != null);

        npcImageUI.sprite = node.npcSprite;
        npcImageUI.gameObject.SetActive(node.npcSprite != null);

        foreach (Transform child in optionsContainer)
        {
            Destroy(child.gameObject);
        }

        foreach (var option in node.options)
        {
            if (!CanShowOption(option)) continue;

            GameObject btn = Instantiate(optionButtonPrefab, optionsContainer);

            TMP_Text label = btn.GetComponentInChildren<TMP_Text>();
            if (label != null)
                label.text = option.optionText;

            Button button = btn.GetComponent<Button>();
            button.onClick.RemoveAllListeners();

            DialogueOption captured = option;

            button.onClick.AddListener(() =>
            {
                SelectOption(captured);
            });
        }
    }

    bool CanShowOption(DialogueOption option)
    {
        // REQUIRED FLAGS (ALL must exist)
        foreach (string flag in option.requiredFlags)
        {
            if (!ChoicesTracker.Instance.HasFlag(flag))
                return false;
        }

        // BLOCKED FLAGS (NONE must exist)
        foreach (string flag in option.blockedFlags)
        {
            if (ChoicesTracker.Instance.HasFlag(flag))
                return false;
        }

        // PHASE CHECK
        if (option.usePhaseRequirement)
        {
            if (ChoicesTracker.Instance.currentPhase != option.requiredPhase)
                return false;
        }

        // ITEM CHECK
        if (option.choiceTrigger != null &&
            option.choiceTrigger.requiredItem != null)
        {
            if (!Inventory.Instance.HasItem(option.choiceTrigger.requiredItem))
                return false;
        }

        return true;
    }

    bool CanShowConditional(ConditionalDialogue cond)
    {
        // REQUIRED FLAGS
        foreach (string flag in cond.requiredFlags)
        {
            if (!ChoicesTracker.Instance.HasFlag(flag))
                return false;
        }

        // BLOCKED FLAGS
        foreach (string flag in cond.blockedFlags)
        {
            if (ChoicesTracker.Instance.HasFlag(flag))
                return false;
        }

        // PHASE
        if (cond.usePhaseRequirement)
        {
            if (ChoicesTracker.Instance.currentPhase != cond.requiredPhase)
                return false;
        }

        return true;
    }
    void SelectOption(DialogueOption option)
    {
        ApplyChoice(option.choiceTrigger);

        if (option.nextNode != null)
        {
            ShowNode(option.nextNode);
        }
        else
        {
            EndDialogue();
        }
    }

    void ApplyChoice(ChoiceTrigger choice)
    {
        if (choice == null) return;

        // ITEM
        if (choice.requiredItem != null)
        {
            if (Inventory.Instance.HasItem(choice.requiredItem))
            {
                Inventory.Instance.RemoveItem(choice.requiredItem);
            }
        }

        // FLAG
        if (!string.IsNullOrEmpty(choice.setsFlag))
        {
            ChoicesTracker.Instance.SetFlag(choice.setsFlag);
        }

        // PHASE CHANGE
        if (choice.changesPhase)
        {
            ChoicesTracker.Instance.SetPhase(choice.newPhase);
        }
    }

    void EndDialogue()
    {
        foreach (Transform child in optionsContainer)
        {
            Destroy(child.gameObject);
        }

        dialogueUI.SetActive(false);
        Time.timeScale = 1f;
    }

    void OnDisable()
    {
        Time.timeScale = 1f;
    }
}