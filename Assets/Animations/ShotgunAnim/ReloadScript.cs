using System.Collections;
using UnityEngine;

/*public class ReloadScriptShotgun : MonoBehaviour
{
    public GameObject Gun;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            StartRecoilCoroutine();
        }
    }

    void StartRecoilCoroutine()
    {
        StartCoroutine(RecoilCoroutine());
    }

    IEnumerator RecoilCoroutine()
    {
        Gun.GetComponent<Animator>().Play("ShotgunReload");
        yield return new WaitForSeconds(0.2f); // Adjust this value
        Gun.GetComponent<Animator>().Play("New State");
    }
}*/

public class ReloadScriptShotgun : MonoBehaviour
{
    public GameObject gun;

    private bool reloading = false; // Flag para indicar se a arma está em processo de reload

    // Update is called once per frame
    void Update()
    {
        // Verifica se a tecla "R" foi pressionada e a arma não está em processo de reload
        if (Input.GetKeyDown(KeyCode.R) && !reloading)
        {
            StartCoroutine(StartReload());
        }
    }

    IEnumerator StartReload()
    {
        reloading = true; // Define a flag de reload como true

        // Inicia a animação de reload
        gun.GetComponent<Animator>().SetTrigger("Reload");

        // Aguarda o tempo de reload antes de finalizar o reload
        yield return new WaitForSeconds(4f); // Tempo de reload de 4 segundos

        // Finaliza o reload
        reloading = false; // Define a flag de reload como false
    }
}
