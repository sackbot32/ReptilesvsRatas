using TMPro;
using UnityEngine;

public class CurrencyManager : MonoBehaviour
{

    public static CurrencyManager instance;
    public int startingCurrency;
    public int currency;
    public TMP_Text currencyText;
    void Start()
    {
        instance = this;
        currency = startingCurrency;
        currencyText.text = currency.ToString("000");
    }

    
    public void ChangeCurrency(int addedCurrency)
    {
        currency += addedCurrency;

        currencyText.text = currency.ToString("000");
    }
}
