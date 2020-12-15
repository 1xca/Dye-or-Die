using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AliveText : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;
    void Update()
    {
        ballCountText.text = "BALLS:     " + (CharacterManager.Instance.charactersAlive + CharacterManager.Instance.finishedCharacters);
    }
}
