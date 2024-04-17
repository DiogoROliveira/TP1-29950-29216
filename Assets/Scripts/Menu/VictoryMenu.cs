using UnityEngine;
using UnityEngine.SceneManagement;

public class VictoryMenu : MonoBehaviour
{
    public GameObject victoryMenu;
    public GameObject crosshair;
    public Gun gun;

    void Start()
    {
        victoryMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (victoryMenu.activeSelf)
        {
            crosshair.SetActive(false);
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            Time.timeScale = 0f;

            gun.PauseSound();
        }
    }


    public void Retry()
    {
        Time.timeScale = 1f;
        victoryMenu.SetActive(false);
        crosshair.SetActive(true);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }


    public void MainMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void NextLevel()
    {
        if (SceneManager.GetActiveScene().name == "Map1")
        {
            SceneManager.LoadScene("Map2");
        }
        else if (SceneManager.GetActiveScene().name == "Map2")
        {
            SceneManager.LoadScene("Map3");
        }
    }

}
