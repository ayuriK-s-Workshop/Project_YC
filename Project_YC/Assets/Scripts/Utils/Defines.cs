/* Defines.cs | 최초 작성자 - 이원섭
 * 각종 열거형이나 클래스 선언에 사용함.
 * 추가적인 클래스 선언이 필요한 경우에는 이원섭과 상의 후 결정할 것
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


        // 캐릭터 성격
        public enum CharacterPersonality
        {
            Normal,     // 일반
            Impatient,  // 급함
            Careful,    // 꼼꼼함
            Stupid,     // 호구
        }
    }

    public class SceneComponents
    {
        // 전당포 UI 구성 요소들
        public enum PawnshopUI
        {
            DialogueSection,
            TradeSection,
            NegoSection,
            DrawerSection,
            PlayerMoney,
            TriggerButton,
            TradeAcceptButton,
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
            public int tradeAcceptIndex;    // 거래 성사
            public int tradeDenyIndex;      // 거래 거절
        }

        [Serializable]
        public class TradeDialogueText
        {
            public string[] texts;
        }
    }
}
