using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using TMPro;

public class Menu : MonoBehaviour
{

    public AudioSource OpenSound;
    public AudioSource GeneriqueSound;

    public GameObject MenuScreen;
    public GameObject GameScreen;
    public GameObject Charactères;

    public Button StartButton;
    public Button QuitButton;


    // Start is called before the first frame update
    private void Start()
    {
            
            // On lance la musique d'entrée
            OpenSound.Play();

            
            GameScreen.SetActive(false); 

            // On désactive les personnages du jeu pour éviter que se lance le script du Player
            Charactères.SetActive(false);
            
            // On écoute les boutons et on renvois aux fonctions.
            QuitButton.onClick.AddListener(Exit);
            StartButton.onClick.AddListener(Open);
    }

    // Update is called once per frame
    void Update()
    {}

    // Ferme l'application
    public void Exit(){
   
            # if UNITY_EDITOR
                EditorApplication.ExitPlaymode();

            #else
                Application.Quit();
            #endif
        } 

    
    // on ouvre l'application
    public void Open(){

            // On arrête la musique
            OpenSound.Stop();
            // On désactive l'écran de démarage
            MenuScreen.SetActive(!MenuScreen.activeSelf);
            // On lance le son
            GeneriqueSound.Play();
            // On lance l'écran de jeu
            GameScreen.SetActive(true);
            // On active les personnage
            Charactères.SetActive(true);
        } 
   
}
