using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace Yeon
{
    /// <summary>
    /// 레퍼런스 연결을 위한 클래스
    /// </summary>
    public class RefCtr : MonoBehaviour
    {
        public static RefCtr instance = null;

        public Button startButton = null; // 상태1. 시작버튼
        public Text showTime = null; // 상태2. 정답 보여주는 시간 텍스트
        public RectTransform noticelPanel = null; //상태3. 지진경보 경고 패널
        public RectTransform playingPanel = null; //상태4. (타이머 + 정답개수)패널
        public Text timer = null; //상태 4. (타이머)
        public RectTransform winPanel = null; //상태5. 이겼을때
        public RectTransform losePanel = null;  //상태5. 졌을때

        private void Awake()
        {
            if (instance == null)
            {
                instance = this;
            }
            else if (instance != this)
            {
                Destroy(this.gameObject);
            }
        }
    }
}