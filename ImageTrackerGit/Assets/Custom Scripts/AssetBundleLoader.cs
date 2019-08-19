using System.Collections;
using UnityEngine.Networking;
using UnityEngine;

public class AssetBundleLoader : MonoBehaviour
{

    public string[] urls;
    public string[] assetNames;

    private Transform parent;
    private GameObject parentGameObject;

    // Start is called before the first frame update
    void Start()
    {
        parentGameObject = GameObject.Find("ControllerObject");
        if (parentGameObject != null)
        {
            Debug.Log("Got Parent GameObject: " + parentGameObject.name);
            parent = parentGameObject.transform;
        }
        StartCoroutine(GetAssetBundle());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator GetAssetBundle()
    {
        Debug.Log("Download Started...");

        float maxProgress = urls.Length;
        float progress = 0;
        for (int i=0; i<urls.Length; i++)
        {
            UnityWebRequest www = UnityWebRequestAssetBundle.GetAssetBundle(urls[i]);
            yield return www.SendWebRequest();

            if (www.isNetworkError || www.isHttpError)
            {
                Debug.Log(www.error);
            }
            else
            {
                AssetBundle bundle = DownloadHandlerAssetBundle.GetContent(www);
                //To remember the last progress
                float lastProgress = progress;
                while (!www.isDone)
                {
                    //Calculate the current progress
                    progress = lastProgress + www.downloadProgress;
                    //Get a percentage
                    float progressPercentage = (progress / maxProgress) * 100;
                    Debug.Log("Progress: " + progressPercentage + "%");
                }
                Debug.Log("Download Completed.");
                GameObject model = bundle.LoadAsset<GameObject>(assetNames[i]);
                model.SetActive(false);
                Instantiate(model, parent);            
            }
        }
        parent.SendMessage("populateModelsArray", parent);
    }
}
