using UnityEngine;

public class InventoryMenu : MonoBehaviour
{
    public bool IsPaused = false;

    public GameObject InventoryMenuCanvas;


    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (IsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Pause()
    {
        Time.timeScale = 0;
        InventoryMenuCanvas.SetActive(true);
        IsPaused = true;
    }

    public void Resume()
    {
        InventoryMenuCanvas.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }
}