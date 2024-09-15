using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

namespace CharacterMovement
{
    // sends input from PlayerInput to attached CharacterMovement components
    public class PlayerController : MonoBehaviour
    {
        // initial cursor state
        [field: SerializeField] protected CursorLockMode CursorMode { get; set; } = CursorLockMode.Locked;
        // make character look in Camera direction instead of MoveDirection
        [field: SerializeField] protected bool LookInCameraDirection { get; set; }

        [field: Header("Componenents")]
        [field: SerializeField] protected CharacterMovementBase Movement { get; set; }

        protected Vector2 MoveInput { get; set; }

        private Vector3 _aimPosition;

        protected virtual void OnValidate()
        {
            if(Movement == null) Movement = GetComponent<CharacterMovementBase>();
        }

        protected virtual void Awake()
        {
            Cursor.lockState = CursorMode;
        }

        public virtual void OnMove(InputValue value)
        {
            MoveInput = value.Get<Vector2>();
        }

        public virtual void OnJump(InputValue value)
        {
            Movement?.Jump();
        }

        public virtual void OnInteract(InputValue value)
        {
            Debug.Log(_aimPosition);
        }

        protected virtual void Update()
        {
            if (Movement == null) return;

            // find correct right/forward directions based on main camera rotation
            Vector3 up = Vector3.up;
            Vector3 right = Camera.main.transform.right;
            Vector3 forward = Vector3.Cross(right, up);
            Vector3 moveInput = forward * MoveInput.y + right * MoveInput.x;

            // send player input to character movement
            Movement.SetMoveInput(moveInput);
            Movement.SetLookDirection(moveInput);
            if (LookInCameraDirection) Movement.SetLookDirection(Camera.main.transform.forward);

            Ray aimPosRay = Camera.main.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
            if (Physics.Raycast(aimPosRay, out RaycastHit hit, Mathf.Infinity))
            {
                _aimPosition = hit.point;
            }
            else
            {
                _aimPosition = aimPosRay.GetPoint(75); //long distance away from the player
            }
        }
    }
}