using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AliveText : MonoBehaviour
{
    public TextMeshProUGUI ballCountText;
    public TextMeshProUGUI timeCountText;
    void Update()
    {
        ballCountText.text = "BALLS:     " + (CharacterManager.Instance.charactersAlive + CharacterManager.Instance.finishedCharacters);
        timeCountText.text = "TIME  00:30s" ; //TODO Add Timer
    }
}
