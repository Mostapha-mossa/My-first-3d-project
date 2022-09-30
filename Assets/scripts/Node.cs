using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    public Color notEnoughMoney;
    [HideInInspector]
    public GameObject turret;
    [HideInInspector]
    public TurretBluePrint turretBluePrint;
    [HideInInspector]
    public bool isUpgraded = false;

    public Vector3 posetionOffSet; 
    private Renderer rend;
    private Color startColor;
    BuildManager buildManger;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
        buildManger = BuildManager.instance;
    }
    private void OnMouseDown()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        
        if (turret != null)
        {
            buildManger.selectNode(this);
            return;
        }

        if (!buildManger.CanBuild)
        {
            return;
        }
        //build a turret
        BuildTurret(buildManger.GetTurretToBuild());
    }
    void BuildTurret(TurretBluePrint bluePrint)
    {
        if (PlayerStats.Money < bluePrint.cost)
        {
            Debug.Log("Not Money for building");
            return;
        }

        PlayerStats.Money -= bluePrint.cost;

        GameObject _turret = (GameObject)Instantiate(bluePrint.prefab, GetbuildPosition(), Quaternion.identity);
        turret = _turret;

        turretBluePrint = bluePrint;
        GameObject beffact = (GameObject)Instantiate(buildManger.buildEffact, GetbuildPosition(), Quaternion.identity);
        Destroy(beffact, 5f);

        Debug.Log("Turret build! ");
    }
    public void UpgradeTurret()
    {
        if (PlayerStats.Money < turretBluePrint.upgradeCost)
        {
            Debug.Log("Not Money for Upgrade that!");
            return;
        }

        PlayerStats.Money -= turretBluePrint.upgradeCost;
        Destroy(turret);

        GameObject _turret = (GameObject)Instantiate(turretBluePrint.upgradedPrefab, GetbuildPosition(), Quaternion.identity);
        turret = _turret;

        GameObject beffact = (GameObject)Instantiate(buildManger.buildEffact, GetbuildPosition(), Quaternion.identity);
        Destroy(beffact, 5f);

        isUpgraded = true;

        Debug.Log("Turret Upgraded! ");
    }
    public void SellTurret()
    {
        PlayerStats.Money += turretBluePrint.GetSellAmount();

        GameObject beffact = (GameObject)Instantiate(buildManger.sellEffect, GetbuildPosition(), Quaternion.identity);
        Destroy(beffact, 5f);

        Destroy(turret);
        turretBluePrint = null;
    }
    public Vector3 GetbuildPosition()
    {
        return transform.position + posetionOffSet;
    }
    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (!buildManger.CanBuild)
        {
            return;
        }
        if (buildManger.HasMoney)
        {
        rend.material.color = hoverColor;
        }else
        {
            rend.material.color = notEnoughMoney;
        }
    }
    private void OnMouseExit()
    {
        rend.material.color = startColor;
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
