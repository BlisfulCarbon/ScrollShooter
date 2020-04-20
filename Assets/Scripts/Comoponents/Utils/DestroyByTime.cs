namespace ScrollShooter.Components
{
    public class DestroyByTime : BaseComponent
    {
        public float destroyTime = 0;

        private void Start()
        {
            Destroy(this.gameObject, destroyTime);
        }
    }
}