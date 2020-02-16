﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesBehaviour : MonoBehaviour {
    public RectTransform piece;
    public GameObject pieceReferenceGroup;
    RectTransform[] referencePieces;
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
    }

    void Update() {
        piece.position = Vector2.MoveTowards(piece.position, referencePieces[pieceReference].position, 1f);
    }

    public void MoveToNextPosition() {
        if (referencePieces.Length - 1 > pieceReference) {
            pieceReference++;
        }

        if (pieceReference == referencePieces.Length - 1) {
            VictoryPanel.SetActive(true);
        }
    }

}
