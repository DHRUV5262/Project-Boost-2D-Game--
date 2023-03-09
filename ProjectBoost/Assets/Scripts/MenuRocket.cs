using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuRocket : MonoBehaviour
{

    [SerializeField] ParticleSystem BoostEffect;

    PlayerMovement rotate ;

    [SerializeField] ParticleSystem LeftBoostEffect;
    [SerializeField] ParticleSystem RightBoostEffect;
    [SerializeField] float rotationThrust ;
    


    // Start is called before the first frame update
    void Start()
    {
        rotate = GetComponent<PlayerMovement>();
    }

    // Update is called once per frame
    void Update()
    {
        Upthrust();
        rotates();
    }

    void Upthrust(){
        if(Input.GetKey(KeyCode.Space)){
            if(!BoostEffect.isPlaying){
                BoostEffect.Play();
            }
        }
        else
        {
            BoostEffect.Stop();
        }
    }

    void rotates(){
        if(Input.GetKey(KeyCode.A)){
            
           transform.Rotate(Vector3.forward *rotationThrust*Time.deltaTime);
            if(!LeftBoostEffect.isPlaying){
                LeftBoostEffect.Play();
            }
        }
        else if(Input.GetKey(KeyCode.D)){
           
            transform.Rotate(-Vector3.forward*rotationThrust*Time.deltaTime);
            if(!RightBoostEffect.isPlaying){
                RightBoostEffect.Play();
            }
        }

        else{
            RightBoostEffect.Stop();
            LeftBoostEffect.Stop();
        }
    }

    public void ChageLevel(){
        
    }


}
