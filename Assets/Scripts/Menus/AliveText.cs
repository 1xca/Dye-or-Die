using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AliveText : MonoBehaviour
{
    public TextMeshProUGUI text;
    void Update()
    {
        text.text = "Amount: " + CharacterManager.Instance.Amount + " Alive: " + (CharacterManager.Instance.charactersAlive + CharacterManager.Instance.finishedCharacters);
    }
}
