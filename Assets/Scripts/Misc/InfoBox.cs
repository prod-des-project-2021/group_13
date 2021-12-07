using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InfoBox : MonoBehaviour
{

    private Text text;
    // Start is called before the first frame update
    void Start()
    {
        text = GetComponent<Text>();
    }

    public void ShowItemInfo(string item, string dsc){
        StartCoroutine(DisplayItem(item, dsc));
    }

    IEnumerator DisplayItem(string item, string dsc){
        text.text = item + " acquired!";
        yield return new WaitForSeconds(2f);
        text.text = dsc;
        yield return new WaitForSeconds(2f);
        text.text = "";
    }

    public void ShowShopError(){
        StartCoroutine(NoMoney());
    }

    IEnumerator NoMoney(){
        text.text = "Not enough coins!";
        text.color = Color.red;
        yield return new WaitForSeconds(2f);
        text.text = "";
        text.color = Color.white;
    }

}
