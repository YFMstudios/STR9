using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MinionDeathHandler : MonoBehaviour
{
    public int experienceValue = 20;   // D��mandan kazan�lacak deneyim de�eri

    // D��man�n �l�m� durumunda �a�r�lan i�lev
    public void Die()
    {
        GameObject player = GameObject.FindGameObjectWithTag("Player");   // Oyuncuyu bul

        if (player != null)
        {
            // Oyuncuya deneyim kazand�rma mesaj�n� g�nder
            player.SendMessage("GainExperienceFromMinion", experienceValue);
        }

        Destroy(gameObject);   // D��man� yok et
    }

    // Start is called before the first frame update
    void Start()
    {
        // Ba�lang�� i�levi, �u anda bo�
    }

    // Update is called once per frame
    void Update()
    {
        // G�ncelleme i�levi, �u anda bo�
    }
}
