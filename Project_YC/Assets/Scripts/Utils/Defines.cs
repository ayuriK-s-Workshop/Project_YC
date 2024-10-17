/* Defines.cs | ���� �ۼ��� - �̿���
 * ���� �������̳� Ŭ���� ���� �����.
 * �߰����� Ŭ���� ������ �ʿ��� ��쿡�� �̿����� ���� �� ������ ��
 */
using System;
using UnityEngine;

namespace Defines
{
    public class Enums
    {
        public enum Scenes
        {
            None = -1,
            PawnshopScene,
            ResistanceManageScene,
        }


        // ĳ���� ����
        public enum CharacterPersonality
        {
            Normal,     // �Ϲ�
            Impatient,  // ����
            Careful,    // �Ĳ���
            Stupid,     // ȣ��
        }


        // ��ȭ �̺�Ʈ��
        public enum DialogueEvent
        {
            Start,
            TradeStart,
            Paused,
            End,
        }


        public enum KeyInputTypes
        {
            Down,
            Press,
            Up,
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

        // ������ UI ���� ��ҵ�
        public enum ResistanceManageUI
        {
            StorageUI,
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
        }
    }
}
