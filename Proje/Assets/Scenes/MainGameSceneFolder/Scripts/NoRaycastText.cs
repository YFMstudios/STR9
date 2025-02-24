using UnityEngine;
using UnityEngine.UI;

public class NoRaycastText : MonoBehaviour, ICanvasRaycastFilter
{
    public bool IsRaycastLocationValid(Vector2 sp, Camera eventCamera)
    {
        // Her zaman false d�nerse, bu nesne raycast taraf�ndan hedeflenmez.
        return false;
    }
}
