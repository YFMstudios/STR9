using UnityEngine;

public class DisableOutlineOnStart : MonoBehaviour
{
    private float delay = 0.01f;   // Devre d��� b�rakma gecikme s�resi
    private Outline outline;       // Outline bile�eni referans�

    // Start is called before the first frame update
    void Start()
    {
        outline = GetComponent<Outline>();   // Nesnenin Outline bile�enini al
        Invoke("DisableOutline", delay);      // Belirli bir s�re sonra DisableOutline i�levini �a��r
    }

    private void DisableOutline()
    {
        outline.enabled = false;   // Outline bile�enini devre d��� b�rak
    }
}
