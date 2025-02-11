using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera cmVirtualCam;   // Sanal kamera referans�
    public Camera mainCamera;                       // Birincil kamera referans�

    private bool usingVirtualCam = true;            // Sanal kamera kullan�l�yor mu?

    // Update is called once per frame
    void Update()
    {
        // Uzay tu�una bas�ld���nda kamera modunu de�i�tir
        if (Input.GetKeyDown(KeyCode.Space))
        {
            usingVirtualCam = !usingVirtualCam;  // Kamera modunu tersine �evir

            if (usingVirtualCam)
            {
                cmVirtualCam.gameObject.SetActive(true);   // Sanal kameray� etkinle�tir
                mainCamera.gameObject.SetActive(false);    // Birincil kameray� devre d��� b�rak
            }
            else
            {
                cmVirtualCam.gameObject.SetActive(false);  // Sanal kameray� devre d��� b�rak
                mainCamera.gameObject.SetActive(true);     // Birincil kameray� etkinle�tir
            }
        }

        // E�er birincil kamera kullan�l�yorsa, fare pozisyonuna ba�l� olarak kameray� hareket ettir
        if (!usingVirtualCam)
        {
            float x = Input.mousePosition.x;
            float y = Input.mousePosition.y;

            // Fare ekran�n sol kenar�na yak�nsa, kameray� sola do�ru hareket ettir
            if (x < 10)
            {
                mainCamera.transform.position -= Vector3.left * Time.deltaTime * 10f;
            }
            // Fare ekran�n sa� kenar�na yak�nsa, kameray� sa�a do�ru hareket ettir
            else if (x > Screen.width - 10)
            {
                mainCamera.transform.position -= Vector3.right * Time.deltaTime * 10f;
            }
            // Fare ekran�n alt kenar�na yak�nsa, kameray� geriye do�ru hareket ettir
            if (y < 10)
            {
                mainCamera.transform.position -= Vector3.back * Time.deltaTime * 10f;
            }
            // Fare ekran�n �st kenar�na yak�nsa, kameray� ileriye do�ru hareket ettir
            else if (y > Screen.height - 10)
            {
                mainCamera.transform.position -= Vector3.forward * Time.deltaTime * 10f;
            }
        }
    }
}
