using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ReadGoogleSheet : MonoBehaviour
{
    [SerializeField] private string _urlJson =
        "https://script.googleusercontent.com/macros/echo?user_content_key=QE-p8xdfolEsdGB_C4dihaotZ7kzDWkVsRSilE8Q13zAOjWoZXUq4T38YlIpNlKGz8bx4FEeS_V9kVNStj8_nGJikg_NUCQ1m5_BxDlH2jW0nuo2oDemN9CCS2h10ox_1xSncGQajx_ryfhECjZEnHCAWDSdIaYb1FZqgXrUQUpk4SH8jBY2jHWlTiXf9hA5TpGSfQ6ct4SDZ2oXoghobaSOyZyuZN2-bcvQbMv3K0TacrY_wOGqBA&lib=MgJZQ3qnPVskaQJFdmS7pddiHJHGnRMgN";

    [SerializeField] private TextMeshProUGUI _textResult; 
    private void Start() => StartCoroutine(GetData());

    private IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(_urlJson);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
        {
            string jsonResult = request.downloadHandler.text;
            ItemsData dataItems = JsonUtility.FromJson<ItemsData>(jsonResult);
            PrintResult(dataItems);
            Debug.Log(jsonResult);
        }
        else
            Debug.LogError("Error: " + request.error);
    }

    private void PrintResult(ItemsData dataItems)
    {
        _textResult.text = ""; 
        
        foreach (var item in dataItems.items)
            _textResult.text += $"Name: {item.Name} | Quantity: {item.Quantity} | Price: {item.Price} \n";
    }
}
