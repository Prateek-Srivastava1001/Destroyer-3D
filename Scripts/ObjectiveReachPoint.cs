using JetBrains.Annotations;
using UnityEngine;

[RequireComponent(typeof(Objective), typeof(Collider))]
public class ObjectiveReachPoint : MonoBehaviour
{
    [Tooltip("Visible transform that will be destroyed once the objective is completed")]
    public Transform destroyRoot;
    public Transform door;

    Objective m_Objective;

    void Awake()
    {
        m_Objective = GetComponent<Objective>();
        DebugUtility.HandleErrorIfNullGetComponent<Objective, ObjectiveReachPoint>(m_Objective, this, gameObject);

        if (destroyRoot == null)
            destroyRoot = transform;
    }

    void OnTriggerEnter(Collider other)
    {
      
        
        if (m_Objective.isCompleted)
            return;

        var player = other.GetComponent<PlayerCharacterController>();
        // test if the other collider contains a PlayerCharacterController, then complete
        if (player != null)
        {
            m_Objective.CompleteObjective(string.Empty, string.Empty, "Objective complete : KEY FOUND " );

            
            // destroy the transform, will remove the compass marker if it has one
            Destroy(destroyRoot.gameObject);
            door.Rotate(0f,90f,0f);
        }
    }
}
