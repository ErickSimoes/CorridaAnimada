using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesBehaviour : MonoBehaviour {
    public RectTransform piece;
    public GameObject pieceReferenceGroup;
    RectTransform[] referencePieces;
    public float movimenteDuration = 1f;
    Vector3 targetPosition;
    Vector3 yFixPosition;
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

        yFixPosition = new Vector3(0, piece.position.y - referencePieces[0].position.y, 0);
    }
    public void MoveToNextPosition() {
        if (referencePieces.Length - 1 > pieceReference) {
            targetPosition = referencePieces[pieceReference++].position + yFixPosition;
        }

        //TODO: Active this panel only in the end of movimentation
        if (pieceReference == referencePieces.Length - 1) {
            VictoryPanel.SetActive(true);
        }

        StartCoroutine(MovePiece(targetPosition));
    }
    IEnumerator MovePiece(Vector3 target) {
        while (piece.position != target) {
            piece.position = Vector3.MoveTowards(piece.position, target, movimenteDuration);
            yield return null;
        }
    }

}
