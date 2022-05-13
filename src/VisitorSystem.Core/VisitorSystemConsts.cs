using VisitorSystem.Debugging;

namespace VisitorSystem
{
    public class VisitorSystemConsts
    {
        public const string LocalizationSourceName = "VisitorSystem";

        public const string ConnectionStringName = "Default";
        public const string ConnectionStringOA = "OA";

        public const bool MultiTenancyEnabled = true;


        /// <summary>
        /// Default pass phrase for SimpleStringCipher decrypt/encrypt operations
        /// </summary>
        public static readonly string DefaultPassPhrase =
            DebugHelper.IsDebug ? "gsKxGZ012HLL3MI5" : "ff6cebf8055848d6a58e148545b29015";
    }
}
