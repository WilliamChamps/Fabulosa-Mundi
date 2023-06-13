using System;
using System.Collections.Generic;
using Sirenix.OdinInspector;
using UnityEngine;

namespace StudioXP.Scripts.Controllers
{
    public class AnimatorController : MonoBehaviour
    {
        [ChildGameObjectsOnly]
        [SerializeField] private Animator animator;

        [LabelText("Paramètres")]
        [ShowIf("animator")]
        [ListDrawerSettings(IsReadOnly = true, Expanded = true)]
        [SerializeField]
        private List<AnimationParameter> parameters = new List<AnimationParameter>();

        private readonly HashSet<int> _validHash = new HashSet<int>();
        private bool _hasAnimator;

        private void OnValidate()
        {
            parameters.Clear();
            if (!animator || !animator.isActiveAndEnabled)
                return;

            foreach (var parameter in animator.parameters)
            {
                parameters.Add(new AnimationParameter(parameter.name, parameter.type));
            }
        }

        public void SetAnimator(AnimationParameter parameter)
        {
            
        }

        public void SetAnimatorBool(int hash, bool value)
        {
            if (!_hasAnimator || !_validHash.Contains(hash)) return;
            animator.SetBool(hash, value);
        }
    
        public void SetAnimatorFloat(int hash, float value)
        {
            if (!_hasAnimator || !_validHash.Contains(hash)) return;
            animator.SetFloat(hash, value);
        }
    
        public void SetAnimatorInteger(int hash, int value)
        {
            if (!_hasAnimator || !_validHash.Contains(hash)) return;
            animator.SetInteger(hash, value);
        }
        
        public void SetAnimatorTrigger(string parameterName)
        {
            SetAnimatorTrigger(AnimatorController.GetAnimatorHash(parameterName));
        }
    
        public void SetAnimatorTrigger(int hash)
        {
            if (!_hasAnimator || !_validHash.Contains(hash)) return;
            animator.SetTrigger(hash);
        }

        public bool IsCurrentStateName(int layer, int stateNameHash)
        {
            if (!_hasAnimator || layer >= animator.layerCount) return false;
            return animator.GetCurrentAnimatorStateInfo(layer).shortNameHash == stateNameHash;
        }

        public static int GetAnimatorHash(string parameterName)
        {
            return Animator.StringToHash(parameterName);
        }
    
        private void Awake()
        {
            _hasAnimator = animator != null;
            if (!_hasAnimator) return;
            
            foreach (var parameter in animator.parameters)
                _validHash.Add(parameter.nameHash);
        }
    }
}
