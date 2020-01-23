using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowerEnterDialog : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public GameObject canvas;
    public GameObject chop;
    bool enter = false;
    bool activated;
    int counter;
    [SerializeField] public bool ShowerFinished;

    Text dialog;
    public Text myjuText;


    void Start() {
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = false;
        ShowerFinished = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E) && enter == true && gameManager.currentActiveType == "prysznic") {
            canvas.GetComponent<Canvas>().enabled = true;
            chop.GetComponent<Image>().enabled = true;
            counter = 1;
            activated = true;
        }

        
        if (activated && Input.GetKeyDown(KeyCode.Q) && ShowerFinished == false && gameManager.currentActiveType == "prysznic") {
            counter++;
        }

        if (ShowerFinished == true && gameManager.currentActiveType == "prysznic") {
            dialog.text = "JUŻ JESTEM CZYŚCIUTKI NIE BĘDĘ MARNOWAŁ WODY";
        }
        else
        if (counter == 1 && ShowerFinished == false && gameManager.currentActiveType == "prysznic") {
            dialog.text = "*MYJU MYJU*";
        }
        else
        if (counter == 2 && ShowerFinished == false && gameManager.currentActiveType == "prysznic") {
            dialog.text = "KURCZE A ŻEM SIE FAJNIE UMYŁ";
        }
        else
        if (counter == 3 && ShowerFinished == false && gameManager.currentActiveType == "prysznic") {
            dialog.text = "JAK GRECKI BUK";
        }
        else
        if (counter == 4 && ShowerFinished == false && gameManager.currentActiveType == "prysznic") {
            canvas.GetComponent<Canvas>().enabled = false;
            enter = false;
            ShowerFinished = true;
            gameManager.currentActiveType = "";
            myjuText.text = "WYKĄP SIĘ ✓";
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            enter = true;
            gameManager.currentActiveType = "prysznic";
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            canvas.GetComponent<Canvas>().enabled = false;
            enter = false;
            counter = 0;
            gameManager.currentActiveType = "";
        }
    }
}
