using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class BedEnterDialog : MonoBehaviour
{
    public GameManager gameManager;
    public EatingEnterDialog eatingEnterDialog;
    public ShowerEnterDialog showerEnterDialog;
    public GameObject player;
    public GameObject canvas;
    public GameObject chop;
    bool enter = false;
    bool activated;
    int counter;

    Text dialog;
    LevelTransition levelTransition;


    void Start() {
        levelTransition = FindObjectOfType<LevelTransition>();
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = false;

        gameManager = FindObjectOfType<GameManager>();
        eatingEnterDialog = FindObjectOfType<EatingEnterDialog>();
        showerEnterDialog = FindObjectOfType<ShowerEnterDialog>();
    }

    void Update() {

        if (Input.GetKeyDown(KeyCode.E) && enter == true && gameManager.currentActiveType == "lozko") {
            canvas.GetComponent<Canvas>().enabled = true;
            chop.GetComponent<Image>().enabled = true;
            counter = 1;
            activated = true;
        }

        
        if (activated && Input.GetKeyDown(KeyCode.Q)  && gameManager.currentActiveType == "lozko") {
            counter++;
            Debug.Log(counter);
        }

        if (showerEnterDialog.ShowerFinished == true && eatingEnterDialog.EatingFinished == true && gameManager.currentActiveType == "lozko") {
            dialog.text = "NO TO SPAŃSKO";
            StartCoroutine(LoadNextLevel());
        }
        
        else
        if (showerEnterDialog.ShowerFinished == false && eatingEnterDialog.EatingFinished == true && gameManager.currentActiveType == "lozko") {
            dialog.text = "ALE TAK BRUDNY IŚĆ SPAĆ";
        }
        else
        if (showerEnterDialog.ShowerFinished == true && eatingEnterDialog.EatingFinished == false && gameManager.currentActiveType == "lozko") {
            dialog.text = "NIE NALEŻY IŚĆ SPAĆ GŁODNY";
        }
        else
        if (showerEnterDialog.ShowerFinished == false && eatingEnterDialog.EatingFinished == false && gameManager.currentActiveType == "lozko") {
            dialog.text = "BRUDNY I GŁODNY SIĘ NIE WYŚPIĘ";
        }
    }

    IEnumerator LoadNextLevel()
    {
        yield return new WaitForSeconds(2);
        levelTransition.FadeToLevel("Level1");
        // SceneManager.LoadScene("Level1");
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            enter = true;
            gameManager.currentActiveType = "lozko";
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
