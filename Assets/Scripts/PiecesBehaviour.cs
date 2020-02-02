using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PiecesBehaviour : MonoBehaviour {
    public RectTransform pieces;
    public RectTransform referencePieces;
    float yDiference = 0;

    void Start() {
        yDiference = pieces.position.y - referencePieces.position.y;
    }

    void Update() {
        Vector2 fixedPosition = new Vector2(referencePieces.position.x, referencePieces.position.y + yDiference);
        pieces.position = Vector2.MoveTowards(pieces.position, fixedPosition, 1f);
    }
}
