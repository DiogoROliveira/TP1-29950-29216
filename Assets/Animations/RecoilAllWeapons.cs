using UnityEngine;
using System.Collections;

public class RecoilAllWeapons : MonoBehaviour
{
    public GameObject Gun1;
    public GameObject Gun2;
    public GameObject Gun3;

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
        Gun1.GetComponent<Animator>().Play("RecoilAnim");
        Gun2.GetComponent<Animator>().Play("ShotgunRecoil");
        Gun3.GetComponent<Animator>().Play("MeleeRecoil");

        yield return new WaitForSeconds(0.2f); // Adjust this value
        Gun1.GetComponent<Animator>().Play("New State");
        Gun2.GetComponent<Animator>().Play("New State");
        Gun3.GetComponent<Animator>().Play("New State");
    }
}
