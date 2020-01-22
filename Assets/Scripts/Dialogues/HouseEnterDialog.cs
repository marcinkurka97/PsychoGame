using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HouseEnterDialog : MonoBehaviour
{

    public GameObject player;
    public GameObject canvas;
    public GameObject chop;
    public GameObject HouseEnterTrigger;
    bool enter = false;
    bool activated;
    int counter;

    Text dialog;


    void Start() {
        enter = false;
        // canvas.GetComponent<Canvas>().enabled = false;
        counter = 0;
        dialog = GameObject.Find("Text").GetComponent<Text>();

        activated = false;
    }

    void Update() {
        if (activated && Input.GetKeyDown(KeyCode.Q)) {
            counter++;
        }

        if (counter == 1) {
            dialog.text = "NO I FAJNO W KOŃCU W DOMCIU";
        }
        else
        if (counter == 2) {
            dialog.text = "ALE JESTEM GŁODNY";
        }
        else
        if (counter == 3) {
            dialog.text = "PRZTDAŁA BY SIĘ JAKAŚ KOLACJA ,A PÓŻNIEJ PRYSZNIC";
        }
        else
        if (counter == 4) {
            dialog.text = "WSZYSTKO PO KOLEI A POTEM DO SPAŃSKA";
        }
        else
        if (counter == 5) {
            dialog.text = "BO JUTRO ZNOWU DO PRACY Z FRAJERAMI Z WOLNOŚCI SIĘ UŻERAĆ";
        }
        else
        if (counter == 6) {
            HouseEnterTrigger.SetActive(false);
        }
    }

    void OnTriggerEnter2D(Collider2D other) {
        if (other.tag == "Player") {
            enter = true;
            canvas.GetComponent<Canvas>().enabled = true;
            chop.GetComponent<Image>().enabled = true;
            counter = 1;
            activated = true;
        }
    }

    void OnTriggerExit2D(Collider2D other) {
        if (other.tag == "Player") {
            canvas.GetComponent<Canvas>().enabled = false;
            enter = false;
            counter = 0;
        }
    }
}
