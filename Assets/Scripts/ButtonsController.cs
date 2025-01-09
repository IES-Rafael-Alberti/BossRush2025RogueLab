using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    public KeyCode keyPressed;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (Input.GetKeyDown(keyPressed))
        {
            SR.sprite = pressedImage;
        }

        if (Input.GetKeyUp(keyPressed))
        {
            SR.sprite = defaultImage;
        }
    }
}
