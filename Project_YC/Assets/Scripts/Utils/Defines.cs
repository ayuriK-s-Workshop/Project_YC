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
        // ĳ���� ����
        public enum CharacterPersonality
        {
            Normal,     // �Ϲ�
            Impatient,  // ����
            Careful,    // �Ĳ���
            Stupid,     // ȣ��
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
