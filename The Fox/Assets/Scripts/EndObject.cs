using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndObject : MonoBehaviour
{
    public SceneLoader load;
    void OnTriggerEnter2D(Collider2D collision)
    {
        load.nextlevel();
    }
}
