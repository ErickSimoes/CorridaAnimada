using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesBehaviour : MonoBehaviour {
    public RectTransform piece;
    public RectTransform[] referencePieces;
    int pieceReference = 0;

    void Start() {
        
    }

    void Update() {
        piece.position = Vector2.MoveTowards(piece.position, referencePieces[pieceReference].position, 1f);
    }

    public void MoveToNextPosition() {
        if (referencePieces.Length - 1 > pieceReference) {
            pieceReference++;
        }
        
    }

}
