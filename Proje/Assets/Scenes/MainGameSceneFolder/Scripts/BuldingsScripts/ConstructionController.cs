using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class ConstructionController : MonoBehaviour
{
    // Referans�n�z� ProgressBarController scriptine ba�lay�n
    public ProgressBarController progressBarController;

    public bool CanStartNewConstruction()
    {
        // T�m bool de�i�kenlerini bir listeye ekleyin
        bool[] activeConstructions = new bool[]
        {
            progressBarController.isBarracksBuildActive,
            progressBarController.isUnitCreationActive,
            progressBarController.isHealActive,
            progressBarController.isHospitalBuildActive,
            progressBarController.isTowerBuildingActive,
            progressBarController.isFarmBuildActive,
            progressBarController.isAnyTrapActive,
            progressBarController.isWareHouseBuildingActive,
            progressBarController.isStonePitBuildingActive,
            progressBarController.isSawmillBuildingActive,
            progressBarController.isBlacksmithBuildingActive,
            progressBarController.isCastleBuildingActive
        };

        // Aktif olan in�aatlar�n say�s�n� kontrol edin
        int activeCount = activeConstructions.Count(isActive => isActive);

        // E�er aktif olan in�aat say�s� 2 veya daha fazlaysa yeni in�aata izin verme
        return activeCount < 2;
    }
}
