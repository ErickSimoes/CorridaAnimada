using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetGroupController : MonoBehaviour {

    public GameObject piecesGroup;
    public int waitTime;
    public Transform[] startTargets;
    Cinemachine.CinemachineTargetGroup targetGroup;

    void Start() {
        targetGroup = GetComponent<Cinemachine.CinemachineTargetGroup>();
        int numPieces = piecesGroup.transform.childCount;
        int radius = 2;
        for (int i = 0; i < numPieces; i++) {
            if (i == numPieces - 1) {
                radius = 10;
            }
            targetGroup.AddMember(piecesGroup.transform.GetChild(i), 1, radius);
        }

        StartCoroutine(RemoveStartTargetMembers(waitTime));
    }

    IEnumerator RemoveStartTargetMembers(int waitTime) {
        yield return new WaitForSeconds(waitTime);
        for (int i = 0; i < startTargets.Length; i++) {
            targetGroup.RemoveMember(startTargets[i].transform);
        }
    }
}
