using System;
using System.Diagnostics;
using DataGen.App.Infrastructure.Contracts;
using DataGen.App.ViewModels;
using Konsole;

namespace DataGen.App.Views
{
    class JsonView: IView, IDisposable
    {
        private readonly JsonViewModel _viewModel;
        private ProgressBar _progressBar;
        private int _currentTick = 0;
        private Stopwatch _stopwatch;

        public JsonView(JsonViewModel jsonViewModel)
        {
            _viewModel = jsonViewModel;
        }

        public void Render()
        {
            if (_progressBar == null)
            {
                Console.WriteLine(_viewModel.Message);
                _stopwatch = new Stopwatch();
                _stopwatch.Start();
                _progressBar = new ProgressBar(_viewModel.Count);
            }
        }

        public void Step (int stepCount)
        {
            _stopwatch.Stop();

            _currentTick += stepCount;
            var tickCount = _viewModel.Count;
            var leftCount = tickCount - _currentTick;
            var eta = (_stopwatch.Elapsed / _currentTick) * leftCount;
            var timeLeft = Math.Round(eta.TotalHours);
            var timeUnit = 'h';

            if (timeLeft == 0)
            {
                timeLeft = Math.Round(eta.TotalMinutes);
                timeUnit = 'm';
            }

            if (timeLeft == 0)
            {
                timeLeft = Math.Round(eta.TotalSeconds);
                timeUnit = 's';
            }

            var itemMessagePrefix = _currentTick >= tickCount ? "Done" : "Item:";
            var nextMessage = $@"{itemMessagePrefix} {_currentTick}/{tickCount} . {timeLeft}{timeUnit} left";

            _stopwatch.Start();
            _progressBar.Refresh(_currentTick, nextMessage);
        }

        public void Dispose()
        {
            _progressBar = null;
        }
    }
}
