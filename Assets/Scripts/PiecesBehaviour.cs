using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesBehaviour : MonoBehaviour {
    public RectTransform piece;
    public GameObject pieceReferenceGroup;
    RectTransform[] referencePieces;
    //TODO: Rename position to target
    Vector3 position;
    Vector3 positionReference;
    static GameObject VictoryPanel;
    int pieceReference = 0;

    void Start() {
        int numPieces = pieceReferenceGroup.transform.childCount;
        referencePieces = new RectTransform[numPieces];

        for (int i = 0; i < numPieces; i++) {
            referencePieces.SetValue(pieceReferenceGroup.transform.GetChild(i), i);
        }

        if (!VictoryPanel) {
            VictoryPanel = GameObject.FindGameObjectWithTag("VictoryPanel");
            VictoryPanel.SetActive(false);
        }

        //position = piece.position;
        float yReference = piece.position.y - referencePieces[0].position.y;
        positionReference = new Vector3(0, yReference, 0);
        print(yReference);
    }
    public void MoveToNextPosition() {
        if (referencePieces.Length - 1 > pieceReference) {
            position = referencePieces[pieceReference++].position + positionReference;
        }

        //TODO: Active this panel only in the end of movimentation
        if (pieceReference == referencePieces.Length - 1) {
            VictoryPanel.SetActive(true);
        }

        StartCoroutine(MovePiece(position));
    }
    IEnumerator MovePiece(Vector3 target) {
        while (piece.position != target) {
            //TODO: Move time needs be public
            piece.position = Vector3.MoveTowards(piece.position, target, 1f);
            yield return null;
        }
    }

}
