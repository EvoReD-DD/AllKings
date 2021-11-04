using System;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener //для получения сообщений из Unity Purchasing
{
    [SerializeField] private SaveAndLoadData svData;

    IStoreController m_StoreController;

    private string erdcoins5 = "erdcoin5";
    private string erdcoins20 = "erdcoin20";
    private string erdcoins50 = "erdcoin50";
    private string erdcoins100 = "erdcoin100";
    private string erdcoins500 = "erdcoin500";

    void Start()
    {
        InitializePurchasing();
    }

    void InitializePurchasing()
    {
        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        builder.AddProduct(erdcoins5, ProductType.Consumable);
        builder.AddProduct(erdcoins20, ProductType.Consumable);
        builder.AddProduct(erdcoins50, ProductType.Consumable);
        builder.AddProduct(erdcoins100, ProductType.Consumable);
        builder.AddProduct(erdcoins500, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }
    public void BuyProduct(string productName)
    {
        m_StoreController.InitiatePurchase(productName);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        var product = args.purchasedProduct;

        if (product.definition.id == erdcoins5)
        {
            Product_5erdcoins();
        }

        if (product.definition.id == erdcoins20)
        {
            Product_20erdcoins();
        }
        if (product.definition.id == erdcoins50)
        {
            Product_50erdcoins();
        }
        if (product.definition.id == erdcoins100)
        {
            Product_100erdcoins();
        }
        if (product.definition.id == erdcoins500)
        {
            Product_500erdcoins();
        }

        Debug.Log($"Purchase Complete - Product: {product.definition.id}");

        return PurchaseProcessingResult.Complete;
    }

    private void Product_5erdcoins()
    {
        int count = 5;
        SaveData.donateCoins += count;
        SaveAndLoadData.Save();
        svData.Load();
    }

    private void Product_20erdcoins()
    {
        int count = 20;
        SaveData.donateCoins += count;
        SaveAndLoadData.Save();
        svData.Load();
    }
    private void Product_50erdcoins()
    {
        int count = 50;
        SaveData.donateCoins += count;
        SaveAndLoadData.Save();
        svData.Load();
    }

    private void Product_100erdcoins()
    {
        int count = 100;
        SaveData.donateCoins += count;
        SaveAndLoadData.Save();
        svData.Load();
    }
    private void Product_500erdcoins()
    {
        int count = 500;
        SaveData.donateCoins += count;
        SaveAndLoadData.Save();
        svData.Load();
    }

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.Log($"In-App Purchasing initialize failed: {error}");
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.Log($"Purchase failed - Product: '{product.definition.id}', PurchaseFailureReason: {failureReason}");
    }

    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        Debug.Log("In-App Purchasing successfully initialized");
        m_StoreController = controller;
    }


    //public void RestoreMyProduct()
    //{
    //    if (CodelessIAPStoreListener.Instance.StoreController.products.WithID(noads).hasReceipt)
    //    {
    //        Product_NoAds();
    //    }

    //    if (CodelessIAPStoreListener.Instance.StoreController.products.WithID(vip).hasReceipt)
    //    {
    //        Product_VIP();
    //    }
    //}
}