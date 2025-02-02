using UnityEngine;

public class ButtonsController : MonoBehaviour
{
    private SpriteRenderer SR;
    public Sprite defaultImage;
    public Sprite pressedImage;

    void Start()
    {
        SR = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    {
        if (Input.GetButton("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("e"))
        {
            SR.sprite = pressedImage;
        }

        if (Input.GetButton("Fire1") || Input.GetKeyDown("space") || Input.GetKeyDown("e"))
        {
            SR.sprite = defaultImage;
        }
    }
}
