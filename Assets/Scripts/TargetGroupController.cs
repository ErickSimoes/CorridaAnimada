using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupController : MonoBehaviour {

    public GameObject piecesGroup;

    void Start() {
        Cinemachine.CinemachineTargetGroup targetGroup = GetComponent<Cinemachine.CinemachineTargetGroup>();
        int numPieces = piecesGroup.transform.childCount;
        int radius = 2;
        for (int i = 0; i < numPieces; i++) {
            if (i == numPieces - 1) {
                radius = 10;
            }
            targetGroup.AddMember(piecesGroup.transform.GetChild(i), 1, radius);
        }

    }
}
