using UnityEngine;


namespace MazeAndBall
{
    public sealed class GoodBonus : InteractiveObject, IFly, IFlicker
    {
        private MyBall player;
        private Material _material;
        private DisplayBonuses _displayBonuses;
        private float _lengthFlay;
        private static int scores;
        private float bonusTime = 10.0f;

        private void Awake()
        {
            player = FindObjectOfType<MyBall>();
            _displayBonuses = new DisplayBonuses();
            _material = GetComponent<Renderer>().material;
            _lengthFlay = Random.Range(1.0f, 2.0f);
        }

        protected override void Interaction()
        {
            scores++;
            _displayBonuses.Display(scores);
            player.Accelerate(bonusTime);
            Destroy(gameObject);
        }

        public void Fly()
        {
            transform.localPosition = new Vector3(transform.localPosition.x,
                Mathf.PingPong(Time.time, _lengthFlay),
                transform.localPosition.z);
        }

        public void Flick()
        {
            _material.color = new Color(Mathf.PingPong(Time.time, 1.0f), _material.color.g, _material.color.b,
                Mathf.PingPong(Time.time, 1.0f));
        }
    }
}
