using UnityEngine;
using UnityEngine.EventSystems;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject turret;

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
        if (buildManger.GetTurretToBuild()==null)
        {
            return;
        }
        if (turret != null)
        {
            Debug.Log("can't build there -TOOO:Display on screen.");
            return;
        }
        //build a turret
        GameObject turretToBuild = buildManger.GetTurretToBuild();
        turret =(GameObject)Instantiate(turretToBuild, transform.position+ posetionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
        if (EventSystem.current.IsPointerOverGameObject())
        {
            return;
        }
        if (buildManger.GetTurretToBuild() == null)
        {
            return;
        }
        rend.material.color = hoverColor;
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
