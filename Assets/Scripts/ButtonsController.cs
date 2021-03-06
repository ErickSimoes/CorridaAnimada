﻿using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ButtonsController : MonoBehaviour {

    Pieces piecesSelected;
    public GameObject buttonPrefab;
    public GameObject piecePrefab;
    public Transform piecesGroup;
    public Vector2 pieceReferencePosition;
    [Range(0f, 10f)]
    public float stepY;
    public Transform ReferencePositionGroup;
    public Transform StartReference;
    public Transform EndReference;

    void Start() {
        piecesSelected = GameObject.FindGameObjectWithTag("PiecesSelected").GetComponent<Pieces>();

        for (int i = 0; i < piecesSelected.buttons.Length; i++) {
            GameObject pieceGameObject = Instantiate(piecePrefab, pieceReferencePosition, Quaternion.identity, piecesGroup);
            GameObject buttonGameObject = Instantiate(buttonPrefab, this.transform);

            pieceGameObject.GetComponent<SpriteRenderer>().sprite = piecesSelected.characters[i];

            buttonGameObject.GetComponent<Image>().sprite = piecesSelected.buttons[i];
            buttonGameObject.GetComponent<Image>().type = Image.Type.Simple;
            buttonGameObject.GetComponent<PiecesBehaviour>().piece = pieceGameObject;

            pieceReferencePosition += new Vector2(0, -stepY);
        }

        float xDistance = (EndReference.position.x - StartReference.position.x) / piecesSelected.numQuestion;
        Vector3 objPosition = StartReference.position;
        for (int i = 0; i < piecesSelected.numQuestion; i++) {
            objPosition += new Vector3(xDistance, 0);
            Instantiate(new GameObject(), objPosition, Quaternion.identity, ReferencePositionGroup);
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
