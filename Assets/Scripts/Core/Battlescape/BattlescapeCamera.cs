using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlescapeCamera : MonoBehaviour
{
    [SerializeField] private InputManager inputManager;
    [SerializeField] private Camera Camera;

    private void Awake()
    {
        //Camera = GameObject.Find("Camera").GetComponent<Camera>();
        //inputManager = GameObject.Find(GameManager.ManagerGameObject.name).GetComponent<InputManager>();
    }

    private void Update()
    {
        if(inputManager.GetCanPanCamera())
            Camera.transform.Translate(inputManager.GetMouseDelta() * -0.005f);
    }

}
