using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public bool hasHit = false;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("e"))
        {
            Debug.Log("Button pressed");
            if (canBePressed)
            {
                Debug.Log("Note hit");
                hasHit = true;
                Destroy(gameObject);
                GameManager.Instance.NoteHit();
            }
            if (hasHit == false) { GameManager.Instance.NoteMissed(); GameManager.Instance.NoteHit(); }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Activator")
        {
            canBePressed = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Activator")
        {
            canBePressed = false;

            if (hasHit == false) { GameManager.Instance.NoteMissed(); }

        }
    }
}
