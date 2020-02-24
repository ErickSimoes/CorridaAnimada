using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class CharacterSelectionController : MonoBehaviour {

    Toggle[] toggles;
    public Button startButton;
    public GameObject PiecesSelected;

    void Start() {

        DontDestroyOnLoad(PiecesSelected);

        int numChilds = transform.childCount;
        print(numChilds);

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

        Pieces pieces = PiecesSelected.GetComponent<Pieces>();
        pieces.sprites = sprites;

        SceneManager.LoadScene("MainScene");
    }
}
