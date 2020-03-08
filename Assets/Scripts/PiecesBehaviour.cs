using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PiecesBehaviour : MonoBehaviour {
    public GameObject piece;
    static GameObject ReferencePositionGroup;
    static GameObject[] referencePosition;
    public float movimenteDuration = 1f;
    Vector3 targetPosition;
    Vector3 yFixPosition;
    static GameObject VictoryPanel;
    int pieceReference = 0;
    Coroutine previousCoroutine;

    void Start() {
        if (!ReferencePositionGroup) {
            ReferencePositionGroup = GameObject.FindGameObjectWithTag("ReferencePosition");
        }

        int numPieces = ReferencePositionGroup.transform.childCount;
        referencePosition = new GameObject[numPieces];
        for (int i = 0; i < numPieces; i++) {
            referencePosition.SetValue(ReferencePositionGroup.transform.GetChild(i).gameObject, i);
        }

        if (!VictoryPanel) {
            VictoryPanel = GameObject.FindGameObjectWithTag("VictoryPanel");
            VictoryPanel.SetActive(false);
        }

        yFixPosition = new Vector3(0, piece.transform.position.y - referencePosition[0].transform.position.y, 0);
    }

    public void MoveToNextPosition() {
        if (referencePosition.Length > pieceReference) {
            targetPosition = referencePosition[pieceReference++].transform.position + yFixPosition;
        }

        if (previousCoroutine != null) {
            StopCoroutine(previousCoroutine);
        }

        previousCoroutine = StartCoroutine(MovePiece(targetPosition));
    }

    IEnumerator MovePiece(Vector3 target) {
        while (piece.transform.position != target) {
            piece.transform.position = Vector3.MoveTowards(piece.transform.position, target, movimenteDuration * Time.deltaTime);
            yield return null;
        }

        if (pieceReference >= referencePosition.Length) {
            VictoryPanel.SetActive(true);
        }
    }

}
