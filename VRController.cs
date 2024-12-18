using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.InputSystem;

public class VRController : MonoBehaviour
{
    private CinemachineDollyCart m_Dollycart;
    public float RotSpeed = 10;
    public float MoveSpeed = 100;
    public Transform Head;

    [SerializeField]
    InputActionProperty m_ClambAction = new(new InputAction("ClambActivate", type: InputActionType.Button));

    [SerializeField]
    InputActionProperty m_VectorActionValue = new(new InputAction("Vector2 Value", expectedControlType: "Vector2"));

    public Animator m_Animator;
    public float newPosition;
    
    void Awake()
    {
        m_Dollycart = gameObject.GetComponentInParent<CinemachineDollyCart>();
    }

    private void OnEnable()
    {
        m_ClambAction.action.performed += OnClamb;
    }

    private void OnDisable()
    {
        m_ClambAction.action.performed -= OnClamb;
    }
    private void OnClamb(InputAction.CallbackContext obj)
    {
        RaycastHit hit;
        int layermask = 1 << LayerMask.NameToLayer("Obstacle");
        Debug.DrawLine(Head.position, Head.position + transform.forward * MoveSpeed * 1.5f, Color.red, 5);
        if (Physics.Raycast(Head.position, transform.forward, out hit, MoveSpeed * 1.5f, layermask))
        {
            Debug.Log("前方障碍物：" + hit.collider.name);
        }
        else
        {
            newPosition = m_Dollycart.m_Position + MoveSpeed;
            m_Animator.Play("Pa");
        }
    }
    void Update()
    {
        var dir = m_VectorActionValue.action.ReadValue<Vector2>();
        transform.Rotate(Vector3.forward, -dir.x * RotSpeed * Time.deltaTime);
        m_Dollycart.m_Position = Mathf.Lerp(m_Dollycart.m_Position, newPosition, Time.deltaTime * 10f);
    }
}