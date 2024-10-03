using Scripts.Characters;
using Scripts.Managers;
using UnityEngine;
using Zenject;

namespace Scripts.Objects
{
    public class ObstacleChecker : MonoBehaviour
    {
        [SerializeField] private LayerMask _target;

        private Player _player;

        [Inject]
        private void Construct(Player player)
        {
            _player = player;
        }

        private void OnCollisionEnter(Collision collision)
        {
            if ((_target & (1 << collision.gameObject.layer)) != 0)
            {
                FindObjectOfType<AudioManager>().PlaySfx("hit");
                _player.Die();
            }
        }

        //private void OnCollisionEnter(Collision collision)
        //{
        //    var player = collision.gameObject.tag == "Player";
        //    if (player)
        //    {
        //        FindObjectOfType<AudioComponent>().PlaySfx("hit");
        //        _player.IsDead = true;

        //        _session.StopGame();
        //    }
        //}
    }
}