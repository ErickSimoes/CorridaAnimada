using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillPieces : MonoBehaviour {

    Sprite[] spriteSelected;
    public GameObject piecesSelected;

    void Start() {

        /*piecesSelected = GameObject.FindGameObjectWithTag("PiecesSelected");

        spriteSelected = piecesSelected.gameObject.GetComponent<Pieces>().characters;

        for (int i = 0; i < spriteSelected.Length; i++) {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = spriteSelected[i];
        }*/
    }

    public void BackToSelectionScene() {
        SceneManager.LoadScene("CharacterSelection");
    }
}
