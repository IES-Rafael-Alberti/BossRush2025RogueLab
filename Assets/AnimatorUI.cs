using System;
using UnityEngine;
using UnityEngine.EventSystems;

public class AnimatorUI : MonoBehaviour
{
    public GameObject[] botones;
    
    public float velocidadAnim = 0.3f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        foreach (var boton in botones) { 
        
            LeanTween.moveX(boton.GetComponent<RectTransform>(), 865f, velocidadAnim);  
        }
    }

  



}
