using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour {

    Toggle[] toggles;
    public Button startButton;
    public GameObject piecesSelected;

    void Start() {

        GameObject[] piecesSelecteds = GameObject.FindGameObjectsWithTag("PiecesSelected");
        if (piecesSelecteds.Length > 1) {
            if (piecesSelected == piecesSelecteds[0]) {
                Destroy(piecesSelecteds[1]);
            } else {
                Destroy(piecesSelecteds[0]);
            }
        }

        DontDestroyOnLoad(piecesSelected);

        int numChilds = transform.childCount;

        toggles = new Toggle[numChilds];

        for (int i = 0; i < numChilds; i++) {
            toggles[i] = transform.GetChild(i).gameObject.GetComponent<Toggle>();
        }
        FillCharacters();
    }

    void Update() {

    }

    public void ChechTogglesActiveis(Toggle myToggle) {
        int numToggleOn = 0;

        foreach (Toggle toggle in toggles) {
            if (toggle.isOn) {
                numToggleOn++;
            }
        }

        if (numToggleOn >= 2) {
            startButton.interactable = true;
        }

        if (numToggleOn > 4) {
            myToggle.isOn = false;
        }
    }

    private void FillCharacters() {
        Pieces pieces = GameObject.FindGameObjectWithTag("Pieces").GetComponent<Pieces>();
        
        for (int i = 0; i < toggles.Length; i++) {
            toggles[i].gameObject.GetComponentInChildren<Image>().sprite = pieces.sprites[i];
        }
    }

    public void StartGame() {

        List<Sprite> sprites = new List<Sprite>();

        foreach (Toggle toggle in toggles) {
            if (toggle.isOn) {
                sprites.Add(toggle.gameObject.GetComponentInChildren<Image>().sprite);
            }
        }

        Pieces pieces = piecesSelected.GetComponent<Pieces>();
        pieces.sprites = sprites;

        SceneManager.LoadScene("MainScene");
    }
}
