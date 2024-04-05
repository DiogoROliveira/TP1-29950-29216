using UnityEngine;

public class MainMenuScript : MonoBehaviour
{

    public GameObject mainMenu;
    public GameObject mapPickMenu;
    public GameObject confirmQuitMenu;


    void Start()
    {
        mainMenu.SetActive(true);
    }

    public void StartGame()
    {
        mainMenu.SetActive(false);
        mapPickMenu.SetActive(true);
    }


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            ConfirmQuit();
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


}
