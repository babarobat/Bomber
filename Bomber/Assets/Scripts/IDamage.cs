namespace Bomber.Interfaces
{
    /// <summary>
    /// Интерфейс получения урона
    /// </summary>
    public interface IDamage
    {
        /// <summary>
        /// Получение урона
        /// </summary>
        /// <param name="damage">колличество урона</param>
        void ApplyDamage(int damage);
    }
}
