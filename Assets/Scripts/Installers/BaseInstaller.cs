using Scripts.Characters;
using Scripts.Managers;
using Scripts.Pooling;
using Scripts.Service;
using Scripts.UI;
using UnityEngine;
using Zenject;

namespace Unavinar.Installers
{
    public class BaseInstaller : MonoInstaller
    {
        [SerializeField] private Player _player;
        [SerializeField] private MatchManager _gameManager;
        [SerializeField] private AudioManager _audioManager;
        [SerializeField] private ObjectPool _objectPool;
        [SerializeField] private CameraController _cameraController;
        [SerializeField] private BoardControlSlider _boardControlSlider;

        public override void InstallBindings()
        {
            InstallPlayerController();
            InstallGameSession();
            InstallAudioManager();
            InstallObjectPool();
            InstallCameraController();
            InstallBoardControlSlider();
        }

        private void InstallPlayerController()
        {
            Container.Bind<Player>().FromInstance(_player).AsSingle().NonLazy();
            Container.QueueForInject(_player);
        }

        private void InstallGameSession()
        {
            Container.Bind<MatchManager>().FromInstance(_gameManager).AsSingle().NonLazy();
            Container.QueueForInject(_gameManager);
        }

        private void InstallAudioManager()
        {
            Container.Bind<AudioManager>().FromInstance(_audioManager).AsSingle().NonLazy();
            Container.QueueForInject(_audioManager);
        }

        private void InstallObjectPool()
        {
            Container.Bind<ObjectPool>().FromInstance(_objectPool).AsSingle().NonLazy();
            Container.QueueForInject(_objectPool);
        }

        private void InstallCameraController()
        {
            Container.Bind<CameraController>().FromInstance(_cameraController).AsSingle().NonLazy();
            Container.QueueForInject(_cameraController);
        }

        private void InstallBoardControlSlider()
        {
            Container.Bind<BoardControlSlider>().FromInstance(_boardControlSlider).AsSingle().NonLazy();
            Container.QueueForInject(_boardControlSlider);
        }
    }
}