using UnityEngine;

public class Pause : MonoBehaviour
{
    public bool IsPaused = false;

    public GameObject PauseMenuCanvas;


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
                PauseGame();
            }
        }
    }

    public void PauseGame()
    {
        Time.timeScale = 0;
        PauseMenuCanvas.SetActive(true);
        IsPaused = true;
    }

    public void Resume()
    {
        PauseMenuCanvas.SetActive(false);
        IsPaused = false;
        Time.timeScale = 1;
    }
}

