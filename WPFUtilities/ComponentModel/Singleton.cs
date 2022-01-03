namespace WPFUtilities.ComponentModel
{
    /// <summary>
    /// singleton feature
    /// </summary>
    /// <typeparam name="T">class</typeparam>
    public abstract class Singleton<T>
        where T : class, new()
    {
        static T _instance;
        /// <summary>
        /// shared instance
        /// </summary>
        public static T Instance => _instance ?? (_instance = new T());
    }
}
