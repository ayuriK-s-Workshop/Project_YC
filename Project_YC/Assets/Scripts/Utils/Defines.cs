/* Defines.cs | 최초 작성자 - 이원섭
 * 각종 열거형이나 클래스 선언에 사용함.
 * 추가적인 클래스 선언이 필요한 경우에는 이원섭과 상의 후 결정할 것
 */
using System;
using UnityEngine;

namespace Defines
{
    public class Enums
    {
        // 캐릭터 성격
        public enum CharacterPersonality
        {
            Normal,     // 일반
            Impatient,  // 급함
            Careful,    // 꼼꼼함
            Stupid,     // 호구
        }
    }

    public class Classes
    {
        [Serializable]
        public class DialogueText
        {
            public int nextIndex;
            public bool isOpponent;
            public bool isEnd;
            [TextArea]
            public string text;
        }
    }
}
