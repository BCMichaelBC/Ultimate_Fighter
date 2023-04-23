using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableMovement : MonoBehaviour
{
    [SerializeField] private float disableTime;

    private List<MonoBehaviour> scriptsToDisable = new List<MonoBehaviour>();

    private void Start()
    {
        foreach (var script in GetComponents<MonoBehaviour>())
        {
            if (script != this)
            {
                scriptsToDisable.Add(script);
            }
        }

        StartCoroutine(DisableScripts());
    }

    private IEnumerator DisableScripts()
    {
        // disable all scripts
        foreach (var script in scriptsToDisable)
        {
            script.enabled = false;
        }

        yield return new WaitForSeconds(disableTime);

        foreach (var script in scriptsToDisable)
        {
            script.enabled = true;
        }
    }
}
