using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class NoteObject : MonoBehaviour
{

    public bool canBePressed;
    public bool hasHit = false;

    public KeyCode keyPressed;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            if (canBePressed)
            {
                hasHit = true;
                Destroy(gameObject);
                GameManager.Instance.NoteHit();
            }
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
