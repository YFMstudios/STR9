using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// Bina t�rlerini tan�mlayan enum
public enum BuildingType
{
    ResourceProduction,
    UnitProduction,
    Defense,
    Medical,
    Research,
    // Di�er bina t�rleri buraya eklenebilir
}

// Bina s�n�f�
public class Building : MonoBehaviour
{
    // Bina �zellikleri
    public string buildingName;
    public BuildingType buildingType;
    public int health;
    public int buildGoldCost;
    public int buildFoodCost;
    public int buildIronCost;
    public int buildStoneCost;
    public int buildTimberCost;
    public float buildTime;

    public bool wasBuildCreated;

    // ��levler
    public virtual void StartConstruction()
    {
        // Bina yap�m�n� ba�latma kodu buraya gelebilir
    }

    public virtual void CompleteConstruction()
    {
        // Bina yap�m�n� tamamlama kodu buraya gelebilir
    }

    public virtual void DestroyBuilding()
    {
        // Bina yok etme kodu buraya gelebilir
    }

    // �rnek i�levler - Bina t�r�ne ba�l� olarak geni�letilebilir
    public virtual void ProduceResource()
    {
        // Kaynak �retme kodu buraya gelebilir
    }

    public virtual void ProduceUnit()
    {
        // Birim �retme kodu buraya gelebilir
    }
    public virtual void UpdateCosts()
    {
        // Varsay�lan maliyet g�ncelleme i�lemleri burada yap�labilir.
        // E�er her bina i�in genel bir kural varsa burada tan�mlanabilir.
    }

    // Di�er �zellikler ve i�levler buraya eklenebilir
}
