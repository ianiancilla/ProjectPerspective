using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionArrows : MonoBehaviour
{
    [SerializeField] Transform ObjectToFollow;
    void Update()
    {
        if (ObjectToFollow != null)
        {
            transform.position = ObjectToFollow.position;
        }        
    }
}
