using UnityEngine;
using UnityEngine.UI;

public class best_score_ui : MonoBehaviour
{
    [SerializeField] GameObject obj;
    [SerializeField] Transform parent;
    void Start()
    {
        SaveS.Load();
        int num = 1;
        foreach (int a in StaticValues.time) {
            var created = Instantiate(obj);
            created.transform.SetParent(parent);
            created.transform.GetChild(0).GetComponent<Text>().text = num.ToString();
            created.transform.GetChild(1).GetComponent<Text>().text =   a.ToString();
            created.transform.localScale = new Vector3(1,1,1);
            num++;
        }
    }
}
