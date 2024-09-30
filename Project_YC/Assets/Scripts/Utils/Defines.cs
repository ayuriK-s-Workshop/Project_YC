/* Defines.cs | ���� �ۼ��� - �̿���
 * ���� �������̳� Ŭ���� ���� �����.
 * �߰����� Ŭ���� ������ �ʿ��� ��쿡�� �̿����� ���� �� ������ ��
 */
using System;
using System.Collections.Generic;
using UnityEngine;

namespace Defines
{
    public class Enums
    {
        public enum Scenes
        {
            PawnshopScene,
        }


        // ĳ���� ����
        public enum CharacterPersonality
        {
            Normal,     // �Ϲ�
            Impatient,  // ����
            Careful,    // �Ĳ���
            Stupid,     // ȣ��
        }
    }

    public class SceneComponents
    {
        // ������ UI ���� ��ҵ�
        public enum PawnshopUI
        {
            DialogueSection,
            TradeSection,
            NegoSection,
            DrawerSection,
            PlayerMoney,
            TriggerButton,
            TradeAcceptButton,
            TradeNegoButton,
            TradeDenyButton,
            ValueIncreaseButton,
            ValueDecreaseButton,
            ValueInputField,
        }
    }

    public class Classes
    {
        [Serializable]
        public class DialogueText
        {
            public int nextIndex;
            public bool justNext;
            public bool isOpponent;
            public bool isTradeStart;
            public bool isEnd;
            [TextArea]
            public string text;
            public int tradeAcceptIndex;    // �ŷ� ����
            public int tradeDenyIndex;      // �ŷ� ����
        }
    }
}
