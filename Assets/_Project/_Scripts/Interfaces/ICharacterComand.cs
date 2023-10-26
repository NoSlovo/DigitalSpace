namespace _Project.Scripts.Interfaces
{
    public interface ICharacterComand: IComand
    {
        void Execute( ref float speedNow);
    }
}