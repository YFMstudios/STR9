using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class SliderController : MonoBehaviour
{
    public UnityEngine.UI.Slider savasciSlider;
    public UnityEngine.UI.Slider okcuSlider;
    public InputField savasciInputField;
    public InputField okcuInputField;

    public TextMeshProUGUI AltinText;
    public TextMeshProUGUI KeresteText;
    public TextMeshProUGUI TasText;
    public TextMeshProUGUI YemekText;
    public TextMeshProUGUI DemirText;

    

    private void Start()
    {
        // Slider'lar�n wholeNumbers �zelli�ini true olarak ayarlama
        savasciSlider.wholeNumbers = true;
        okcuSlider.wholeNumbers = true;

        // Slider'lar�n maksimum de�erlerini ayarlama
        savasciSlider.maxValue = 100; // �rne�in, savasciSlider'�n maksimum de�eri 100
        okcuSlider.maxValue = 50;     // �rne�in, okcuSlider'�n maksimum de�eri 50

        savasciInputField.text = "0";
        savasciSlider.value = 0;
        savasciSlider.onValueChanged.AddListener(delegate { OnSavasciSliderChanged(); });

        okcuInputField.text = "0";
        okcuSlider.value = 0;
        okcuSlider.onValueChanged.AddListener(delegate { OnOkcuSliderChanged(); });


        savasciInputField.onEndEdit.AddListener(OnSavasciInputEndEdit);
        okcuInputField.onEndEdit.AddListener(OnOkcuInputEndEdit);
    }

    // Sava��� slider'� de�i�ti�inde hem maliyetleri hem de InputField'� g�ncelle
    private void OnSavasciSliderChanged()
    {
        savasciInputField.text = savasciSlider.value.ToString();
        UpdateAllCosts();
    }

    // Ok�u slider'� de�i�ti�inde hem maliyetleri hem de InputField'� g�ncelle
    private void OnOkcuSliderChanged()
    {
        okcuInputField.text = okcuSlider.value.ToString();
        UpdateAllCosts();
    }


    // T�m slider'lar�n mevcut de�erlerini kullanarak maliyetleri g�ncelleyen fonksiyon
    private void UpdateAllCosts()
    {
        // Her bir slider'�n de�erini al
        float savasciCount = savasciSlider.value;
        float okcuCount = okcuSlider.value;

        // T�m birimlerin maliyetlerini toplu olarak hesapla
        float totalAltin = (savasciCount * 5) + (okcuCount * 7) ;
        float totalYemek = (savasciCount * 5) + (okcuCount * 6) ;
        float totalDemir = (savasciCount * 5) + (okcuCount * 3) ;
        float totalTas = (savasciCount * 5) + (okcuCount * 2);
        float totalKereste = (savasciCount * 5) + (okcuCount * 10);

        // Text alanlar�n� g�ncelle
        AltinText.text = totalAltin.ToString();
        YemekText.text = totalYemek.ToString();
        DemirText.text = totalDemir.ToString();
        TasText.text = totalTas.ToString();
        KeresteText.text = totalKereste.ToString();
    }

    // InputField de�i�ti�inde slider'� g�ncelle
    private void OnSavasciInputEndEdit(string value)
    {
        float floatValue;
        if (float.TryParse(value, out floatValue))
        {
            savasciSlider.value = Mathf.Clamp(floatValue, savasciSlider.minValue, savasciSlider.maxValue);
        }
    }

    private void OnOkcuInputEndEdit(string value)
    {
        float floatValue;
        if (float.TryParse(value, out floatValue))
        {
            okcuSlider.value = Mathf.Clamp(floatValue, okcuSlider.minValue, okcuSlider.maxValue);
        }
    }

}
