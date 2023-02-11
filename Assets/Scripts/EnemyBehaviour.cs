using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyBehaviour : MonoBehaviour
{
    public int currMultplyAmount;
    public float timeDelay = 3;
    public int maxMoveVariety = 1;
    private bool canMakeMove;
    [SerializeField]private List<BodyBaseBehavour> bodyListEnemy = new List<BodyBaseBehavour>();

    private void Start()
    {
        Invoke(nameof(OnLevelStart),2);
    }

    public void OnLevelStart()
    {
        StartCoroutine(MakeMove());
    }
    private void Update()
    {
        if (canMakeMove)
        {
            StartCoroutine(MakeMove());
        }
    }

    // ReSharper disable Unity.PerformanceAnalysis
    IEnumerator MakeMove()
    {
        canMakeMove = false;
        var randomMove = Random.Range(0, maxMoveVariety);
        switch (randomMove)
        {
            case 0 :
                var randomAmount = Random.Range(0, bodyListEnemy.Count);
                for (var i = 0; i<= randomAmount;i++)
                {
                    if(bodyListEnemy[i])
                    {
                        var tempObj = bodyListEnemy[i];
                        bodyListEnemy.Remove(bodyListEnemy[i]);
                        var tempList = tempObj.MultiplyBody(currMultplyAmount);
                        foreach (var tempBody in tempList)
                        {
                            bodyListEnemy.Add(tempBody);
                        }
                    }
                }
                break;
            case 1:
                foreach (var body in bodyListEnemy)
                {
                    body.EnlargeBody();
                }
                break;
            case 2:
                foreach (var body in bodyListEnemy)
                {
                    //body.ShootBody();
                }
                break;
        }
        yield return new WaitForSeconds(timeDelay);
        canMakeMove = true;
    }
}
