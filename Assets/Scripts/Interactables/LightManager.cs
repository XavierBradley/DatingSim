using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LightManager : MonoBehaviour
{
    public static LightManager Instance { get; private set; }

    private Image darknessOverlay;
    private bool lightsOn = true;

    [SerializeField] private float darknessAlpha = 0.6f;

    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    private void Start()
    {
        FindDarknessOverlay();
        UpdateLightsVisual();
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
        FindDarknessOverlay();
        UpdateLightsVisual();
    }

    private void FindDarknessOverlay()
    {
        GameObject overlayObject = GameObject.Find("DarknessOverlay");

        if (overlayObject != null)
        {
            darknessOverlay = overlayObject.GetComponent<Image>();
        }
    }

    public void ToggleLights()
    {
        lightsOn = !lightsOn;
        UpdateLightsVisual();

        if (lightsOn)
        {
            Debug.Log("Lights turned on.");
        }
        else
        {
            Debug.Log("Lights turned off.");
        }
    }

    public bool AreLightsOn()
    {
        return lightsOn;
    }

    private void UpdateLightsVisual()
    {
        if (darknessOverlay == null)
        {
            return;
        }

        Color color = darknessOverlay.color;

        if (lightsOn)
        {
            color.a = 0f;
        }
        else
        {
            color.a = darknessAlpha;
        }

        darknessOverlay.color = color;
    }
}