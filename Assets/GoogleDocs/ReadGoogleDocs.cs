using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.Networking;

public class ReadGoogleDocs : MonoBehaviour
{
    [SerializeField] private string _url;
    [SerializeField] private string _keyStarMassage = "!Start!";
    [SerializeField] private string _keyEndMassage = "!End!";

    [SerializeField] private TextMeshProUGUI _textResult;

    private void Start()
    {
        StartCoroutine(GetData()); 
    }

    private IEnumerator GetData()
    {
        UnityWebRequest request = UnityWebRequest.Get(_url);
        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.Success)
            PrintResult(request.downloadHandler.text);
        else
        {
            Debug.LogError("Error: " + request.error);
        }
    }

    private void PrintResult(string request)
    {
        int startIndex = request.IndexOf(_keyStarMassage) + _keyStarMassage.Length;
        int endIndex = request.IndexOf(_keyEndMassage);

        string result = request.Substring(startIndex, endIndex - startIndex); 
        
        _textResult.text = result;
        Debug.Log(result);
    }
}
