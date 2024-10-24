using System.Collections.Generic;
using UnityEngine;

public class ResistanceManageRecruitUI : MonoBehaviour
{
    private List<CrewSO> _randomCrewDatas = new List<CrewSO>();
    private List<GameObject> _crewCrads = new List<GameObject>();

    void Start()
    {
        GameObject crewCardPrefab = Resources.Load("Prefabs/UI/CrewCard") as GameObject;
        Transform storageInstancePoint = transform.Find("ScrollView/Viewport/Content");
        int totalCrewCount = Random.Range(1, 3);
        for (int i = 0; i < totalCrewCount; i++)
        {
            _randomCrewDatas.Add(CreateRandomCrewData());
            Instantiate(crewCardPrefab, storageInstancePoint).GetComponent<CrewCard>().UpdateData(_randomCrewDatas[i]);
        }
        gameObject.SetActive(false);
    }

    private CrewSO CreateRandomCrewData()
    {
        CrewSO crew = new CrewSO();
        int total = Random.Range(50, 100);
        for (int i = 0; i < crew.abilities.Length; i++)
        {
            crew.abilities[i] = Random.Range(0, total);
            total -= crew.abilities[i];
        }
        crew.mentality = Random.Range(0, 100);
        crew.reliability = Random.Range(0, 100);

        return crew;
    }
}
