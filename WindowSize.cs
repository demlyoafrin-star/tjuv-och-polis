using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TjuvOchPolis
{
    internal class WindowSize
    {
        public static void TryEnsureConsoleHeight(int desiredHeight)
        {
            try
            {
                // Ensure desired does not exceed the largest possible window height for this environment
                int maxWindow = Console.LargestWindowHeight;
                int windowHeight = Math.Min(desiredHeight, maxWindow);

                // If buffer is smaller than the target window height, grow buffer first
                if (Console.BufferHeight < windowHeight)
                {
                    try
                    {
                        Console.BufferHeight = windowHeight;
                    }
                    catch
                    {
                        // Some hosts may not allow changing buffer; swallow and continue
                    }
                }

                // Now set the window height (must be <= BufferHeight)
                try
                {
                    Console.WindowHeight = windowHeight;
                }
                catch
                {
                    // Some hosts or terminals won't allow resizing the window; ignore and continue
                }

                // Finally, if you wanted a larger buffer than the window, attempt to set it
                if (Console.BufferHeight < desiredHeight)
                {
                    try
                    {
                        Console.BufferHeight = desiredHeight;
                    }
                    catch
                    {
                        // ignore if impossible
                    }
                }
            }
            catch
            {
                // If anything unexpected happens, do not crash — continue with current console size
            }
        }
    }
}
