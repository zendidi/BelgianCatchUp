using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExclamPoint : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        gameObject.LeanMoveY(gameObject.transform.position.y - 0.5f, 2).setEaseOutQuad().setLoopPingPong();
    }
}
