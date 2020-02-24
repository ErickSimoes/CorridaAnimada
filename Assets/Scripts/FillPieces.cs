using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FillPieces : MonoBehaviour {

    public Sprite[] sprites;
    Sprite[] spriteSelected;
    public GameObject piecesSelected;

    void Start() {

        piecesSelected = GameObject.FindGameObjectWithTag("PiecesSelected");

        spriteSelected = piecesSelected.gameObject.GetComponent<Pieces>().sprites.ToArray();

        sprites = new Sprite[spriteSelected.Length];
        for (int i = 0; i < spriteSelected.Length; i++) {
            transform.GetChild(i).gameObject.GetComponent<SpriteRenderer>().sprite = spriteSelected[i];
        }
    }

    public void BackToSelectionScene() {
        SceneManager.LoadScene("CharacterSelection");
    }
}
