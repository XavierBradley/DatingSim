using UnityEngine;

public class SettingsMenu : MonoBehaviour
{
    public bool IsPaused = false;

    public GameObject SettingsMenuCanvas;


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
        SettingsMenuCanvas.SetActive(true);
        IsPaused = true;
    }

    public void Resume()
    {
        SettingsMenuCanvas.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }
}
