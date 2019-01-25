using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Book : MonoBehaviour
{
    public delegate void Book_delegate();
    public static event Book_delegate Book_Event;

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

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("bookshelf"))
        {
            StartCoroutine(Book_SNAP());
            this.other = other.gameObject;
            //transform.SetParent(other.transform);
            
            

        }
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("bookshelf"))
    //    {
    //        StartCoroutine(Book_SNAP2());
    //    }
    //}


}
