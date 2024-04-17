using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayMenu : MonoBehaviour
{
    public void LoadMap1()
    {
        SceneManager.LoadScene("Map1");
    }

    public void LoadMap2()
    {
        SceneManager.LoadScene("Map2");
    }

    public void LoadMap3()
    {
        SceneManager.LoadScene("Map3");
    }
}
