#region Using Statements
#endregion

namespace Company.SampleApp.Services.Core
{
    public abstract class ServiceBase<T> : SimpleServiceBase where T : class
    {
		internal T _repository;

        /// <summary>Initializes a new instance of the <see cref="ServiceBase{T}"/> class.</summary>
        /// <param name="repository">The repository.</param>
        public ServiceBase(T repository)
        {
            _repository = repository;
        }

    }

}
