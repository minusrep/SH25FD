namespace Root
{
    public class Stock : Interactable
    {
        public override void Interact()
        {
            Destroy(gameObject);
        }
    }
}