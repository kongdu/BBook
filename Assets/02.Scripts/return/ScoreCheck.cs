using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreCheck : MonoBehaviour
{
    public Quaker quaker;
    public int pushedBookcount = 0;
    // Start is called before the first frame update
    public bool CheckingNextState(float time)
    {
        if (time >= 0 )
        {
            if (pushedBookcount < 4)
            {
                for (int i = 0; i < quaker.dropbooks; i++)
                {
                    var book = quaker.AllbooksRigidBody[i].GetComponent<Book>();
                    if (book.Snaped == true)
                    {
                        pushedBookcount++;
                    }
                }
                return false;
            }
            return true;
        }
        return true;
    }
    

    // Update is called once per frame
    
}
