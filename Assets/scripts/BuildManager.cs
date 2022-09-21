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

    public GameObject standardTurretPrefab;
    public GameObject missileLauncherPrefad;



    private TurretBluePrint turretToBuild;

    public bool CanBuild { get { return turretToBuild != null; } }
    public void BuildTurretOn(Node node)
    {
        
        if (PlayerStats.Money < turretToBuild.cost)
        {
            Debug.Log("Not Money for building");
            return;
        }

        PlayerStats.Money -= turretToBuild.cost;

        GameObject turret = (GameObject)Instantiate(turretToBuild.prefab,node.GetbuildPosition(),Quaternion.identity);
        node.turret = turret;

        Debug.Log("Turret build! Money left:" + PlayerStats.Money);
    }
    public void SelectTurretToBuild(TurretBluePrint turret)
    {
        turretToBuild = turret;
    }
}
