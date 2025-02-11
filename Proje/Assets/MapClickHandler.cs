using UnityEngine;
using UnityEngine.UI;

public class MapClickHandler : MonoBehaviour
{
    // Image bile�enini referans almak i�in bir de�i�ken olu�turuyoruz.
    private Image imageComponent;

    void Start()
    {
        // GameObject �zerindeki Image bile�enini al�yoruz.
        imageComponent = GetComponent<Image>();

        // Image'in alphaHitTestMinimumThreshold �zelli�ini ayarl�yoruz.
        if (imageComponent != null)
        {
            // 0.1 de�eri, %10 �effafl�k seviyesinden d���k b�lgelerin t�klanamaz olmas�n� sa�lar.
            imageComponent.alphaHitTestMinimumThreshold = 0.1f;
        }
    }
}
