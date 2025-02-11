using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BillboardCanvas : MonoBehaviour
{
    Transform cameraTransform;  // Kamera transformu

    // Ba�lang��ta kamera transformunu al
    void Start()
    {
        cameraTransform = Camera.main.transform;
    }

    // Her frame'de kanvas�n daima kameraya do�ru bakmas�n� sa�la
    void LateUpdate()
    {
        transform.LookAt(transform.position + cameraTransform.rotation * -Vector3.forward, cameraTransform.rotation * Vector3.up);
    }
}
