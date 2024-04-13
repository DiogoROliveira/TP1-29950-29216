using System.Collections;
using UnityEngine;

public class RecoilScriptShotgun : MonoBehaviour
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
        Gun.GetComponent<Animator>().Play("ShotgunRecoil");
        yield return new WaitForSeconds(0.2f); // Adjust this value
        Gun.GetComponent<Animator>().Play("New State");
    }
}
