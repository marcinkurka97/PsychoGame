using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingEnterDialog : MonoBehaviour
{
    public GameManager gameManager;
    public GameObject player;
    public GameObject canvas;
    public GameObject chop;
    bool enter = false;
    bool activated;
    int counter;
    [SerializeField] public bool EatingFinished;

    Text dialog;
    public Text jedzuText;


    void Start() {
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = false;
        EatingFinished = false;
        gameManager = FindObjectOfType<GameManager>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E) && enter == true && gameManager.currentActiveType == "lodówa") {
            canvas.GetComponent<Canvas>().enabled = true;
            chop.GetComponent<Image>().enabled = true;
            counter = 1;
            activated = true;
        }

        if (activated && Input.GetKeyDown(KeyCode.Q) && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            counter++;
        }

        if (EatingFinished == true && gameManager.currentActiveType == "lodówa") {
            dialog.text = "KURDE JUŻ NIC WIĘCEJ NIE DAM RADY ZJEŚĆ";
        }
        else
        if (counter == 1 && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            dialog.text = "*GOTOWAŃSKO GOTOWAŃSKO*";
        }
        else
        if (counter == 2 && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            dialog.text = "A ŻEM SE PIERDYKNOŁ DOBRY OBIADEK";
        }
        else
        if (counter == 3 && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            dialog.text = "*JEDZU JEDZU*";
        }
        else
        if (counter == 4 && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            dialog.text = "DOBRA FAJNIE ZEM SIE NAJADŁ";
        }
        else
        if (counter == 5 && EatingFinished == false && gameManager.currentActiveType == "lodówa") {
            canvas.GetComponent<Canvas>().enabled = false;
            enter = false;
            counter = 0;
            gameManager.currentActiveType = "";
            EatingFinished = true;
            jedzuText.text = "ZJEDZ COŚ ✓";

        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            enter = true;
            gameManager.currentActiveType = "lodówa";
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
