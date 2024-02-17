using Serilog.Sinks.MSSqlServer;

namespace BinanceReactDemo.Common.LogHelper
{
    /// <summary>
    /// SeriLog Column Types
    /// </summary>
    public static class ColumnOptionsProvider
    {
        /// <summary>
        /// SeriLog Column Options
        /// </summary>
        /// <returns>ColumnOptions</returns>
        public static ColumnOptions GetColumnOptions()
        {
            var columnOptions = new ColumnOptions();

            columnOptions.Message.ColumnName = "Message";
            columnOptions.Message.DataLength = 2048;

            columnOptions.Level.ColumnName = "Level";
            columnOptions.Level.DataLength = 128;

            columnOptions.TimeStamp.ColumnName = "TimeStamp";
            columnOptions.TimeStamp.ConvertToUtc = true;

            columnOptions.Exception.ColumnName = "Exception";
            columnOptions.Exception.DataLength = 2048;

            columnOptions.Properties.ColumnName = "Properties";
            columnOptions.LogEvent.ExcludeAdditionalProperties = true;

            columnOptions.Properties.ColumnName = "LogEvent";
            columnOptions.Exception.DataLength = 2048;

            return columnOptions;
        }
    }
}
