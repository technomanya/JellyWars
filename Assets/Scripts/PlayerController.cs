using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public GameObject mainBody;
    public int currMultplyAmount;
    private Camera _playerCamera;
    private bool isPressed;
    [SerializeField] private List<BodyBehaviourPlayer> bodyEffectList;

    public InteractCircleBehaviour interactCircle;

    private LayerMask _layerMask;
    // Start is called before the first frame update
    void Start()
    {
        _layerMask = LayerMask.GetMask("EnemyJelly"); 
        _playerCamera = GameManager.Instance.playerCamera;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            for (int i = 0; i < 10; i++)
            {
                Instantiate(mainBody);
            }
        }
        if (Input.GetMouseButtonDown(0))
        {
            
            interactCircle.bodyEffectList.Clear();
            interactCircle.bodyEffectList = new List<BodyBehaviourPlayer>();
            isPressed = true;
        }
        if(Input.GetMouseButton(0))
        {
            var camPos = _playerCamera.ScreenToWorldPoint(Input.mousePosition);
            interactCircle.gameObject.SetActive(true);
            interactCircle.transform.position = new Vector3(camPos.x,camPos.y,0);

        }
        if(isPressed && Input.GetMouseButtonUp(0))
        {
            isPressed = false;
            bodyEffectList = interactCircle.bodyEffectList;
            

            foreach (var body in bodyEffectList)
            {
                switch (interactCircle.circleEffect)
                {
                    case EffectType.Enlarge:
                        body.EnlargeBody();
                        break;
                    case EffectType.Multiply:
                        body.MultiplyBody(currMultplyAmount);
                        break;
                    case EffectType.Shoot:
                        var hitObj = Physics2D.CircleCast(interactCircle.transform.position, 100f, Vector2.zero, 1f, _layerMask);
                        Debug.Log(hitObj.transform.name);
                        if (hitObj.rigidbody)
                        {
                            body.ShootBody(hitObj.transform.position);
                        }
                        break;
                }
            }
            interactCircle.gameObject.SetActive(false);
        }
    }
}
