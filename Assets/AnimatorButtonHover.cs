using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatorButtonHover : MonoBehaviour , IPointerEnterHandler, IPointerExitHandler
{
    public GameObject button;
    public void OnPointerEnter(PointerEventData eventData)
    {
        LeanTween.moveX(button.GetComponent<RectTransform>(), 738f, 0.2f);
        Debug.Log("entro");
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        LeanTween.moveX(button.GetComponent<RectTransform>(), 865f, 0.3f);
    }

}
