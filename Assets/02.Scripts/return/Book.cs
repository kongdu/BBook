using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public delegate void Book_delegate();
    public static event Book_delegate Book_Event;
    public int bookNumber = 0;
    public bool Snaped = false;


    public bool Stack_on = false;

    public GameObject other;

    IEnumerator Book_SNAP()
    {
        Snaped = true;
        yield return null;
    }

    IEnumerator Book_SNAP2()
    {
        Snaped = false;
        yield return null;
    }

    public void SnapBook()
    {
        transform.position = other.transform.position;
        transform.rotation = other.transform.rotation;
    }

    private int chkscore;

    private void OnTriggerEnter(Collider other)
    {
        chkscore = other.gameObject.GetComponent<Book_Sh>().shelfNum;
        if (other.CompareTag("bookshelf"))
        {
            
            StartCoroutine(Book_SNAP());
            this.other = other.gameObject;
            //transform.SetParent(other.transform);
        }
    }
    
    public int Scorechking()
    {
        int result = 0;
        if (chkscore==this.bookNumber)
        {
            result = 1;
        }
        return result;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("bookshelf"))
    //    {
    //        StartCoroutine(Book_SNAP2());
    //    }
    //}


}
