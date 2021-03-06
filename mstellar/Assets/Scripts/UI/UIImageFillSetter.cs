﻿using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Image))]
public class UIImageFillSetter : MonoBehaviour
{
    [SerializeField] private DFloatValue   fillAmount   = null;

    private Image   image;

    private void Awake() {
        image = GetComponent<Image>();
    }
    private void Update() {
        if(image.fillAmount != fillAmount/100)
            image.fillAmount = fillAmount/100;
    }
}
