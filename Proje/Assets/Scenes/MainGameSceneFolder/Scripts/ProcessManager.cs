using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class PanelManager : MonoBehaviour
{
    public GameObject buildPanelPrefab; // Panel Prefab'�
    public GameObject researchPanelPrefab; // Panel Prefab'�
    public GameObject soldierCreationPanelPrefab;
    public GameObject SoldierHealPanelPrefab;
    public Transform panelContainer; // Vertical Layout Group'un oldu�u GameObject

    private List<GameObject> activePanels = new List<GameObject>();
    private List<GameObject> deactivePanels = new List<GameObject>();
    private Dictionary<string, GameObject> panelDictionary = new Dictionary<string, GameObject>();

    

    // Yeni bir panel olu�tur
    public void CreatePanel(string panelId, string panelText, float buildTime,string processType)
    {
        if(processType == "Building")
        {
            GameObject newPanel = Instantiate(buildPanelPrefab, panelContainer);

            Image img = newPanel.transform.Find("ProcessImage").GetComponent<Image>();
            TextMeshProUGUI tmp = newPanel.transform.Find("BuildNameText").GetComponent<TextMeshProUGUI>();
            Image background = newPanel.transform.Find("Background").GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Buildings/" + panelText);


            if (background == null)
            {
                Debug.Log("Background bulunamad�");
            }
            else
            {
                Image bar = background.transform.Find("Bar").GetComponent<Image>();

                if (bar == null)
                {
                    Debug.Log("Bar bulunamad�");
                }
                else
                {

                    LeanTween.scaleX(bar.gameObject, 1, buildTime).setOnComplete(() => DestroyPanel(panelId));
                }
            }

            if (img != null && tmp != null)
            {
                img.sprite = sprite;
                tmp.text = panelText;
            }

            if (panelDictionary.ContainsKey(panelId))
            {
                Debug.LogWarning($"Panel ID zaten mevcut: {panelId}");
                Destroy(newPanel); // Ayn� ID i�in birden fazla panel olu�mas�n� engelle
                return;
            }

            panelDictionary.Add(panelId, newPanel); // Paneli ID ile ili�kilendir

            // Paneli aktifle�tir/deaktif et
            if (OpenProcessPanelWithAnim.isPanelActive)
            {
                activePanels.Add(newPanel);
                Debug.Log($"Panel '{panelId}' aktif.");
            }
            else
            {
                deactivePanels.Add(newPanel);
                newPanel.SetActive(false);
                Debug.Log($"Panel '{panelId}' pasif.");
            }

            Debug.Log($"Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");
        }
       
        else if(processType == "Researching")
        {
            GameObject newPanel = Instantiate(researchPanelPrefab, panelContainer);

            Image img = newPanel.transform.Find("ProcessImage").GetComponent<Image>();
            TextMeshProUGUI tmp = newPanel.transform.Find("ResearchNameText").GetComponent<TextMeshProUGUI>();
            Image background = newPanel.transform.Find("Background").GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Researches/" + panelId);

            if (background == null)
            {
                Debug.Log("Background bulunamad�");
            }
            else
            {
                Image bar = background.transform.Find("Bar").GetComponent<Image>();

                if (bar == null)
                {
                    Debug.Log("Bar bulunamad�");
                }
                else
                {

                    LeanTween.scaleX(bar.gameObject, 1, buildTime).setOnComplete(() => DestroyPanel(panelId));
                }
            }

            if (img != null && tmp != null)
            {
                img.sprite = sprite;
                tmp.text = panelText;
            }

            if (panelDictionary.ContainsKey(panelId))
            {
                Debug.LogWarning($"Panel ID zaten mevcut: {panelId}");
                Destroy(newPanel); // Ayn� ID i�in birden fazla panel olu�mas�n� engelle
                return;
            }

            panelDictionary.Add(panelId, newPanel); // Paneli ID ile ili�kilendir

            // Paneli aktifle�tir/deaktif et
            if (OpenProcessPanelWithAnim.isPanelActive)
            {
                activePanels.Add(newPanel);
                Debug.Log($"Panel '{panelId}' aktif.");
            }
            else
            {
                deactivePanels.Add(newPanel);
                newPanel.SetActive(false);
                Debug.Log($"Panel '{panelId}' pasif.");
            }

            Debug.Log($"Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");
        }

        else if(processType == "SoldierCreation")
        {
            GameObject newPanel = Instantiate(soldierCreationPanelPrefab, panelContainer);

            Image img = newPanel.transform.Find("ProcessImage").GetComponent<Image>();
            TextMeshProUGUI tmp = newPanel.transform.Find("SoldierAmountText").GetComponent<TextMeshProUGUI>();
            Image background = newPanel.transform.Find("Background").GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Military/SoldierCreation");

            if (background == null)
            {
                Debug.Log("Background bulunamad�");
            }
            else
            {
                Image bar = background.transform.Find("Bar").GetComponent<Image>();

                if (bar == null)
                {
                    Debug.Log("Bar bulunamad�");
                }
                else
                {

                    LeanTween.scaleX(bar.gameObject, 1, buildTime).setOnComplete(() => DestroyPanel(panelId));
                }
            }

            if (img != null && tmp != null)
            {
                img.sprite = sprite;
                tmp.text = panelText;
            }

            if (panelDictionary.ContainsKey(panelId))
            {
                Debug.LogWarning($"Panel ID zaten mevcut: {panelId}");
                Destroy(newPanel); // Ayn� ID i�in birden fazla panel olu�mas�n� engelle
                return;
            }

            panelDictionary.Add(panelId, newPanel); // Paneli ID ile ili�kilendir

            // Paneli aktifle�tir/deaktif et
            if (OpenProcessPanelWithAnim.isPanelActive)
            {
                activePanels.Add(newPanel);
                Debug.Log($"Panel '{panelId}' aktif.");
            }
            else
            {
                deactivePanels.Add(newPanel);
                newPanel.SetActive(false);
                Debug.Log($"Panel '{panelId}' pasif.");
            }

            Debug.Log($"Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");
        }

        else if (processType == "HealSoldier")
        {
            GameObject newPanel = Instantiate(SoldierHealPanelPrefab, panelContainer);

            Image img = newPanel.transform.Find("ProcessImage").GetComponent<Image>();
            TextMeshProUGUI tmp = newPanel.transform.Find("HealedSoldierAmountText").GetComponent<TextMeshProUGUI>();
            Image background = newPanel.transform.Find("Background").GetComponent<Image>();
            Sprite sprite = Resources.Load<Sprite>("Military/HealSoldier");

            if (background == null)
            {
                Debug.Log("Background bulunamad�");
            }
            else
            {
                Image bar = background.transform.Find("Bar").GetComponent<Image>();

                if (bar == null)
                {
                    Debug.Log("Bar bulunamad�");
                }
                else
                {

                    LeanTween.scaleX(bar.gameObject, 1, buildTime).setOnComplete(() => DestroyPanel(panelId));
                }
            }

            if (img != null && tmp != null)
            {
                img.sprite = sprite;
                tmp.text = panelText;
            }

            if (panelDictionary.ContainsKey(panelId))
            {
                Debug.LogWarning($"Panel ID zaten mevcut: {panelId}");
                Destroy(newPanel); // Ayn� ID i�in birden fazla panel olu�mas�n� engelle
                return;
            }

            panelDictionary.Add(panelId, newPanel); // Paneli ID ile ili�kilendir

            // Paneli aktifle�tir/deaktif et
            if (OpenProcessPanelWithAnim.isPanelActive)
            {
                activePanels.Add(newPanel);
                Debug.Log($"Panel '{panelId}' aktif.");
            }
            else
            {
                deactivePanels.Add(newPanel);
                newPanel.SetActive(false);
                Debug.Log($"Panel '{panelId}' pasif.");
            }

            Debug.Log($"Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");
        }
    }

    // Paneli yok et
    public void DestroyPanel(string panelId)
    {
        if (panelDictionary.ContainsKey(panelId))
        {
            GameObject panelToRemove = panelDictionary[panelId];

            if (activePanels.Contains(panelToRemove))
                activePanels.Remove(panelToRemove);

            if (deactivePanels.Contains(panelToRemove))
                deactivePanels.Remove(panelToRemove);

            Destroy(panelToRemove);
            panelDictionary.Remove(panelId);

            Debug.Log($"Panel yok edildi: {panelId}");
        }
        else
        {
            Debug.LogWarning($"Panel bulunamad�: {panelId}");
        }
    }

    // Panellerin durumunu de�i�tir
    public void ChangeStatus()
    {
        Debug.Log("Panellerin durumunu de�i�tiriyorum...");
        Debug.Log($"Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");

        if (OpenProcessPanelWithAnim.isPanelActive)
        {
            foreach (GameObject panel in deactivePanels.ToArray())
            {
                deactivePanels.Remove(panel);
                activePanels.Add(panel);
                panel.SetActive(true);
            }
        }
        else
        {
            foreach (GameObject panel in activePanels.ToArray())
            {
                activePanels.Remove(panel);
                deactivePanels.Add(panel);
                panel.SetActive(false);
            }
        }

        Debug.Log($"G�ncel Aktif Panel Say�s�: {activePanels.Count}, Deaktif Panel Say�s�: {deactivePanels.Count}");
    }

    // Paneli g�ncelle (�rne�in panel textini de�i�tir)
    public void UpdatePanel(string panelId, string newText)
    {
        if (panelDictionary.ContainsKey(panelId))
        {
            GameObject panelToUpdate = panelDictionary[panelId];
            Text panelText = panelToUpdate.GetComponentInChildren<Text>();
            if (panelText != null)
            {
                panelText.text = newText;
                Debug.Log($"Panel g�ncellendi: {panelId}");
            }
        }
        else
        {
            Debug.LogWarning($"G�ncelleme yap�lamad�, panel bulunamad�: {panelId}");
        }
    }
}
