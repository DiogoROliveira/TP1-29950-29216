using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;
    public GameObject settingsMenu;
    public GameObject crosshair;

    // Referência ao script da arma
    public Gun gun;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameIsPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
        crosshair.SetActive(true);

        // Resumir a reprodução do som da arma
        gun.ResumeSound();
    }

    void Pause()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
        crosshair.SetActive(false);

        // Pausar a reprodução do som da arma
        gun.PauseSound();
    }

    public void Quit()
    {
        Debug.Log("Going back to menu...");
        SceneManager.LoadScene("Menu");
    }

    public void Settings()
    {
        settingsMenu.SetActive(true);
    }

    public void CancelSettings()
    {
        settingsMenu.SetActive(false);
    }
}