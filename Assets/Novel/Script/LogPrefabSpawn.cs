using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogPrefabSpawn : MonoBehaviour
{
    [SerializeField]
    GameObject logPrefab;
    [SerializeField]
    GameObject parent;

    LogComponent logComponent;

    int count;
    // Start is called before the first frame update
    void Start()
    {
        count = 0;
    }

    public void SpawnLog(string name, string sentence)
    {
        GameObject log;

        var rectTransform = parent.GetComponent<RectTransform>();
        var height = rectTransform.sizeDelta.y;

        if(count >= 2)
        {
            height += 300;
            parent.GetComponent<VerticalLayoutGroup>().enabled = true;
            parent.GetComponent<RectTransform>().SetSizeWithCurrentAnchors(RectTransform.Axis.Vertical,height);
        }

        log = Instantiate(logPrefab, new Vector3(1230, 870 - (count * 300), 0), Quaternion.identity);
        log.transform.SetParent(parent.transform, true);

        logComponent = log.GetComponentInChildren<LogComponent>();
        logComponent.SetName(name);
        logComponent.SetDialogue(sentence);

        count++;
    }
}
