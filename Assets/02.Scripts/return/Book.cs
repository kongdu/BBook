﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Book : MonoBehaviour
{
    public delegate void Book_delegate();

    public static event Book_delegate Book_Event;

    public int bookNumber = 0;
    public bool Snaped = false;
     public Text title = null;
    public MeshRenderer _mesh;
    public Outline _outline;

    public bool Stack_on = false;

    public GameObject other;

    private IEnumerator Book_SNAP()
    {
        Snaped = true;
        yield return null;
    }

    private IEnumerator Book_SNAP2()
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
        if (other.CompareTag("bookshelf"))
        {
            chkscore = other.gameObject.GetComponent<Book_Sh>().shelfNum;
            StartCoroutine(Book_SNAP());
            this.other = other.gameObject;
            //transform.SetParent(other.transform);
        }
    }

    public int Scorechking()
    {
        int result = 0;
        if (chkscore == this.bookNumber)
        {
            result = 1;
        }
        return result;
    }

    public void SetText(string newTitle)
    {
        title.text = newTitle;
    }

    public void SetColor(Color color)
    {
        _mesh.material.color = color;
    }

    public void OutlinerOn()
    {
        _outline.enabled = true;
    }

    public void OutlinerOff()
    {
        _outline.enabled = false;
    }

    //private void OnTriggerExit(Collider other)
    //{
    //    if (other.CompareTag("bookshelf"))
    //    {
    //        StartCoroutine(Book_SNAP2());
    //    }
    //}
}