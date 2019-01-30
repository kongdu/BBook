using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class Quaker : MonoBehaviour
{
    public Transform[] AllTransforms;
    public GameObject bookcasePreFab;
    public ParticleSystem DustParticle;
    public float magnitude = 0.1f;
    public float duration = 10f;
    public int dropbooks = 5;
    public AudioSource audiosource;
    public AudioClip bookSound;

    //private float dropBooks;
    [SerializeField]
    private Transform slotTransform;

    private Vector3 originPos_bookcase;
    public List<Transform> AllBooksTransform;
    public List<GameObject> Slotlist;
    public List<Book> booknum = new List<Book>();
    private List<Vector3> originPos_books;

    public Rigidbody[] AllbooksRigidBody;

    public GameObject AllBooks;
    public GameObject bookshelf;

    public event Action OnCompleted = () => { };

    //public Quaker(int dropBooks, float magnitude, float duration)
    //{
    //    this.magnitude = magnitude;
    //    this.duration = duration;
    //    this.dropBooks = dropBooks;
    //}

    private void Start()
    {
        audiosource = GetComponent<AudioSource>();
        originPos_bookcase = bookshelf.transform.localPosition;
        originPos_books = new List<Vector3>();
        AllbooksRigidBody = AllBooks.GetComponentsInChildren<Rigidbody>();
        AllBooksTransform = new List<Transform>();
        for (int i = 0; i < AllbooksRigidBody.Length; i++)
        {
            AllBooksTransform.Add(AllbooksRigidBody[i].gameObject.GetComponent<Transform>());
            originPos_books.Add(AllbooksRigidBody[i].transform.localPosition);
        }
        Slotlist = new List<GameObject>();
        //StartQuake(dropbooks, magnitude, duration);
    }

    public void StartQuake(int dropbooks, float magnitude, float duration)
    {
        Debug.Log("StartCoroutine(QuakeSequence)");
        dropbooks = this.dropbooks;
        for (int i = 0; i < dropbooks; i++)
        {
            Slotlist.Add(GameObject.Instantiate(bookcasePreFab, slotTransform));
        }
        StartCoroutine(QuakeSequence(magnitude, duration, dropbooks));
    }

    private IEnumerator QuakeSequence(float magnitude, float time, int dropbooks)
    {
        Debug.Log("audiosource.Play();");
        audiosource.Play();
        //yield return StartCoroutine(ShakingBookcase(magnitude));
        yield return new WaitForSeconds(1f);
        StartCoroutine(ShakingBookcase(magnitude));
        Debug.Log("DustParticle.Play();");
        DustParticle.Play();
        //yield return new WaitWhile(() => DustParticle.isPlaying);
        Debug.Log("ShakingBooks(magnitude)");
        yield return new WaitForSeconds(5f);
        StartCoroutine(ShakingBooks(magnitude));
        Debug.Log("ShakingCam()");
        yield return new WaitForSeconds(5f);
        StartCoroutine(ShakingCam());
        Debug.Log("DropingBooks(dropbooks)");
        yield return StartCoroutine(DropingBooks(dropbooks));
        yield return new WaitForSeconds(2f);
        OnCompleted();
    }

    private IEnumerator ShakingBookcase(float magnitude)
    {
        while (this.duration > 0)
        {
            Vector3 randomValue = Random.insideUnitSphere * magnitude;
            bookshelf.transform.localPosition = Vector3.Lerp(bookshelf.transform.localPosition, originPos_bookcase + randomValue, 0.05f);
            this.duration = this.duration - Time.deltaTime;

            yield return null;
        }
    }

    private IEnumerator ShakingBooks(float magnitude)
    {
        while (this.duration > 0)
        {
            for (int i = 0; i < AllBooksTransform.Count; i++)
            {
                Vector3 randomValue = Random.insideUnitSphere * magnitude;
                AllBooksTransform[i].transform.localPosition = Vector3.Lerp(AllBooksTransform[i].transform.localPosition, originPos_books[i] + randomValue, 0.05f);
                //this.duration = this.duration - Time.deltaTime;
            }

            yield return null;
        }
    }

    public Camera mycam;

    private IEnumerator ShakingCam()
    {
        while (this.duration > 0)
        {
            Vector3 randomValue = Random.insideUnitSphere * magnitude;
            Camera.main.transform.localPosition = Vector3.Lerp(mycam.transform.localPosition, Camera.main.transform.localPosition + randomValue, 0.05f);
            yield return null;
        }
    }

    private IEnumerator DropingBooks(int dropbooks)
    {
        List<int> randomvaluelist = new List<int>();

        for (int k = 0; k < dropbooks; k++)
        {
            randomvaluelist.Add(Random.Range(0, AllbooksRigidBody.Length + 1));
        }
        randomvaluelist.Sort((t1, t2) => { return Random.Range(-1, 2); });

        //for(int i = 0; i < randomvaluelist.Count - 1; i++)
        //{
        //    for(int j = i; j < randomvaluelist.Count - 1; ++j)
        //    {
        //        if(randomvaluelist[j] == randomvaluelist[j + 1])
        //        {
        //            randomvaluelist.RemoveAt(j);
        //            randomvaluelist.Add(Random.Range(0, AllbooksRigidBody.Length));
        //            --j;
        //        }
        //    }
        //}

        for (int i = 0; i < randomvaluelist.Count; i++)
        {
            float randompower = Random.Range(140f, 240f);

            booknum.Add(AllbooksRigidBody[randomvaluelist[i]].GetComponent<Book>());
            booknum[i].enabled = true;
            booknum[i].bookNumber = i;
            Slotlist[i].transform.position = AllbooksRigidBody[randomvaluelist[i]].position;
            //Slotlist[i].GetComponent<BoxCollider>().enabled = true;
            AllbooksRigidBody[randomvaluelist[i]].AddForce(Vector3.forward * -randompower);
            AllbooksRigidBody[randomvaluelist[i]].gameObject.layer = 10;
            //GameObject.Instantiate(bookcasePreFab, originPos_books[i], Quaternion.identity);
        }

        yield return null;
    }
}