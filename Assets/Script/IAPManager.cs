using System;
using UnityEngine;
using UnityEngine.Purchasing;


public class IAPManager : MonoBehaviour, IStoreListener
{
    public static IAPManager instance;
    public GameManager gm;
    public Menu diamonds;
    private static IStoreController m_StoreController;
    private static IExtensionProvider m_StoreExtensionProvider;

    //Step 1 create your products
    private string removeAds = "remove_ads";  
    private string Diamond1 = "diamond_1";
    private string Diamond2 = "diamond_2";
    private string Diamond5 = "diamond_5";
    private string Diamond15 = "diamond_15";
    private string Diamond30 = "diamond_30";    
    private string Diamond70 = "diamond_70";    
    private string Diamond150 = "diamond_150";    


    //************************** Adjust these methods **************************************
    public void InitializePurchasing()
    {
        if (IsInitialized()) { return; }
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //Step 2 choose if your product is a consumable or non consumable
        builder.AddProduct(removeAds, ProductType.NonConsumable);
        builder.AddProduct(Diamond1, ProductType.Consumable);
        builder.AddProduct(Diamond2, ProductType.Consumable);
        builder.AddProduct(Diamond5, ProductType.Consumable);
        builder.AddProduct(Diamond15, ProductType.Consumable);
        builder.AddProduct(Diamond30, ProductType.Consumable);
        builder.AddProduct(Diamond70, ProductType.Consumable);
        builder.AddProduct(Diamond150, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return m_StoreController != null && m_StoreExtensionProvider != null;
    }

    //Step 3 Create methods
    public void BuyRemoveAds()
    {
        BuyProductID(removeAds);
    }

/*    public void Buy10Coins()
    {
        BuyProductID(coin10);
    }    
    public void Buy100Coins()
    {
        BuyProductID(coin100);
    }    
    public void Buy1000Coins()
    {
        BuyProductID(coin1000);
    } */   
    public void Buy1Diamonds()
    {
        BuyProductID(Diamond1);
    }
    public void Buy2Diamonds()
    {
        BuyProductID(Diamond2);
    }
    public void Buy5Diamonds()
    {
        BuyProductID(Diamond5);
    }
    public void Buy15Diamonds()
    {
        BuyProductID(Diamond15);
    }
    public void Buy30Diamonds()
    {
        BuyProductID(Diamond30);
    }
    public void Buy70Diamonds()
    {
        BuyProductID(Diamond70);
    }
    public void Buy150Diamonds()
    {
        BuyProductID(Diamond150);
    }
    /*    public void Buy1Life()
        {
            BuyProductID(Life1);
        }
        public void Buy3Lifes()
        {
            BuyProductID(Life3);
        }
        public void Buy9Lifes()
        {
            BuyProductID(Life9);
        }*/



    //Step 4 modify purchasing
    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (String.Equals(args.purchasedProduct.definition.id, removeAds, StringComparison.Ordinal))
        {
            Debug.Log("RemoveAds Successful");
        }
/*        else if (String.Equals(args.purchasedProduct.definition.id, coin10, StringComparison.Ordinal))
        {
            Debug.Log("10 Coins Added");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin100, StringComparison.Ordinal))
        {
            Debug.Log("100 Coins Added");
        }
        else if (String.Equals(args.purchasedProduct.definition.id, coin1000, StringComparison.Ordinal))
        {
            Debug.Log("1000 Coins Added");
        }*/
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond1, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 1;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond2, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 2;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond5, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 5;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond15, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 15;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond30, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 30;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond70, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 70;
        }
        else if (String.Equals(args.purchasedProduct.definition.id, Diamond150, StringComparison.Ordinal))
        {
            diamonds.diamondsCounter += 150;
        }
        /*        else if (String.Equals(args.purchasedProduct.definition.id, Life1, StringComparison.Ordinal))
                {

                }
                else if (String.Equals(args.purchasedProduct.definition.id, Life3, StringComparison.Ordinal))
                {
                    Debug.Log("3 Lifes Added");
                }
                else if (String.Equals(args.purchasedProduct.definition.id, Life9, StringComparison.Ordinal))
                {
                    Debug.Log("9 Lifes Added");
                }*/
        else
        {
            Debug.Log("Purchase Failed");
        }
        return PurchaseProcessingResult.Complete;
    }










    //**************************** Dont worry about these methods ***********************************
    private void Awake()
    {
        TestSingleton();
    }

    void Start()
    {
        diamonds = FindObjectOfType<Menu>();
        if (m_StoreController == null) { InitializePurchasing(); }
    }

    void Update()
    {
        diamonds = FindObjectOfType<Menu>();
    }
    private void TestSingleton()
    {
        if (instance != null) { Destroy(gameObject); return; }
        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized())
        {
            Product product = m_StoreController.products.WithID(productId);
            if (product != null && product.availableToPurchase)
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product);
            }
            else
            {
                Debug.Log("BuyProductID: FAIL. Not purchasing product, either is not found or is not available for purchase");
            }
        }
        else
        {
            Debug.Log("BuyProductID FAIL. Not initialized.");
        }
    }

    public void RestorePurchases()
    {
        if (!IsInitialized())
        {
            Debug.Log("RestorePurchases FAIL. Not initialized.");
            return;
        }

        if (Application.platform == RuntimePlatform.IPhonePlayer ||
            Application.platform == RuntimePlatform.OSXPlayer)
        {
            Debug.Log("RestorePurchases started ...");

            var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();
            apple.RestoreTransactions((result) => {
                Debug.Log("RestorePurchases continuing: " + result + ". If no further messages, no purchases available to restore.");
            });
        }
        else
        {
            Debug.Log("RestorePurchases FAIL. Not supported on this platform. Current = " + Application.platform);
        }
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("OnInitialized: PASS");
        m_StoreController = controller;
        m_StoreExtensionProvider = extensions;
    }


    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log("OnInitializeFailed InitializationFailureReason:" + error);
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log(string.Format("OnPurchaseFailed: FAIL. Product: '{0}', PurchaseFailureReason: {1}", product.definition.storeSpecificId, failureReason));
    }
}