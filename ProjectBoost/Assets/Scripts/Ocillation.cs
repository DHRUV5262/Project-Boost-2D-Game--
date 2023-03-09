using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ocillation : MonoBehaviour
{
    Vector3 S;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] [Range(0,1)] float MovementFactor ;
    [SerializeField] float period = 2f ;
    // Start is called before the first frame update
    void Start()
    {
        S = transform.position ; 
    }

    // Update is called once per frame
    void Update()
    {
        if(period <= Mathf.Epsilon){ return ;}
        const float tua = Mathf.PI *2 ;
        float cycle = Time.time / period ;

        float rawSinwave = Mathf.Sin(tua* cycle);
        MovementFactor = (rawSinwave + 1f)/ 2 ;

        Vector3 offset = MovementVector*MovementFactor ;
        transform.position = offset + S ;
    }
}
