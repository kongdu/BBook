using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookManager : MonoBehaviour
{
    private static BookManager _instance = null;
    public static BookManager Instance
    {
        get
        {
            if (_instance == null)
            {
                _instance = FindObjectOfType(typeof(BookManager)) as BookManager;

                if (_instance == null)
                {
                    Debug.LogError("There's no active BookManager Object");
                }
            }
            return _instance;
        }
    }

    public Color[] colors = { Color.white, Color.green, Color.red, Color.blue, Color.yellow, new Color(0.8f, 0.4f, 0f), Color.grey, new Color(1f, 0.4f, 1f) };
    public string[] Language = { "KOREAN", "ENGLISH", "CHINESE", "JAPANESE", "GREEK", "RUSSIAN", "ARABIAN", "MONGOLIAN" };
    
    //정답으로 인정하는 거리와 각도
    public float correctDist = 0.1f;
    public float correctRot = 10f;

    //책 제목의 수
    public int titleVariety = 21;


    public List<Dictionary<string, object>> booksName = null;
    public List<Book> books = new List<Book>();

    private void Awake()
    {
        booksName = CSVReader.Read("LibraryEarthquakeBooksName");
    }

    public void SetBooksProp(int colorVariety, int langVariety)
    {
        foreach (var item in books)
        {
            //랜덤 색 전달
            var coloridx = colors[Random.Range(0, colorVariety)];
            item.SetColor(coloridx);

            //랜덤 언어의 랜덤 제목 전달
            var lang = Language[Random.Range(0, langVariety)];    //랜덤 언어 설정
            var index = Random.Range(0, titleVariety);            //제목 수 중 랜덤인덱스
            var list = booksName[index];                          //딕셔너리의 리스트 중 책 제목의 인덱스
            item.SetText((list[lang]).ToString());                //해당 인덱스에 해당 언어 전달.
            
        }
    }

    public void buttontest()
    {
        foreach (var item in books)
        {
            item.SetColor(colors[Random.Range(0, 4)]);
            var str = Language[Random.Range(0, 2)];
            var index = Random.Range(0, BookManager.Instance.titleVariety);
            var list = BookManager.Instance.booksName[index];
            item.SetText((list[str]).ToString());
        }
    }
}
