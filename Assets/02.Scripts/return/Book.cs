using System.Collections;
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
    public cakeslice.Outline _outline;
    public bool Stack_on = false;
    public bool outlineOn = false;
    public AudioSource bookAudio;

    public AudioClip inputSound;
    public GameObject other;

    public static int SnapCount = 0;

    public bool plugged;

    private void Start()
    {
        _outline.enabled = false;
    }

    private void Awake()
    {
        plugged = true;
    }

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

    private IEnumerator Plugged_corutine()
    {
        this.plugged = true;
        yield return null;
    }

    public void SnapBook()
    {
        if (other != null)
        {
            transform.position = other.transform.position;
            transform.rotation = other.transform.rotation;

            other.GetComponent<Book_Sh>().Book_Check = bookNumber;
            StartCoroutine(Plugged_corutine());
            //  Yeon.RefCtr.instance.AnswerCountText.text = ++SnapCount + "/" + GameObject.Find("Quake").GetComponent<Quaker>().dropbooks;
        }
    }

    private int chkscore;

    private void OnCollisionEnter(Collision other)
    {
        if (other.collider.CompareTag("bookshelf"))
        {
            Debug.Log("bookshelf체크");
            chkscore = other.gameObject.GetComponent<Book_Sh>().Book_Check;
            chkscore = bookNumber;
            StartCoroutine(Book_SNAP());
            bookAudio.clip = inputSound;
            bookAudio.Play();
            this.other = other.gameObject;
            //transform.SetParent(other.transform);
        }
        else if (other.collider.CompareTag("Ground"))
        {
            Debug.Log("Ground체크");
            bookAudio.Play();
            Snaped = false;
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
        if (gameObject.layer == 10)
            _outline.enabled = true;
    }

    public void OutlinerOff()
    {
        if (gameObject.layer == 10)
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