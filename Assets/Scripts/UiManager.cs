using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
    [SerializeField] private Button multiplyButton;
    [SerializeField] private Button enlargeButton;
    [SerializeField] private Button shootButton;
    void Start()
    {
        multiplyButton.onClick.AddListener(MultiplyButonOnPressed);
        enlargeButton.onClick.AddListener(EnlargeButonOnPressed);
        shootButton.onClick.AddListener(ShootButonOnPressed);
    }

    public void MultiplyButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Multiply;
    }
    
    public void EnlargeButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Enlarge;
    }
    
    public void ShootButonOnPressed()
    {
        GameManager.Instance.interactCircle.circleEffect = EffectType.Shoot;
    }
}
