using UnityEngine;
using UnityEngine.UI;

public class BetController : MonoBehaviour
{
    public Slider betSlider;
    public Text betAmountText;
    private int currentBet;

    void Start()
    {
        currentBet = (int)betSlider.value;
        betAmountText.text = "$" + currentBet;
        betSlider.onValueChanged.AddListener(UpdateBetAmount);
    }

    void UpdateBetAmount(float value)
    {
        currentBet = (int)value;
        betAmountText.text = "$" + currentBet;
    }

    public int GetCurrentBet()
    {
        return currentBet;
    }
}
