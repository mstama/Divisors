using System;
using System.Text;
using System.Threading;

namespace Divisors.Services
{
    /// <summary>
    /// ASCII Console Progress Bar Code from: https://gist.github.com/DanielSWolf/0ab6a96899cc5377bf54
    /// </summary>
    public class ProgressConsole : IProgress<double>, IDisposable
    {
        private const string _animation = @"|/-\";
        private readonly int _blockCount;
        private readonly char _emptyBarValue;
        private readonly char _fullBarValue;
        private readonly int _refreshInterval;
        private readonly Timer _timer;
        private int _animationIndex = 0;
        private int _currentCursorTop = 0;
        private string _currentText = string.Empty;
        private bool _enabled = false;
        private double _progressValue;

        /// <summary>
        /// Constructor
        /// </summary>
        public ProgressConsole() : this(250, 10, '-', '#') { }

        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="refreshInterval">Refresh interval in ms (default:250)</param>
        /// <param name="blockCount">Size of progress bar (default:10)</param>
        /// <param name="emptyBarValue">Representation of empty progress bar (default:-)</param>
        /// <param name="fullBarValue">Representation of full progress bar (default:#)</param>
        public ProgressConsole(int refreshInterval, int blockCount, char emptyBarValue, char fullBarValue)
        {
            _refreshInterval = refreshInterval;
            _blockCount = blockCount;
            _emptyBarValue = emptyBarValue;
            _fullBarValue = fullBarValue;
            // Just create the timer but disable its calls
            _timer = new Timer(BuildProgressBar, null, Timeout.Infinite, Timeout.Infinite);
        }

        /// <summary>
        /// Update progress
        /// </summary>
        /// <param name="value"></param>
        public void Report(double value)
        {
            value = Math.Max(0, Math.Min(1, value));
            Interlocked.Exchange(ref _progressValue, value);
            if (value == 1)
            {
                lock (_timer)
                {
                    StopTimer();
                }
            }
            else
            {
                if (!_enabled)
                {
                    ResetTimer();
                }
            }
        }

        /// <summary>
        /// Timer execution
        /// </summary>
        /// <param name="state"></param>
        private void BuildProgressBar(object state)
        {
            lock (_timer)
            {
                if (_disposed)
                {
                    return;
                }
                int progressBlockCount = (int)(_progressValue * _blockCount);
                int percent = (int)(_progressValue * 100);
                string text = string.Format("[{0}{1}] {2,3}% {3}",
                    new string(_fullBarValue, progressBlockCount), new string(_emptyBarValue, _blockCount - progressBlockCount),
                    percent,
                    _animation[_animationIndex++ % _animation.Length]);
                UpdateConsole(text);
                ResetTimer();
            }
        }

        private int FindDiffStart(string text)
        {
            int common = 0;
            int maxLength = Math.Min(_currentText.Length, text.Length);
            while (common < maxLength && text[common] == _currentText[common])
            {
                common++;
            }

            return common;
        }

        /// <summary>
        /// Schedule timer
        /// </summary>
        private void ResetTimer()
        {
            // Only update when not redirected
            if (!Console.IsOutputRedirected)
            {
                _timer.Change(_refreshInterval, Timeout.Infinite);
                _enabled = true;
            }
        }

        private void StopTimer()
        {
            if (_enabled)
            {
                _timer.Change(Timeout.Infinite, Timeout.Infinite);
                UpdateConsole(string.Empty);
                _enabled = false;
            }
        }

        /// <summary>
        /// Updates only the difference
        /// </summary>
        /// <param name="text"></param>
        private void UpdateConsole(string text)
        {
            // If line changed
            if (_currentCursorTop != Console.CursorTop)
            {
                _currentText = string.Empty;
                _currentCursorTop = Console.CursorTop;
            }

            // Get length of common portion
            int diffStart = FindDiffStart(text);

            // Backtrack to the first differing character
            var outputBuilder = new StringBuilder();
            outputBuilder.Append('\b', _currentText.Length - diffStart);

            // Output new suffix
            outputBuilder.Append(text.Substring(diffStart));

            // If the new text is shorter than the old one: delete overlapping characters
            int surplus = _currentText.Length - text.Length;
            if (surplus > 0)
            {
                outputBuilder.Append(' ', surplus);
                outputBuilder.Append('\b', surplus);
            }

            Console.Write(outputBuilder);
            _currentText = text;
        }

        #region IDisposable Support

        private bool _disposed = false; // To detect redundant calls

        public void Dispose()
        {
            lock (_timer)
            {
                Dispose(true);
            }
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!_disposed)
            {
                StopTimer();
                if (disposing)
                {
                    _timer.Dispose();
                }
                _disposed = true;
            }
        }

        #endregion IDisposable Support
    }
}