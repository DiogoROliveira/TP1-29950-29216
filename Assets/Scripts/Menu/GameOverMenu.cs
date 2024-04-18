using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverMenu : MonoBehaviour
{
    public GameObject gameOverMenu;
    public GameObject crosshair;
    public static bool gameOverShowing = false;
    public Transform player;


    void Start()
    {
        gameOverMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        if (player.GetComponent<PlayerHealth>().health <= 0)
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            gameOverMenu.SetActive(true);
            Time.timeScale = 0f;
            gameOverShowing = true;
            crosshair.SetActive(false);
        }

        if (gameOverShowing)
            if (Input.GetKeyDown(KeyCode.R))
                Restart();

    }

    public void Quit()
    {
        Application.Quit();
    }

    public void Restart()
    {
        gameOverShowing = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void MainMenu()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }


}
