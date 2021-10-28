using System;
using UnityEngine;
using UnityEngine.Purchasing; //���������� � ���������, ����� �������� ����� ���������� �������

public class IAPCore : MonoBehaviour, IStoreListener //��� ��������� ��������� �� Unity Purchasing
{
    [SerializeField] private SaveAndLoadData svData;
    private static IStoreController m_StoreController;          //������ � ������� Unity Purchasing
    private static IExtensionProvider m_StoreExtensionProvider; // ���������� ������� ��� ���������� ���������

    public static string erdcoins5 = "5erdcoins";
    public static string erdcoins20 = "20erdcoins";
    public static string erdcoins50 = "50erdcoins";
    public static string erdcoins100 = "100erdcoins";
    public static string erdcoins500 = "500erdcoins";

    void Start()
    {
        if (m_StoreController == null) //���� ��� �� ���������������� ������� Unity Purchasing, ����� ��������������
        {
            InitializePurchasing();
        }
    }

    public void InitializePurchasing()
    {
        if (IsInitialized()) //���� ��� ���������� � ������� - ������� �� �������
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        //����������� ���� ������ ��� ���������� � ������
        builder.AddProduct(erdcoins5, ProductType.Consumable);
        builder.AddProduct(erdcoins20, ProductType.Consumable);
        builder.AddProduct(erdcoins50, ProductType.Consumable);
        builder.AddProduct(erdcoins100, ProductType.Consumable);
        builder.AddProduct(erdcoins500, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    public void Buy_5erdcoins()
    {
        BuyProductID(erdcoins5);
    }
    public void Buy_20erdcoins()
    {
        BuyProductID(erdcoins20);
    }
    public void Buy_50erdcoins()
    {
        BuyProductID(erdcoins50);
    }
    public void Buy_100erdcoins()
    {
        BuyProductID(erdcoins100);
    }
    public void Buy_500erdcoins()
    {
        BuyProductID(erdcoins500);
    }

    void BuyProductID(string productId)
    {
        if (IsInitialized()) //���� ������� ���������������� 
        {
            Product product = m_StoreController.products.WithID(productId); //������� ������� ������� 

            if (product != null && product.availableToPurchase) //���� ������� ������ � ����� ��� �������
            {
                Debug.Log(string.Format("Purchasing product asychronously: '{0}'", product.definition.id));
                m_StoreController.InitiatePurchase(product); //��������
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

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args) //�������� �������
    {
        if (String.Equals(args.purchasedProduct.definition.id, erdcoins5, StringComparison.Ordinal))
        {
            int count = 5;
            SaveData.donateCoins += count;
            SaveAndLoadData.Save();
            svData.Load();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, erdcoins20, StringComparison.Ordinal))
        {
            int count = 20;
            SaveData.donateCoins += count;
            SaveAndLoadData.Save();
            svData.Load();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, erdcoins50, StringComparison.Ordinal))
        {
            int count = 50;
            SaveData.donateCoins += count;
            SaveAndLoadData.Save();
            svData.Load();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, erdcoins100, StringComparison.Ordinal))
        {
            int count = 100;
            SaveData.donateCoins += count;
            SaveAndLoadData.Save();
            svData.Load();
        }
        else if (String.Equals(args.purchasedProduct.definition.id, erdcoins500, StringComparison.Ordinal))
        {
            int count = 500;
            SaveData.donateCoins += count;
            SaveAndLoadData.Save();
            svData.Load();
        }
        else
        {
            Debug.Log(string.Format("ProcessPurchase: FAIL. Unrecognized product: '{0}'", args.purchasedProduct.definition.id));
        }
            return PurchaseProcessingResult.Complete;
        }

        public void RestorePurchases() //�������������� ������� (������ ��� Apple). � ���� ��� �������������� �������.
        {
            if (!IsInitialized())
            {
                Debug.Log("RestorePurchases FAIL. Not initialized.");
                return;
            }

            if (Application.platform == RuntimePlatform.IPhonePlayer ||
                Application.platform == RuntimePlatform.OSXPlayer) //���� ��������� �� ��� ����������
            {
                Debug.Log("RestorePurchases started ...");

                var apple = m_StoreExtensionProvider.GetExtension<IAppleExtensions>();

                apple.RestoreTransactions((result) =>
                {
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

        private bool IsInitialized()
        {
            return m_StoreController != null && m_StoreExtensionProvider != null;
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
