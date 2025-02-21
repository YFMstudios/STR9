using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyClone : MonoBehaviour
{
    public float delay = 5f; // Time in seconds after which the GameObject will be destroyed

    void Start()
    {
        Destroy(gameObject, delay);
    }
}
