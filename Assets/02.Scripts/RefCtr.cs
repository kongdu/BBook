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
        public RectTransform upperPanel = null;
        public Button startButton = null;


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