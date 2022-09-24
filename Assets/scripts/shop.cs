using UnityEngine;

public class shop : MonoBehaviour
{
    public TurretBluePrint standardTurret;
    public TurretBluePrint missileLauncher;
    public TurretBluePrint laserBeamer;


    BuildManager buildManger;

    private void Start()
    {
        buildManger = BuildManager.instance;
    }
    public void SelectStandTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManger.SelectTurretToBuild(standardTurret);
    }
    public void SelectMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManger.SelectTurretToBuild(missileLauncher);
    }
    public void SelectLaserBeamer()
    {
        Debug.Log("Laser Beamer Selected");
        buildManger.SelectTurretToBuild(laserBeamer);
    }
}
