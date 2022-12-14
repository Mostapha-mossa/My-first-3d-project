using UnityEngine;

public class BuildManager : MonoBehaviour
{
    public static BuildManager instance;

    private void Awake()
    {
        if (instance != null)
        {
            Debug.Log("more than one BuidManage in scene");
            return;
        }
        instance = this;
    }


    public GameObject buildEffact;
    public GameObject sellEffect;

    private TurretBluePrint turretToBuild;
    private Node selectedNode;
    public NodeUI nodeUI;

    public bool CanBuild { get { return turretToBuild != null; } }
    public bool HasMoney { get { return PlayerStats.Money >= turretToBuild.cost; } }


    public void selectNode(Node node)
    {
        if (selectedNode == node)
        {
            DeslectNode();
            return;
        }
        selectedNode = node;
        turretToBuild = null;

        nodeUI.setTarget(node);
    }
    public void DeslectNode()
    {
        selectedNode = null;
        nodeUI.Hide();
    }

    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
        DeslectNode();
    }
    public TurretBluePrint GetTurretToBuild()
    {
        return turretToBuild;
    }
}
