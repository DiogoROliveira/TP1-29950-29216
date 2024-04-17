using UnityEngine;

public class VictoryTrigger : MonoBehaviour
{
    public GameObject victoryMenu;

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            victoryMenu.SetActive(true);
            Destroy(gameObject, 11);
            gameObject.GetComponent<BoxCollider>().enabled = false;
        }
    }
}
