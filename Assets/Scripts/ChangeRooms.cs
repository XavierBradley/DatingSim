using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeRooms : MonoBehaviour
{
    public string sceneToLoad;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }

}
