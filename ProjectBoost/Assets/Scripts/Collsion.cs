using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement ; 

public class Collsion : MonoBehaviour
{
    AudioSource audio ;
    PlayerMovement move ;
    [SerializeField] float delay ; 
    [SerializeField] AudioClip Finished;
    [SerializeField] AudioClip Crashed;

    [SerializeField] ParticleSystem FinishedEffect;
    [SerializeField] ParticleSystem CrashedEffect;

    bool isTransitioning = false;
    
    void Start()
    {
        move = GetComponent<PlayerMovement>();
        audio = GetComponent<AudioSource>();

    }

    
    void OnCollisionEnter(Collision other)
    {   

        if(isTransitioning){ return ;}

        switch(other.gameObject.tag){

            case "Start" :
                Debug.Log("Game has started");
                break;
            
            case "Finish" :
                StartSuccess();
                break;
            
            case "Fuel":
                Debug.Log("You picked Up fuel");
                break;
            
            default:
                 StartCrashing();
                break;

        }
    }

    void StartSuccess(){
        isTransitioning = true ;
        audio.Stop();
        FinishedEffect.Play();
        move.enabled = false ;
        Invoke("LoadNextLevel" , delay);
        audio.PlayOneShot(Finished);

    }


    void StartCrashing(){
        
        isTransitioning = true ;
        audio.Stop();
        audio.PlayOneShot(Crashed);
        move.enabled = false ; 
        Invoke("RelodLevel" , delay);
        CrashedEffect.Play();
    }

    void LoadNextLevel(){
        move.enabled = false ; 
        int currentScene = SceneManager.GetActiveScene().buildIndex;
        int NextScene = currentScene + 1;
        if(NextScene == SceneManager.sceneCountInBuildSettings){
            NextScene = 0 ;
        }
        SceneManager.LoadScene(NextScene);
    }
    void RelodLevel(){

        int currentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentScene);
    }
}
