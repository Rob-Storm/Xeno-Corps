using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattlescapeCamera : MonoBehaviour
{
    [SerializeField] private Camera Camera;

    private void Awake()
    {
        //Camera = GameObject.Find("Camera").GetComponent<Camera>();
    }

    private void Update()
    {
        if(InputManager.Instance.GetCanPanCamera())
            Camera.transform.Translate(InputManager.Instance.GetMouseDelta() * -0.005f);
    }

}
