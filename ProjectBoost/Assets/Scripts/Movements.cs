using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    AudioSource audio ; 
    Rigidbody rb ; 
    [SerializeField] float thrust ;
    [SerializeField] float rotationThrust ;
    [SerializeField] AudioClip EngineThrust;

    [SerializeField] ParticleSystem BoostEffect;
    [SerializeField] ParticleSystem LeftBoostEffect;
    [SerializeField] ParticleSystem RightBoostEffect;
    
    

    // Start is called before the first frame update
    void Start()
    {
        rb =GetComponent<Rigidbody>();
        audio = GetComponent<AudioSource>();
    }
    // Update is called once per frame
    void Update()
    {
        processInput();
        processRotation();
    }
    void processInput(){           
        
        if(Input.GetKey(KeyCode.Space)){
          
            rb.AddRelativeForce(0,Time.deltaTime*thrust,0);
            if(!audio.isPlaying){
                
                audio.PlayOneShot(EngineThrust);
                
            }
            if(!BoostEffect.isPlaying){
                BoostEffect.Play();
            }

        }
        else{
            audio.Stop();
            BoostEffect.Stop();
        }
    }
    void processRotation(){
        if(Input.GetKey(KeyCode.A)){
            
           rb.freezeRotation = true;
           transform.Rotate(Vector3.forward *rotationThrust*Time.deltaTime);
            rb.freezeRotation = false;
            if(!LeftBoostEffect.isPlaying){
                LeftBoostEffect.Play();
            }

        }

        else if(Input.GetKey(KeyCode.D)){
           
            rb.freezeRotation = true;
            transform.Rotate(-Vector3.forward*rotationThrust*Time.deltaTime);
            rb.freezeRotation = false;
            if(!RightBoostEffect.isPlaying){
                RightBoostEffect.Play();
            }
        }
        else{
            RightBoostEffect.Stop();
            LeftBoostEffect.Stop();
        }
    }

}
