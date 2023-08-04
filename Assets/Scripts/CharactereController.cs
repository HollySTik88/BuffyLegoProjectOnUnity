using System.Collections;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CharactereController : MonoBehaviour
{


    public GameObject MenuScreen;
    public GameObject GameScreen;
    
    public float MovementSpeed = 2f;
    public int Score = 0;
    public int Monsters = 0;
    public TMP_Text ScoreText;
    private GameObject [] MonsterTab;


    public AudioSource DecapitationSound;
    public AudioSource WinningSound;
    public AudioSource YouWinSound;
    public AudioSource GeneriqueSound;
    public AudioSource OpenSound;


    public Button ForwardButton;
    public Button BackwardButton;
    public Button LeftButton;
    public Button RightButton;
    public Button UpButton;
    public Button DownButton;

    private Rigidbody Rigidbody;
    private Vector3 MovementDirection = Vector3.zero; 

    
    // On enclenche l'affichage du score
    private void Awake(){
    ScoreText.text = Score.ToString();
    }

    void Start()
    {   

        Rigidbody = GetComponent<Rigidbody>();

        // On compte le nombre de monstres à combattre 
        MonsterTab = GameObject.FindGameObjectsWithTag("Fightable");
        foreach(GameObject Monstre in MonsterTab){
            Monsters +=1;
        }


        // Ajouter les écouteurs d'événements pour les boutons UI        
        ForwardButton.onClick.AddListener(OnForwardButtonPressed);
        BackwardButton.onClick.AddListener(OnBackwardButtonPressed);
        LeftButton.onClick.AddListener(OnLeftButtonPressed);
        RightButton.onClick.AddListener(OnRightButtonPressed);
        UpButton.onClick.AddListener(OnUpButtonPressed);
        DownButton.onClick.AddListener(OnDownButtonPressed);



    }

    void Update(){
        }

        
    

    void OnForwardButtonPressed(){
        // Mouvement vers l'avant
        Vector3 movement = new Vector3 (0.0f, 0.0f, -2f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
        
    }

    void OnBackwardButtonPressed(){
        // Mouvement vers l'arrière
        Vector3 movement = new Vector3 (0.0f, 0.0f, 2f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
    }

    void OnLeftButtonPressed(){
       // Mouvement vers la gauche
        Vector3 movement = new Vector3 (-2f, 0.0f, 0.0f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
    }

    void OnRightButtonPressed(){
        
        // Mouvement vers la droite
        Vector3 movement = new Vector3 (2f, 0.0f, 0.0f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
    }

    void OnUpButtonPressed(){
        
        // Mouvement vers le haut
        Vector3 movement = new Vector3 (0.0f, 2f, 0.0f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
    }

    void OnDownButtonPressed(){
        
        // Mouvement vers le bas
        Vector3 movement = new Vector3 (0.0f, -2f, 0.0f);
		Rigidbody.transform.position += movement * MovementSpeed * Time.deltaTime;
    }



    private void OnCollisionEnter(Collision collision){

        if (collision.collider.CompareTag("Fightable")){

            // la tête est tranchée :
            DecapitationSound.Play();
            Destroy(collision.gameObject);
             
            // Le score s'incrémente
            Score ++;
            ScoreText.text = Score.ToString();

            // Le nombre de monstres décrémente
            Monsters --;
            
        }
        // S'il n'y à plus de monstre la partie est gagnée !
        if (Monsters < 1){
            GeneriqueSound.Stop();
            WinningSound.Play(); // active le son de victoire

            // on attends 8 secondes avant de renvoyer au menu de démarage
            
            StartCoroutine(BackToMenu(8f));

            // on attends 3 secondes Pour lancer la voix de fin
            StartCoroutine(WinningVoice(3f));
            
        }
            
    }

        // Coroutine
    IEnumerator WinningVoice(float halt){
        yield return new WaitForSeconds(halt);
        YouWinSound.Play();
    }

    // Coroutine
    IEnumerator BackToMenu(float halt){
        yield return new WaitForSeconds(halt);
        Application.LoadLevel(0);
    }
 
}
