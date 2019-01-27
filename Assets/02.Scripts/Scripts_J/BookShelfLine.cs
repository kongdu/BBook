using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//책장의 한 줄이 갖는 책들에 대한 정보.
public class BookShelfLine : MonoBehaviour
{
    
    public float totalBooks = 20;
    public List<Book_J> books = new List<Book_J>();
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void SetBooksColor(Color color)
    {
        foreach (var item in books)
        {
            item.SetColor(color);
        }
    }

    public void SetBooksName(string lang)
    {
        foreach (var item in books)
        {
            var index = Random.Range(0, BookManager.Instance.titleVariety);
            var list = BookManager.Instance.booksName[index];
            item.SetText((list[lang]).ToString());
        }
    }

    public void MemoPos()
    {
        foreach (var item in books)
        {
            item.MemorizePos();
        }
    }
}
