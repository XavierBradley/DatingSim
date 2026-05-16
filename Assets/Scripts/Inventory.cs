using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Inventory : MonoBehaviour
{
    public static Inventory Instance;

    [SerializeField] private InventoryUI inventoryUI;
    [SerializeField] private GameObject inventoryCanvas;

    public List<Items> items = new List<Items>();

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(transform.root.gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(transform.root.gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        UpdateInventoryVisibility(SceneManager.GetActiveScene().name);

        if (inventoryUI != null)
        {
            inventoryUI.UpdateUI(items);
        }
    }

    private void OnDestroy()
    {
        if (Instance == this)
        {
            SceneManager.sceneLoaded -= OnSceneLoaded;
        }
    }

    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        UpdateInventoryVisibility(scene.name);

        if (inventoryUI != null)
        {
            inventoryUI.UpdateUI(items);
        }
    }

    private void UpdateInventoryVisibility(string sceneName)
    {
        if (inventoryCanvas == null)
        {
            return;
        }

        inventoryCanvas.SetActive(sceneName != "MainMenu");
    }

    public void AddItem(Items item)
    {
        if (item == null)
        {
            return;
        }

        items.Add(item);
        Debug.Log("Picked up: " + item.itemName);

        if (inventoryUI != null)
        {
            inventoryUI.UpdateUI(items);
        }
        else
        {
            Debug.LogWarning("Inventory UI is not assigned.");
        }
    }

    public void RemoveItem(Items item)
    {
        if (item == null)
        {
            return;
        }

        if (items.Contains(item))
        {
            items.Remove(item);

            if (inventoryUI != null)
            {
                inventoryUI.UpdateUI(items);
            }
            else
            {
                Debug.LogWarning("Inventory UI is not assigned.");
            }
        }
    }

    public bool HasItem(Items item)
    {
        if (item == null)
        {
            return false;
        }

        return items.Contains(item);
    }
}