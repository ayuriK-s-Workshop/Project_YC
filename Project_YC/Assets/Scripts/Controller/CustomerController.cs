using UnityEngine;

public class CustomerController : MonoBehaviour
{
    private CharacterSO _currentCharacterData;
    private InterchangeableItemSO _currentItemData;

    public int currentCost;
    private int _minCost;


    public void UpdateCharacterData(int characterId)
    {
        _currentCharacterData = Manager.Data.characterDB[characterId];
        _currentItemData = Manager.Data.interchangeableItemDB[_currentCharacterData.itemId];

        currentCost = _currentItemData.actualValue;
        _minCost = _currentItemData.actualValue - (_currentItemData.actualValue / 10);
    }


    public int TryNegotiation(int value)
    {
        // ���� �ݾ��� ���� ������ ũ�ų� ���� �� or ���� �ݾװ��� ���̰� 2% ������ �� -> ���� ���� 
        if (currentCost <= value || (currentCost - value) <= currentCost / 100)
        {
            currentCost = value;
            return 0;
        }


        // ���� �ݾ��� ���� ������ ���� �� -> ���� ����
        else
        {
            if (value <= _minCost)
            {
                currentCost -= (currentCost - _minCost) / 2;
            }
            else
            {
                currentCost -= (currentCost - value) / 2;
            }

            return currentCost;
        }
    }
}
