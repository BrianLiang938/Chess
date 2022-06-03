using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlate : MonoBehaviour
{
    public GameObject controller;
    //piece to be interacted with
    GameObject reference = null;

    //board rep
    int matrixX;
    int matrixY;

    //false: movement, true: attacking, i.e pawn attacking diagonally
    public bool attack = false;

    public void Start() {
        if (attack) {
            gameObject.GetComponent<SpriteRenderer>().color = new Color(1.0f, 0.0f, 0.0f, 1.0f);
        }
    }

    public void OnMouseUp() {
        controller = GameObject.FindGameObjectWithTag("GameController");
        if (attack) {
            GameObject cp = controller.GetComponent<Game>().GetPosition(matrixX, matrixY);
            Destroy(cp);
        }

        controller.GetComponent<Game>().SetPositionEmpty(reference.GetComponent<Piece>().GetXBoard(), reference.GetComponent<Piece>().GetYBoard());

        reference.GetComponent<Piece>().SetXBoard(matrixX);
        reference.GetComponent<Piece>().SetYBoard(matrixY);
        reference.GetComponent<Piece>().SetCoords();

        controller.GetComponent<Game>().SetPosition(reference);
        reference.GetComponent<Piece>().DestroyMovePlates();
    }

    public void SetCoords(int x, int y) {
        matrixX = x;
        matrixY = y;
    }

    public void SetReference(GameObject obj) {
        reference = obj;
    }

    public GameObject GetReference() {
        return reference;
    }
}
