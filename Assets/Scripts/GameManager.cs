using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public PlayerController playerController;
    public InteractCircleBehaviour interactCircle;
    public Camera playerCamera;
    public int currMultplyAmount;
    public float currEnlargeAmountDelta;
    public float currMoveForce;

    public int maxElementSize;
    public int currElementSize;

    public int maxMultiplyAmount;
    public int maxEnlargeLevel;
    private void Awake()
    {
        Instance = this;
        playerController.interactCircle = interactCircle;
    }
}
