using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SiegeWorkshop : Building
{

    public static int buildLevel = 0;
    public static bool wasSiegeWorkshopCreated = false;
    public SiegeWorkshop()
    {
        // �zelliklerin ba�lang�� de�erlerini atama
        buildingName = "Siege Workshop";
        buildingType = BuildingType.UnitProduction;
        health = 100;
        buildGoldCost = 1;
        buildFoodCost = 1;
        buildIronCost = 1;
        buildStoneCost = 1;
        buildTimberCost = 1;
        buildTime = 10f;
    }

    public override void UpdateCosts()
    {
        // Bina seviyesine g�re maliyet g�ncelleme
        if (buildLevel == 1)
        {
            buildGoldCost = 1000;
        }
        else if (buildLevel == 2)
        {
            buildGoldCost = 2500;
        }
    }
}
