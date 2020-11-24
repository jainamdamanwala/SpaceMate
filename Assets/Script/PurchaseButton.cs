using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PurchaseButton : MonoBehaviour
{
    public enum PurchaseType {removeAds,Diamond1, Diamond2, Diamond5, Diamond15, Diamond30, Diamond70, Diamond150 };
    public PurchaseType purchaseType;

    public void ClickPurchaseButton()
    {
        switch (purchaseType)
        {
            case PurchaseType.removeAds:
                IAPManager.instance.BuyRemoveAds();
                break;
            case PurchaseType.Diamond1:
                IAPManager.instance.Buy1Diamonds();
                break;
            case PurchaseType.Diamond2:
                IAPManager.instance.Buy2Diamonds();
                break;
            case PurchaseType.Diamond5:
                IAPManager.instance.Buy5Diamonds();
                break;
            case PurchaseType.Diamond15:
                IAPManager.instance.Buy15Diamonds();
                break;
            case PurchaseType.Diamond30:
                IAPManager.instance.Buy30Diamonds();
                break;
            case PurchaseType.Diamond70:
                IAPManager.instance.Buy70Diamonds();
                break;
            case PurchaseType.Diamond150:
                IAPManager.instance.Buy150Diamonds();
                break;
        }
    }
}
