using UnityEngine;

public class shop : MonoBehaviour
{
    BuildManager buildManger;

    private void Start()
    {
        buildManger = BuildManager.instance;
    }
    public void PurchaseStandTurret()
    {
        Debug.Log("Standard Turret Selected");
        buildManger.SetTurretToBuild(buildManger.standardTurretPrefab);
    }
    public void PurchaseMissileLauncher()
    {
        Debug.Log("Missile Launcher Selected");
        buildManger.SetTurretToBuild(buildManger.missileLauncherPrefad);
    }
}
