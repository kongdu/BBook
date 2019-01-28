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

    private Vector3 originPos_bookcase;
    public List<Transform> AllBooksTransform;
    private List<Vector3> originPos_books;
    public Rigidbody[] AllbooksRigidBody;

    public GameObject AllBooks;
    public GameObject bookcase;

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
        originPos_bookcase = bookcase.transform.localPosition;
        originPos_books = new List<Vector3>();
        AllbooksRigidBody = AllBooks.GetComponentsInChildren<Rigidbody>();
        AllBooksTransform = new List<Transform>();
        for (int i = 0; i < AllbooksRigidBody.Length; i++)
        {
            AllBooksTransform.Add(AllbooksRigidBody[i].gameObject.GetComponent<Transform>());
            originPos_books.Add(AllbooksRigidBody[i].transform.localPosition);
        }

        StartQuake(dropbooks, magnitude, duration);
    }

    public void StartQuake(int dropbooks, float magnitude, float duration)
    {
        StartCoroutine(QuakeSequence(magnitude, duration, dropbooks));
    }

    private IEnumerator QuakeSequence(float magnitude, float time, int dropbooks)
    {
        audiosource.Play();
        yield return StartCoroutine(ShakingBookcase(magnitude));

        DustParticle.Play();
        yield return new WaitWhile(() => DustParticle.isPlaying);

        yield return StartCoroutine(ShakingBooks(magnitude));

        yield return StartCoroutine(ShakingCam());

        yield return StartCoroutine(DropingBooks(dropbooks));

        OnCompleted();
    }

    private IEnumerator ShakingBookcase(float magnitude)
    {
        while (this.duration > 0)
        {
            Vector3 randomValue = Random.insideUnitSphere * magnitude;
            bookcase.transform.localPosition = Vector3.Lerp(bookcase.transform.localPosition, originPos_bookcase + randomValue, 0.05f);
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

    private IEnumerator ShakingCam()
    {
        while (this.duration > 0)
        {
            Vector3 randomValue = Random.insideUnitSphere * magnitude;
            Camera.main.transform.localPosition = Vector3.Lerp(Camera.main.transform.localPosition, Camera.main.transform.localPosition + randomValue, 0.05f);
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

            var booknum = AllbooksRigidBody[i].GetComponent<Book>();
            //될지 안될지 모르겠음 이건 모두 꺼놓고 얘만 킬라고 한거임
            booknum.enabled = true;
            booknum.bookNumber = i;
            AllbooksRigidBody[i].AddForce(Vector3.forward * -randompower);
            GameObject.Instantiate(bookcasePreFab, booknum.transform);
        }

        yield return null;
    }
}