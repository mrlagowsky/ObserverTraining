namespace ObseverProject
{
    /// <summary>
    /// Interface for the object to observe the observable
    /// </summary>
    /// <typeparam name="T"></typeparam>
    interface IObserver<T>
    {
        void Update(T subject);
    }
}
