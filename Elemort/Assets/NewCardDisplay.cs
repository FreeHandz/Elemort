using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewCardDisplay : MonoBehaviour {

    public CardDisplay cardDisplay;

    public void Show(Card card)
    {
        cardDisplay.card = card;
        cardDisplay.GetComponent<DragAndDropItem>().enabled = false;
        cardDisplay.RenderCard();
        gameObject.SetActive(true);
        Time.timeScale = 0;
    }

    public void Hide()
    {
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
