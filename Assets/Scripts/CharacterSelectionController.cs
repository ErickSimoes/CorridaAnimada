using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour {

    Toggle[] toggles;
    public Button startButton;
    public GameObject piecesSelected;
    public int maxPiecesSelected;
    public InputField inputNQuestions;
    public AudioSource clickSound;
    public AudioClip click, error;

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
            clickSound.clip = error;
        } else {
            clickSound.clip = click;
        }
    }

    private void FillCharacters() {
        Pieces pieces = GameObject.FindGameObjectWithTag("Pieces").GetComponent<Pieces>();

        for (int i = 0; i < toggles.Length; i++) {
            PieceChoice pieceChoice = toggles[i].GetComponent<PieceChoice>();
            pieceChoice.button = pieces.buttons[i];
            pieceChoice.character = pieces.characters[i];
            toggles[i].gameObject.GetComponentInChildren<Image>().sprite = pieces.buttons[i];
        }
    }

    public void StartGame() {

        List<Sprite> buttons = new List<Sprite>();
        List<Sprite> characters = new List<Sprite>();

        foreach (Toggle toggle in toggles) {
            if (toggle.isOn) {
                PieceChoice pieceChoice = toggle.GetComponent<PieceChoice>();
                buttons.Add(pieceChoice.button);
                characters.Add(pieceChoice.character);
            }
        }

        Pieces pieces = piecesSelected.GetComponent<Pieces>();
        pieces.buttons = buttons.ToArray();
        pieces.characters = characters.ToArray();

        pieces.numQuestion = int.Parse(inputNQuestions.text);

        SceneManager.LoadScene("MainScene");
    }
}
