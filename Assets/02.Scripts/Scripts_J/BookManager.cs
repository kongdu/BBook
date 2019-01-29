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
    public string[] Language = { "Korean", "English", "Chinese", "Japanese", "Greek", "Russian", "Arabian", "Mongolian" };
    
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
            item.SetColor(colors[Random.Range(0, colorVariety)]);
            var lang = Language[Random.Range(0, langVariety)];
            var index = Random.Range(0, BookManager.Instance.titleVariety);
            var list = BookManager.Instance.booksName[index];
            item.SetText((list[lang]).ToString());
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
