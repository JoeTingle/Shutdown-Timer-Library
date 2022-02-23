namespace ShutdownTimerLibrary
{
    /// <summary>
    /// Main class controlling computer shutdown functionality and timers
    /// </summary>
    public class Shutdown
    {
        /// <summary>
        /// Main timer for controlling shutdown timings, defaulted to run Execute() on tick and does not repeat
        /// </summary>
        private static Timer? timer;

        /// <summary>
        /// Will open a new process and run the shutdown command, with no popup windows
        /// </summary>
        /// <param name="state"></param>
        private static void Execute(object? state)
        {
            var psi = new System.Diagnostics.ProcessStartInfo("shutdown", "/s /t 0");
            psi.CreateNoWindow = true;
            psi.UseShellExecute = false;
            System.Diagnostics.Process.Start(psi);
        }

        /// <summary>
        /// Initializes a new timer
        /// </summary>
        /// <param name="minutes"> Amount for the timer to run untill</param>
        public static void BeginTimer(int minutes)
        {
            if (minutes > 0)
            {
                timer = new System.Threading.Timer(Execute, null, TimeSpan.FromMinutes(minutes), TimeSpan.Zero);
            }
            else
            {
                throw new Exception("\nMinutes paramter must be above 0 !\n");
            }
        }

        /// <summary>
        /// Begin shutdown process straight away
        /// </summary>
        public static void Now()
        {
            //Call private function with null arguments
            Execute(null);
        }

        /// <summary>
        /// Disposes of the current values for the main timer, essentially canceling it
        /// </summary>
        /// <exception cref="InvalidOperationException"></exception>
        public static void Cancel()
        {
            if (timer != null)
            {
                timer.Dispose();
            }
            else
            {
                throw new InvalidOperationException("Timer is null ! \nPlease check if you have initialised a value for the timer.");
            }
        }
    }

}