using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraInteract : MonoBehaviour
{
    private Camera screenCamera;

    private void Start()
    {
        screenCamera = GetComponent<Camera>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = screenCamera.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                if (hit.collider.GetComponent<Interactable>() != null)
                {
                    hit.collider.GetComponent<Interactable>().Interact();
                }
            }
        }
    }
}
