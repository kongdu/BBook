using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{
    List<Dictionary<string, object>> data = null;

    private void Awake()
    {
        data = CSVReader.Read("LibraryEarthquakeLevel");
    }
    // Start is called before the first frame update
    void Start()
    {
        for(int i=0;i<28;i++)
        {
            Debug.Log(data[i]["Color"].ToString() + data[i]["Language"].ToString());
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
