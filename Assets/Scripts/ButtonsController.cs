using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour {

    Pieces piecesSelected;
    public GameObject buttonPrefab;
    public GameObject piecePrefab;
    public GameObject piecesGroup;
    public Vector2 pieceReferencePosition;

    void Start() {
        piecesSelected = GameObject.FindGameObjectWithTag("PiecesSelected").GetComponent<Pieces>();

        for (int i = 0; i < piecesSelected.buttons.Length; i++) {
            GameObject pieceGameObject = Instantiate(piecePrefab, pieceReferencePosition, Quaternion.identity, piecesGroup.transform);
            GameObject buttonGameObject = Instantiate(buttonPrefab, this.transform);

            pieceGameObject.GetComponent<SpriteRenderer>().sprite = piecesSelected.characters[i];
            
            buttonGameObject.GetComponent<Image>().sprite = piecesSelected.buttons[i];
            buttonGameObject.GetComponent<Image>().type = Image.Type.Simple;
            buttonGameObject.GetComponent<PiecesBehaviour>().piece = pieceGameObject;
            
            pieceReferencePosition += new Vector2(0, -4.5f);
        }

    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            BackToSelectionScene();
        }
    }

    public void BackToSelectionScene() {
        SceneManager.LoadScene("CharacterSelection");
    }
}
