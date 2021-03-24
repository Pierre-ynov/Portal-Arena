using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Script.StatusEffects
{
    public abstract class StatusEffectBase : MonoBehaviour
    {
        /// <summary>
        /// Définit les dégâts de l'effet 
        /// </summary>
        public int damage;

        /// <summary>
        /// Définit la durée maximum de l'effet
        /// </summary>
        public int maxDurationEffect;

        /// <summary>
        /// Définit la durée minimum de l'effet
        /// </summary>
        public int minDurationEffect;

        /// <summary>
        /// Definit l'image de l'effet
        /// </summary>
        public Sprite imgStatusEffect;

        /// <summary>
        /// Lance le fonctionnement de l'effet
        /// </summary>
        public abstract void ActionStatusEffect(Player player);

        /// <summary>
        /// Définit le joueur qui est affecté par ce statut
        /// </summary>
        protected Player player;

        /// <summary>
        /// Donne une valeur aléatoire entre le minimum et le maximum de la durée d'effet
        /// </summary>
        /// <returns></returns>
        protected float RandomDurationEffect()
        {
            return UnityEngine.Random.Range(minDurationEffect, maxDurationEffect);
        }

        public virtual IEnumerator CoolDown(float duration)
        {
            for (int i = 1; i <= duration; i++)
            {
                yield return new WaitForSeconds(1);
                player.HurtPlayer(damage);
            }
            player.DeleteStatusEffect();
            Destroy(gameObject);
        }
    }
}
