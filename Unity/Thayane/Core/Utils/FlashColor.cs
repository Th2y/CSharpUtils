using DG.Tweening;
using System.Collections.Generic;
using UnityEngine;

namespace Thayane.Core.Utils
{
    public class FlashColor : MonoBehaviour
    {
        [Header("Damage")]
        [SerializeField] private List<SpriteRenderer> damageRenderers;
        [SerializeField] private Color damageColor;
        [SerializeField] private float damageDuration = .2f;

        private Color initialColor;
        private Tween _damageCurrentTween;

        private void OnValidate()
        {
            if (damageRenderers == null || damageRenderers.Count == 0)
            {
                damageRenderers = new List<SpriteRenderer>();

                foreach (var renderer in transform.GetComponentsInChildren<SpriteRenderer>())
                {
                    damageRenderers.Add(renderer);
                }

                initialColor = damageRenderers[0].color;
            }
        }

        public void DamageFlash()
        {
            if (_damageCurrentTween != null)
            {
                _damageCurrentTween.Kill();
                damageRenderers.ForEach(i => i.color = initialColor);
            }

            foreach (var renderer in damageRenderers)
            {
                renderer.DOColor(damageColor, damageDuration).SetLoops(2, LoopType.Yoyo);
            }
        }
    }
}
