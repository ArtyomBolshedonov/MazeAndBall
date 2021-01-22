using UnityEngine;
using Random = UnityEngine.Random;


namespace MazeAndBall
{
    public abstract class InteractiveObject : MonoBehaviour, IInteractable
    {
        protected Color _color;
        public bool IsInteractable { get; } = true;

        private void OnTriggerEnter(Collider other)
        {
            if (!IsInteractable || !other.CompareTag("Player"))
            {
                return;
            }
            Interaction();
        }
        protected abstract void Interaction();

        private void Start()
        {
            Action();
            //((IAction)this).Action();
            //((IInitialization)this).Action();
        }
        public void Action()
        {
            _color = Random.ColorHSV();
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = _color;
            }
        }

        void IAction.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Random.ColorHSV();
            }
        }

        void IInitialization.Action()
        {
            if (TryGetComponent(out Renderer renderer))
            {
                renderer.material.color = Color.cyan;
            }
        }
    }
}
