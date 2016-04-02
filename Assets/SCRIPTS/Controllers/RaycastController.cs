using UnityEngine;
using System.Collections;

public class RaycastController : TapSteveElement 
{
	
	// Update is called once per frame
	void FixedUpdate() 
    {
        if (Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, 100))
            {
                if (hit.collider.tag == "Limb")
                {
                    //If it's babylimb get parent and then fire method in LimbView component
                    if (hit.transform.parent.name == "babysteve" || hit.transform.parent.name == "childlimbs")
                    {
                        hit.transform.parent.GetComponent<LimbView>().TapSteve(hit.transform.parent.name);
                    }
                    else {
                        hit.transform.GetComponent<LimbView>().TapSteve(hit.transform.name);
                    }
                }
            }
        }
    }
}
