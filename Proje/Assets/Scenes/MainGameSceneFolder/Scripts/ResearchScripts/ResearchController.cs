using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResearchController : MonoBehaviour
{


    public Image[] lockItems = new Image[18];
    public ProgressBarController progressBarController;
    public ObjectiveStats objectiveStats;

    public void OpenResearchUnit(int buildLevel)
    {
        if (buildLevel == 1)
        {
            // �lk seviyenin kilidini a�
            lockItems[0].enabled = false;
        }
    }
    public void OpenTwoAndThreeLevels()
    {

        if (ResearchButtonEvents.isResearched[0] == true)
        {

            lockItems[1].enabled = false;
            lockItems[2].enabled = false;
        }
    }

    public void OpenFourLevel()
    {
        if (ResearchButtonEvents.isResearched[1] == true)
        {
            lockItems[3].enabled = false;

        }
    }

    public void OpenFiveLevel()
    {

        if (ResearchButtonEvents.isResearched[2] == true)
        {
            lockItems[4].enabled = false;
        }
    }

    public void controlBuildLevelTwoResearches()
    {
        if (ResearchButtonEvents.isResearched[3] == true && Lab.buildLevel >= 2)
        {
            lockItems[5].enabled = false;
            // researchItems[5].color = new Color(255f, 255f, 255f, 255f);
        }
        if (ResearchButtonEvents.isResearched[4] == true && Lab.buildLevel >= 2)
        {
            lockItems[7].enabled = false;
            //researchItems[7].color = new Color(255f, 255f, 255f, 255f);
        }
        if (ResearchButtonEvents.isResearched[3] == true && ResearchButtonEvents.isResearched[4] == true && Lab.buildLevel >= 2)
        {
            lockItems[6].enabled = false;
            //researchItems[6].color = new Color(255f, 255f, 255f, 255f);
        }

    }

    public void control9And10Levels()
    {
        if (ResearchButtonEvents.isResearched[5] == true)
        {
            Debug.Log("Level6 Ara�t�r�ld�");
        }
        if (ResearchButtonEvents.isResearched[6] == true)
        {
            Debug.Log("Level7 Ara�t�r�ld�");
        }
        if (ResearchButtonEvents.isResearched[5] == true && ResearchButtonEvents.isResearched[6] == true)
        {
            lockItems[8].enabled = false;
            Debug.Log("Seviye9 A��ld�");
        }
        if (ResearchButtonEvents.isResearched[6] == true && ResearchButtonEvents.isResearched[7] == true)
        {
            lockItems[9].enabled = false;
        }
    }

    public void control11And12And13Levels()
    {

        if (ResearchButtonEvents.isResearched[8] == true && Lab.buildLevel >= 2)
        {
            lockItems[10].enabled = false;
        }
        if (ResearchButtonEvents.isResearched[9] == true && Lab.buildLevel >= 2)
        {
            lockItems[12].enabled = false;
        }
        if (ResearchButtonEvents.isResearched[8] == true && ResearchButtonEvents.isResearched[9] == true
           && Lab.buildLevel >= 2)
        {
            lockItems[11].enabled = false;
        }
    }


    public void controlBuildLevelThreeResearches()
    {
        if (ResearchButtonEvents.isResearched[10] == true && ResearchButtonEvents.isResearched[11]
            && Lab.buildLevel >= 3)
        {
            lockItems[13].enabled = false;
        }
        if (ResearchButtonEvents.isResearched[11] == true && ResearchButtonEvents.isResearched[12] == true
            && Lab.buildLevel >= 3)
        {
            lockItems[14].enabled = false;
        }
    }

    public void control16And17Levels()
    {
        if (ResearchButtonEvents.isResearched[13] == true && Lab.buildLevel >= 3)
        {
            lockItems[15].enabled = false;
        }
        if (ResearchButtonEvents.isResearched[14] == true && Lab.buildLevel >= 3)
        {
            lockItems[16].enabled = false;
        }
    }

    public void level18Control()
    {
        if (ResearchButtonEvents.isResearched[15] && ResearchButtonEvents.isResearched[16] && Lab.buildLevel >= 3)
        {
            lockItems[17].enabled = false;
        }
    }

    public void UpgradeResearchedItems(int researchedLevel)
    {
        if (researchedLevel == 0)
        {
            Debug.Log("Eski �retim Oran� : " + Farm.foodProductionRate);
            Debug.Log("Eski Alt�n �retme Oran� : " + Farm.goldProductionRateFarm);
            Farm.foodProductionRate += (Farm.foodProductionRate * 25) / 100;
            Farm.goldProductionRateFarm += (Farm.goldProductionRateFarm * 100) / 100;
            Debug.Log("Yeni �retim Oran� : " + Farm.foodProductionRate);
            Debug.Log("Yeni Alt�n �retme Oran� : " + Farm.goldProductionRateFarm);
        }
        else if (researchedLevel == 1)
        {
            Debug.Log("Eski �retim Oran� : " + Sawmill.timberProductionRate);
            Debug.Log("Eski Alt�n �retme Oran� : " + Sawmill.goldProductionRateSawmill);
            Sawmill.timberProductionRate += (Sawmill.timberProductionRate * 25) / 100;
            Sawmill.goldProductionRateSawmill += (Sawmill.goldProductionRateSawmill * 100) / 100;
            Debug.Log("Yeni �retim Oran� : " + Sawmill.timberProductionRate);
            Debug.Log("Yeni Alt�n �retme Oran� : " + Sawmill.goldProductionRateSawmill);
        }
        else if (researchedLevel == 2)
        {
            Debug.Log("Eski �retim Oran� : " + StonePit.stoneProductionRate);
            Debug.Log("Eski Alt�n �retme Oran� : " + StonePit.goldProductionRateStonePit);
            StonePit.stoneProductionRate += (StonePit.stoneProductionRate * 25) / 100;
            StonePit.goldProductionRateStonePit += (StonePit.goldProductionRateStonePit * 100) / 100;
            Debug.Log("Yeni �retim Oran� : " + StonePit.stoneProductionRate);
            Debug.Log("Yeni Alt�n �retme Oran� : " + StonePit.goldProductionRateStonePit);
        }
        else if (researchedLevel == 3)
        {
            Debug.Log("Eski �retim Oran� : " + Blacksmith.ironProductionRate);
            Debug.Log("Eski Alt�n �retme Oran� : " + Blacksmith.goldProductionRateBlacksmith);
            Blacksmith.ironProductionRate += (Blacksmith.ironProductionRate * 25) / 100;
            Blacksmith.goldProductionRateBlacksmith += (Blacksmith.goldProductionRateBlacksmith * 100) / 100;
            Debug.Log("Yeni �retim Oran� : " + Blacksmith.ironProductionRate);
            Debug.Log("Yeni Alt�n �retme Oran� : " + Blacksmith.goldProductionRateBlacksmith);
        }
        else if (researchedLevel == 4)
        {
            //Ara�t�rmalar� h�zland�r.
        }
        else if (researchedLevel == 5)
        {
            Debug.Log("Eski Sava��� Heal Time : " + progressBarController.savasciHealTime);
            Debug.Log("Eski Ok�u Heal Time : " + progressBarController.okcuHealTime);
            progressBarController.savasciHealTime = 1.25f;
            progressBarController.okcuHealTime = 2.15f;
            Debug.Log("Yeni Sava��� Heal Time : " + progressBarController.savasciHealTime);
            Debug.Log("Yeni Ok�u Heal Time : " + progressBarController.okcuHealTime);
        }
        else if (researchedLevel == 6)
        {
            objectiveStats.damage = 10000f;
        }
        else if ((researchedLevel == 7))
        {
            progressBarController.savasciCreationTime -= 0.25f;
            progressBarController.okcuCreationTime -= 0.25f;

        }
        else if ((researchedLevel == 8))
        {
            Farm.foodProductionRate += (Farm.foodProductionRate * 40) / 100;
            Farm.goldProductionRateFarm += (Farm.goldProductionRateFarm * 100) / 100;
        }
        else if (researchedLevel == 9)
        {
            //�n�aa s�relerini azalt
        }
        else if (researchedLevel == 10)
        {
            StonePit.stoneProductionRate += (StonePit.stoneProductionRate * 40) / 100;
            StonePit.goldProductionRateStonePit += (StonePit.goldProductionRateStonePit * 100) / 100;
        }
        else if (researchedLevel == 11)
        {
            Blacksmith.ironProductionRate += (Blacksmith.ironProductionRate * 40) / 100;
            Blacksmith.goldProductionRateBlacksmith += (Blacksmith.goldProductionRateBlacksmith * 100) / 100;
        }
        else if (researchedLevel == 12)
        {
            Warehouse.foodCapacity += (Warehouse.foodCapacity * 10) / 100;
            Warehouse.ironCapacity += (Warehouse.ironCapacity * 10) / 100;
            Warehouse.timberCapacity += (Warehouse.timberCapacity * 10) / 100;
            Warehouse.stoneCapacity += (Warehouse.stoneCapacity * 10) / 100;
        }
        else if (researchedLevel == 13)
        {
            //Komutan�n damage ve hareket h�z�n� artt�r.
        }
        else if (researchedLevel == 14)
        {
            //Askerilerin hareket h�zlar�n� artt�r.
        }
        else if (researchedLevel == 15)
        {
            progressBarController.savasciCreationTime -= 0.25f;
            progressBarController.okcuCreationTime -= 0.25f;
        }
        else if (researchedLevel == 16)
        {
            // Kale ve kulelerin canlar�n� artt�r.
        }
        else if (researchedLevel == 17)
        {
            //Askerlerin damage'ini artt�r.
        }

    }

}
