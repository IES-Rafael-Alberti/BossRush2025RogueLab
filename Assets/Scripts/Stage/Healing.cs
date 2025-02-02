using UnityEngine;

public class Healing : MonoBehaviour
{

    private GameManager gameManager;
    private GameObject goGM;

    private void Start()
    {
        goGM = GameObject.Find("GameManager");
        gameManager = goGM.GetComponent<GameManager>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            gameManager.SetHealth(1, "restore");
            gameObject.SetActive(false);
        }
    }

    public void Show()
    {
        gameObject.SetActive(true);
    }
}
