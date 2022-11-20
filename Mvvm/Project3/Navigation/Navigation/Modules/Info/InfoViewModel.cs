using System.Threading.Tasks;
using Navigation.Common;
using Navigation.Modules.History;

namespace Navigation.Modules.Info
{
    public class InfoViewModel: BaseViewModel
    {
        public InfoViewModel(HistoryViewModel historyViewModel)
        {
            HistoryViewModel = historyViewModel;
        }

        public HistoryViewModel HistoryViewModel { get; set; }

        public override Task InitializeAsync(object parameter)
        {
            return HistoryViewModel.InitializeAsync(parameter);
        }
    }
}
