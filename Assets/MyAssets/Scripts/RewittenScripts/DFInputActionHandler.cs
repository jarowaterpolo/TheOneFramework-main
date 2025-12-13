using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

namespace UnityFundamentals
{
    // This script can be tied to any input action from an active input set to listen for that input action.
    //
    // @author J.C. Wichman

    public class DFInputActionHandler : PlayerActivatable
    {
        [SerializeField] private UnityEvent OnInputAction;
        protected override void OnActivate()
        {
            OnInputAction?.Invoke();
        }
        //[SerializeField] private InputActionReference actionReference;



        //private void OnEnable()
        //{
        //    actionReference.action.performed += OnActionPerformed;
        //}

        //private void OnDisable()
        //{
        //    actionReference.action.performed -= OnActionPerformed;
        //}

        //private void OnActionPerformed(InputAction.CallbackContext context)
        //{
        //    OnInputAction?.Invoke();
        //}
    }
}
