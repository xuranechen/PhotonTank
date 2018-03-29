using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIMgr : MonoBehaviour
{
    GameObject canvas;
    GameObject UIPrefab;
    GameObject tempUI;

    public const string LandUI = "LandUI";
    public const string LoseUI = "LoseUI";
    public const string WinUI = "WinUI";

    public Dictionary<string, GameObject> UIGroup = new Dictionary<string, GameObject>();
    public void Inst()
    {
        UIGroup.Clear();
        canvas = transform.Find("Canvas").gameObject;
        OpenUI(LandUI);
    }
    public void OpenUI(string ui_name)
    {
        if (!UIGroup.ContainsKey(ui_name))
        {
            UIPrefab = Resources.Load(string.Format("{0}{1}", "UI/", ui_name)) as GameObject;
            tempUI = Instantiate(UIPrefab, canvas.transform);
            tempUI.transform.localPosition = Vector3.zero;
            switch (ui_name)
            {
                case LandUI:
                    tempUI.AddComponent<LandUI>();
                    break;
                case LoseUI:
                    tempUI.AddComponent<LoseUI>();
                    break;
                case WinUI:
                    tempUI.AddComponent<WinUI>();
                    break;
                default:
                    break;
            }
            UIGroup.Add(ui_name, tempUI);
        }
        else
        {
            UIGroup[ui_name].transform.localPosition = Vector3.zero;
        }
    }
    public void CloseUI(string ui_name)
    {
        if (UIGroup.ContainsKey(ui_name))
        {
            UIGroup[ui_name].transform.localPosition = new Vector3(0, -1000, 0);
        }
    }
    public void DestoryUI(string ui_name)
    {
        if (UIGroup.ContainsKey(ui_name))
        {
            Destroy(UIGroup[ui_name]);
            UIGroup.Remove(ui_name);
        }
    }
}
