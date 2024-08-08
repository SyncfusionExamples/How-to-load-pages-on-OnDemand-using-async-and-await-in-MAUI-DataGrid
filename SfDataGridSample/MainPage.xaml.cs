using Syncfusion.Maui.Data;
using Syncfusion.Maui.DataGrid.DataPager;
namespace SfDataGridSample
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void dataPager_OnDemandLoading(object? sender, OnDemandLoadingEventArgs e)
        {
            var sourse = await vm.orderData.GetOrdersAsync(); 
            dataPager.LoadDynamicItems(e.StartIndex, sourse.Skip(e.StartIndex).Take(e.PageSize));
            (dataPager.PagedSource as PagedCollectionView).ResetCache();
        }
    }
}
