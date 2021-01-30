#region Using Statements
using Microsoft.EntityFrameworkCore.Diagnostics;
using System.Data.Common;
using System.Diagnostics.CodeAnalysis;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
#endregion

namespace Company.SampleApp.Data.Ef
{
    [ExcludeFromCodeCoverage]
    public class WithNoLockInterceptor : DbCommandInterceptor
    {
        //private static readonly Regex TableAliasRegex = new Regex(@"(?<tableAlias>\[dbo\]\.\[([\w\d]*)\] AS \[Extent\d+\](?! WITH \(NOLOCK\)))", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        //private static readonly Regex TableAliasRegex = new Regex(@"(?<tableAlias>\[([\w\d]*)\] AS \[([\w\d]*)\](?! WITH \(NOLOCK\)))", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        private static readonly Regex TableAliasRegex = new Regex(@"(?<tableAlias>(FROM|JOIN) \[([\w\d]*)\] AS \[([\w\d]*)\](?! WITH \(NOLOCK\)))", RegexOptions.Compiled | RegexOptions.Multiline | RegexOptions.IgnoreCase);
        
        public override InterceptionResult<DbDataReader> ReaderExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result)
        {
            command.CommandText = WithNoLockInterceptor.TableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            return base.ReaderExecuting(command, eventData, result);
        }

        public override InterceptionResult<object> ScalarExecuting(DbCommand command, CommandEventData eventData, InterceptionResult<object> result)
        {
            command.CommandText = WithNoLockInterceptor.TableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            return base.ScalarExecuting(command, eventData, result);
        }

        public override ValueTask<InterceptionResult<DbDataReader>> ReaderExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<DbDataReader> result, CancellationToken cancellationToken = default)
        {
            command.CommandText = WithNoLockInterceptor.TableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            return base.ReaderExecutingAsync(command, eventData, result, cancellationToken);
        }

        public override ValueTask<InterceptionResult<object>> ScalarExecutingAsync(DbCommand command, CommandEventData eventData, InterceptionResult<object> result, CancellationToken cancellationToken = default)
        {
            command.CommandText = WithNoLockInterceptor.TableAliasRegex.Replace(command.CommandText, "${tableAlias} WITH (NOLOCK)");
            return base.ScalarExecutingAsync(command, eventData, result, cancellationToken);
        }
    }
}
