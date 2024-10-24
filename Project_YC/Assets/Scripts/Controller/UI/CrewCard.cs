using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CrewCard : MonoBehaviour
{
    private Transform aggressive;
    private Transform agitation;
    private Transform information;
    private Transform supply;
    private Transform mentality;
    private Transform reliability;

    private void Start()
    {
        if (aggressive == null)
            Init();
    }

    private void Init()
    {
        aggressive = transform.Find("Stats/Aggressive");
        agitation = transform.Find("Stats/Agitation");
        information = transform.Find("Stats/Information");
        supply = transform.Find("Stats/Supply");
        mentality = transform.Find("Stats/Mentality");
        reliability = transform.Find("Stats/Reliability");
    }

    public void UpdateData(CrewSO data)
    {
        if (aggressive == null)
            Init();

        aggressive.Find("Slider").GetComponent<Slider>().value = data.abilities[0];
        aggressive.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.abilities[0]}";
        agitation.Find("Slider").GetComponent<Slider>().value = data.abilities[1];
        agitation.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.abilities[1]}";
        information.Find("Slider").GetComponent<Slider>().value = data.abilities[2];
        information.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.abilities[2]}";
        supply.Find("Slider").GetComponent<Slider>().value = data.abilities[3];
        supply.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.abilities[3]}";
        mentality.Find("Slider").GetComponent<Slider>().value = data.mentality;
        mentality.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.mentality}";
        reliability.Find("Slider").GetComponent<Slider>().value = data.reliability;
        reliability.Find("Value").GetComponent<TextMeshProUGUI>().text = $"{data.reliability}";
    }
}
