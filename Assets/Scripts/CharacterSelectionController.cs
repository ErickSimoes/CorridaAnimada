using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour {

    Toggle[] toggles;
    public Button startButton;
    public GameObject piecesSelected;
    public int maxPiecesSelected;

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

        toggles = new Toggle[transform.childCount];
        for (int i = 0; i < transform.childCount; i++) {
            toggles[i] = transform.GetChild(i).gameObject.GetComponent<Toggle>();
        }

        FillCharacters();
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
        } else {
            startButton.interactable = false;
        }

        if (numToggleOn > maxPiecesSelected) {
            myToggle.isOn = false;
        }
    }

    private void FillCharacters() {
        Pieces pieces = GameObject.FindGameObjectWithTag("Pieces").GetComponent<Pieces>();
        
        for (int i = 0; i < toggles.Length; i++) {
            toggles[i].GetComponent<PieceChoice>().sprites = new Sprite[1, 2] { { pieces.buttons[i], pieces.characters[i] } };
            toggles[i].gameObject.GetComponentInChildren<Image>().sprite = pieces.buttons[i];
        }
    }

    public void StartGame() {

        List<Sprite> buttons = new List<Sprite>();
        List<Sprite> characters = new List<Sprite>();

        foreach (Toggle toggle in toggles) {
            if (toggle.isOn) {
                PieceChoice pieceChoice = toggle.GetComponent<PieceChoice>();
                buttons.Add(pieceChoice.sprites[0,0]);
                characters.Add(pieceChoice.sprites[0, 1]);
            }
        }

        Pieces pieces = piecesSelected.GetComponent<Pieces>();
        pieces.buttons = buttons.ToArray();
        pieces.characters = characters.ToArray();

        SceneManager.LoadScene("MainScene");
    }
}
