using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class Escape : MonoBehaviour
{

    public Button EscapeButton;

    public GameObject MenuScreen;
    public GameObject GameScreen;
    public AudioSource OpenSound;
    public AudioSource GeneriqueSound;


    // Start is called before the first frame update
    private void Start()
    {
    
    }

    // Update is called once per frame
    void Update()
    {
        EscapeButton.onClick.AddListener(Exit);
    }

    public void Exit(){

        MenuScreen.SetActive(true); // on renvois au menu de démaragage
        GameScreen.SetActive(false); // On efface l'écran de jeu
        GeneriqueSound.Stop();
        OpenSound.Play(); // On relance le son du menu


        } 

   
}

