using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

namespace FourtyFourty.UI.Screen
{

    [RequireComponent(typeof(Animator))]
    [RequireComponent(typeof(CanvasGroup))]
    public class UI_Screen : MonoBehaviour
    {
        #region Variables

        public Animator animator;

        [Header("Screen Events")]
        public UnityEvent onScreenStart = new UnityEvent();
        public UnityEvent onScreenClose = new UnityEvent();

        //public FF_UI_Screen nextScreen;
        #endregion

        #region Main Methods

        private void Awake()
        {
            animator = gameObject.GetComponent<Animator>();
        }

        #endregion

        #region Helper Methods

        public virtual void OpenScreen()
        {
            onScreenStart?.Invoke(); //using null propagation

            Debug.Log("Opening");

            PlayAnimation("show");
        }

        public virtual void CloseScreen()
        {
            onScreenClose?.Invoke();
            PlayAnimation("hide");
        }

        private void PlayAnimation(string trigger)
        {
            if (!animator) return;
            animator.SetTrigger(trigger);
        }
        #endregion
    }
}