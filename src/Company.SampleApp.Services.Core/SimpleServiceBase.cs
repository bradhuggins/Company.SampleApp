#region Using Statements

#endregion

namespace Company.SampleApp.Services.Core
{
    public abstract class SimpleServiceBase
    {
        /// <summary>
        /// Gets or sets the error message.
        /// </summary>
        /// <value>
        /// The error message.
        /// </value>
        public string ErrorMessage { get; set; }

        /// <summary>
        /// Gets a value indicating whether [has error].
        /// </summary>
        /// <value>
        ///   <c>true</c> if [has error]; otherwise, <c>false</c>.
        /// </value>
        public bool HasError
        {
            get { return !string.IsNullOrEmpty(this.ErrorMessage); }
        }

    }
}
