using UnityEngine;
using UnityEngine.UI;


public class NodeUI : MonoBehaviour
{
    public GameObject ui;
    public Text upgradeCost;
    public Button upgrsdeButton;
    public Text sellAmount;
    private Node target;


    public void setTarget(Node _target)
    {
        target = _target;

        transform.position = target.GetbuildPosition();
        if (!target.isUpgraded)
        {
        upgradeCost.text = "$" + target.turretBluePrint.upgradeCost;
            upgrsdeButton.interactable = true;
        }else
        {
            upgradeCost.text = "done";
            upgrsdeButton.interactable = false;
        }
        sellAmount.text = "$" + target.turretBluePrint.GetSellAmount();
        ui.SetActive(true);
    }

    public void Hide()
    {
        ui.SetActive(false);
    }
    public void Upgrade()
    {
        target.UpgradeTurret();
        BuildManager.instance.DeslectNode();
    }
    public void Sell()
    {
        target.SellTurret();
        BuildManager.instance.DeslectNode();
    }
}
