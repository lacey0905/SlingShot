using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ball : MonoBehaviour
{

    public Transform pos;

    public Vector3 GetPos()
    {
        return pos.transform.position;
    }


}
