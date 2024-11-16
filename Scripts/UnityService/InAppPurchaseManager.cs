using UnityEngine;
using UnityEngine.Purchasing;
using UnityEngine.UI;

public class IAPManager : MonoBehaviour, IStoreListener
{
    private static IStoreController storeController;
    private static IExtensionProvider storeExtensionProvider;
    public Button gemPack1Button;
    public string productID = "coins_50"; // Replace with your product ID.

    private void Start()
    {
        if (storeController == null)
        {
            InitializePurchasing();
        }
        gemPack1Button.onClick.AddListener(BuyProduct);
    }

    public void InitializePurchasing()
    {
        if (IsInitialized())
        {
            return;
        }

        var builder = ConfigurationBuilder.Instance(StandardPurchasingModule.Instance());

        // Add your product here
        builder.AddProduct(productID, ProductType.Consumable);

        UnityPurchasing.Initialize(this, builder);
    }

    private bool IsInitialized()
    {
        return storeController != null && storeExtensionProvider != null;
    }
    public void OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        storeController = controller;
        storeExtensionProvider = extensions;
        Debug.Log("IAP Initialized");
    }
    public void BuyProduct()
    {
        if (IsInitialized())
        {
            Product product = storeController.products.WithID(productID);

            if (product != null && product.availableToPurchase)
            {
                storeController.InitiatePurchase(product);
            }
            else
            {
                Debug.LogError("BuyProduct: Product not found or not available for purchase.");
            }
        }
        else
        {
            Debug.LogError("BuyProduct: Not initialized.");
        }
    }

    

    public void OnInitializeFailed(InitializationFailureReason error)
    {
        Debug.LogError("IAP Initialization Failed: " + error);
    }

    public PurchaseProcessingResult ProcessPurchase(PurchaseEventArgs args)
    {
        if (args.purchasedProduct.definition.id == productID)
        {
            Debug.Log("Purchase Successful! Adding 50 to the player's value.");
            // Update the player's value here
            //StaticData.SavePurchaseGemPack1 = true;
            Debug.Log("Completed purchases");
           // PlayerPrefs.SetInt("PlayerValue", PlayerPrefs.GetInt("PlayerValue", 0) + 50);
        }
        else
        {
            Debug.LogWarning("Purchase Failed: Unrecognized product.");
        }

        return PurchaseProcessingResult.Complete;
    }

    public void OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        Debug.LogError($"Purchase Failed: {product.definition.id}, Reason: {failureReason}");
    }

    void IStoreListener.OnInitializeFailed(InitializationFailureReason error)
    {
        throw new System.NotImplementedException();
    }

    void IStoreListener.OnInitializeFailed(InitializationFailureReason error, string message)
    {
        throw new System.NotImplementedException();
    }

    PurchaseProcessingResult IStoreListener.ProcessPurchase(PurchaseEventArgs purchaseEvent)
    {
        throw new System.NotImplementedException();
    }

    void IStoreListener.OnPurchaseFailed(Product product, PurchaseFailureReason failureReason)
    {
        throw new System.NotImplementedException();
    }

    void IStoreListener.OnInitialized(IStoreController controller, IExtensionProvider extensions)
    {
        throw new System.NotImplementedException();
    }
}
