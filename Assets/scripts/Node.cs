using UnityEngine;

public class Node : MonoBehaviour
{
    public Color hoverColor;
    private GameObject turret;

    public Vector3 posetionOffSet;
    private Renderer rend;
    private Color startColor;
    // Start is called before the first frame update
    void Start()
    {
        rend = GetComponent<Renderer>();
        startColor = rend.material.color;
    }
    private void OnMouseDown()
    {
        if (turret != null)
        {
            Debug.Log("can't build there -TOOO:Display on screen.");
            return;
        }
        //build a turret
        GameObject turretToBuild = BuildManager.instance.GetTurretToBuild();
        turret =(GameObject)Instantiate(turretToBuild, transform.position+ posetionOffSet, transform.rotation);
    }

    private void OnMouseEnter()
    {
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
