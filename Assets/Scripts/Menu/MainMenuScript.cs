using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject mapPickMenu;
    public GameObject confirmQuitMenu;
    private bool settingsShowing = false;
    private bool mapPickShowing = false;
    public GameObject settingsMenu;


    void Start()
    {
        mainMenu.SetActive(true);
        mapPickMenu.SetActive(false);
        confirmQuitMenu.SetActive(false);
        settingsMenu.SetActive(false);
    }

    public void Play()
    {
        mainMenu.SetActive(false);
        mapPickMenu.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape) && !settingsShowing && !mapPickShowing)
        {
            ConfirmQuit();
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && settingsShowing)
        {
            settingsMenu.SetActive(false);
            settingsShowing = false;
        }
        else if (Input.GetKeyDown(KeyCode.Escape) && mapPickShowing)
        {
            mapPickMenu.SetActive(false);
            mapPickShowing = false;
        }
    }

    public void ConfirmQuit()
    {
        confirmQuitMenu.SetActive(true);
    }

    public void CancelQuit()
    {
        confirmQuitMenu.SetActive(false);
    }

    public void Quit()
    {
        Application.Quit();
    }


    public void Settings()
    {
        settingsMenu.SetActive(true);
        settingsShowing = true;
    }


    public void CancelSettings()
    {
        settingsMenu.SetActive(false);
        settingsShowing = false;
    }

    public void MapPick()
    {
        mapPickMenu.SetActive(true);
        mapPickShowing = true;
    }

    public void CancelMapPick()
    {
        mapPickMenu.SetActive(false);
        mainMenu.SetActive(true);
        mapPickShowing = false;
    }


}
