using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum UIPanelType
{
    MenuUI,
    GameUI,
    PausedUI,
    WinUI,
    LoseUI
}
public class UIManager : SingletonManager<UIManager>
{
    // Start is called before the first frame update
    [SerializeField] private Canvas mainCanvas;
    private Dictionary<UIPanelType, GameObject> uiPanels;
    protected override void Awake()
    {
        uiPanels = new Dictionary<UIPanelType, GameObject>();
    }
    private GameObject GetUIPanel(UIPanelType type)
    {
        //check ui exist on uiPanels    
        if(!uiPanels.TryGetValue(type,out GameObject uiPanel))
        {
            string path = $"UI/{type.ToString()}";
            uiPanel = Instantiate(Resources.Load<GameObject>(path),mainCanvas.transform);
            uiPanel.SetActive(false);
            uiPanels[type] = uiPanel;
        }
        return uiPanel;
    }
    public void ShowUI(UIPanelType type)
    {
        HideAllPanel();
        GameObject uiPanel = GetUIPanel(type);
        uiPanel.SetActive(true);
    }
    private void HideAllPanel()
    {
        foreach(var ui in uiPanels.Values)
        {
            ui.SetActive(false);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
