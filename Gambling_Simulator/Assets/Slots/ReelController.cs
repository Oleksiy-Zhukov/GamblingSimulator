using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;

public class ReelController : MonoBehaviour
{
    public Image[] slots;
    public Sprite[] symbols;
    public Text winAmountText;
    public Text balanceText;
    public BetController betController;

    public int playerBalance = 1000;
    public float spinDuration = 2f;

    private List<string> symbolPool = new List<string>();

    void Start()
    {
        balanceText.text = "Balance: $" + playerBalance;
        PopulateSymbolPool();
    }

    private void PopulateSymbolPool()
    {
        symbolPool.Clear();
        AddSymbolsToPool("Cherry", 125);
        AddSymbolsToPool("Lemon", 75);
        AddSymbolsToPool("Watermelon", 50);
        AddSymbolsToPool("Seven", 35);
        AddSymbolsToPool("Crown", 25);
        AddSymbolsToPool("Bar", 15);
        AddSymbolsToPool("Diamond", 10);
    }

    private void AddSymbolsToPool(string symbolName, int odds)
    {
        for (int i = 0; i < odds; i++)
        {
            symbolPool.Add(symbolName);
        }
    }

    public void SpinReels()
    {
        if (CheckOutOfBalance())
        {
            return;
        }

        StartCoroutine(Spin());
    }

    private IEnumerator Spin()
    {
        float timeElapsed = 0f;

        while (timeElapsed < spinDuration)
        {
            for (int i = 0; i < slots.Length; i++)
            {
                string randomSymbol = GetRandomSymbol();
                Sprite symbolSprite = GetSymbolSprite(randomSymbol);
                slots[i].sprite = symbolSprite;
            }
            timeElapsed += Time.deltaTime;
            yield return null;
        }

        FreezeReels();
        CheckForWin();
    }

    private void FreezeReels()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            string randomSymbol = GetRandomSymbol();
            Sprite symbolSprite = GetSymbolSprite(randomSymbol);
            slots[i].sprite = symbolSprite;
        }
    }

    private bool CheckOutOfBalance()
    {
        int currentBet = betController.GetCurrentBet();

        if (playerBalance < currentBet)
        {
            winAmountText.text = "Insufficient balance!";
            return true;
        }

        return false;
    }

    private void CheckForWin()
    {
        int currentBet = betController.GetCurrentBet();
        Dictionary<string, int> symbolCount = CountSymbols();

        int maxCount = 0;
        string winningSymbol = null;

        foreach (var pair in symbolCount)
        {
            if (pair.Value > maxCount)
            {
                maxCount = pair.Value;
                winningSymbol = pair.Key;
            }
        }

        if (maxCount >= 3)
        {
            int baseWin = Mathf.RoundToInt(currentBet * GetSymbolOdds(winningSymbol));
            int winMultiplier = maxCount;
            int totalWin = baseWin * winMultiplier;

            playerBalance += totalWin;
            balanceText.text = "Balance: $" + playerBalance;
            winAmountText.text = "You Win: $" + totalWin + " (x" + winMultiplier + ")";
        }
        else
        {
            playerBalance -= currentBet;
            balanceText.text = "Balance: $" + playerBalance;
            winAmountText.text = "You Lose!";
        }
    }

    private Dictionary<string, int> CountSymbols()
    {
        Dictionary<string, int> symbolCount = new Dictionary<string, int>();

        foreach (var slot in slots)
        {
            string symbolName = slot.sprite.name;

            if (symbolCount.ContainsKey(symbolName))
            {
                symbolCount[symbolName]++;
            }
            else
            {
                symbolCount[symbolName] = 1;
            }
        }

        return symbolCount;
    }

    private string GetRandomSymbol()
    {
        int randomIndex = Random.Range(0, symbolPool.Count);
        return symbolPool[randomIndex];
    }

    private Sprite GetSymbolSprite(string symbolName)
    {
        foreach (var symbol in symbols)
        {
            if (symbol.name == symbolName)
            {
                return symbol;
            }
        }
        return null;
    }

    private float GetSymbolOdds(string symbolName)
    {
        switch (symbolName)
        {
            case "Cherry": return 1.3f;
            case "Lemon": return 1.4f;
            case "Watermelon": return 1.5f;
            case "Seven": return 1.7f;
            case "Crown": return 2f;
            case "Bar": return 3f;
            case "Diamond": return 5f;
            default: return 1f;
        }
    }
}
