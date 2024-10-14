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
        // 제안 금액이 현재 값보다 크거나 같을 때 or 제안 금액과의 차이가 2% 안쪽일 때 -> 제안 수락 
        if (currentCost <= value || (currentCost - value) <= currentCost / 100)
        {
            currentCost = value;
            return 0;
        }


        // 제안 금액이 현재 값보다 작을 때 -> 제안 거절
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

    public InterchangeableItemSO GetCurrentItemData()
    {
        return _currentItemData;
    }
}
