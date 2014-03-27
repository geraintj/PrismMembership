using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mime;
using System.Text;
using System.Text.RegularExpressions;
using System.Timers;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;
using Microsoft.Practices.Prism;
using Microsoft.Practices.Prism.Commands;
using Microsoft.Practices.Prism.ViewModel;
using PrismMembership.Data;
using PrismMembership.Services;

namespace PrismMembership.Modules.Membership.ViewModels
{
    [Export(typeof(MemberListViewModel))]
    public class MemberListViewModel : NotificationObject
    {
        public DelegateCommand<string> SelectEntityCommand { get; set; }

        private readonly IMemberService _memberService;
        private readonly Timer _updateTimer;

        [ImportingConstructor]
        public MemberListViewModel(IMemberService memberService)
        {
            _memberService = memberService;

            _updateTimer = new Timer(250);
            _updateTimer.Elapsed += UpdateTimerElapsed;

            FoundMembers =  new ObservableCollection<Member>();
        }
        
        public ObservableCollection<Member> FoundMembers { get; set; }

        private string _searchString;
        public string SearchString
        {
            get { return string.IsNullOrEmpty(_searchString) ? null : _searchString; }
            set
            {
                if (value != _searchString)
                {
                    _searchString = value;

                    RaisePropertyChanged(() => SearchString);
                    ResetTimer();
                }
            }
        }

        public void SelectFullMatch()
        {
            if (_updateTimer.Enabled)
            {
                _updateTimer.Stop();
                UpdateFoundMembers();
            }
            if (FoundMembers.Count > 1 && FoundMembers.Any(x => x.Surname == SearchString))
            {
                var f = FoundMembers.First(x => x.Surname == SearchString);
                FoundMembers.Clear();
                FoundMembers.Add(f);
            }
            if (SelectEntityCommand.CanExecute(""))
                SelectEntityCommand.Execute("");
        }

        private void ResetTimer()
        {
            _updateTimer.Stop();
            if (!string.IsNullOrEmpty(SearchString))
            {
                _updateTimer.Start();
            }
            else FoundMembers.Clear();
        }

        private void UpdateFoundMembers()
        {
            var result = new List<Member>();

            using (var worker = new BackgroundWorker())
            {
                worker.DoWork += delegate
                {
                    result = _memberService.SearchMembers(SearchString).OrderBy(m => m.Surname).ToList();
                };

                worker.RunWorkerCompleted +=
                    delegate
                    {

                        Application.Current.Dispatcher.BeginInvoke(DispatcherPriority.Normal, new Action(
                               delegate
                               {
                                   FoundMembers.Clear();
                                   FoundMembers.AddRange(result);
                                   //RaisePropertyChanged(() => SelectedEntity);
                                   CommandManager.InvalidateRequerySuggested();
                               }));

                    };

                worker.RunWorkerAsync();
            }
        }

        void UpdateTimerElapsed(object sender, ElapsedEventArgs e)
        {
            _updateTimer.Stop();
            UpdateFoundMembers();
        }
    }
}
