# How to load pages on OnDemand using async and await in .NET MAUI DataGrid
In this article, we will show you how to load pages on OnDemand using async and await in [.Net Maui DataGrid](https://www.syncfusion.com/maui-controls/maui-datagrid).

## xaml
```
<ContentPage.BindingContext>
    <local:OrderInfoViewModel x:Name="vm" />
</ContentPage.BindingContext>

<Grid>
    <Grid.RowDefinitions>
        <RowDefinition Height="70" />
        <RowDefinition Height="*" />
        <RowDefinition Height="70" />
    </Grid.RowDefinitions>

    <syncfusionControls:SfDataPager x:Name="dataPager"
                                    PageSize="20"
                                    PageCount="10"
                                    NumericButtonCount="10"
                                    UseOnDemandPaging="True"
                                    Grid.Row="2"
                                    OnDemandLoading="dataPager_OnDemandLoading" />

    <syncfusion:SfDataGrid x:Name="dataGrid"
                            HorizontalOptions="Fill"
                            ColumnWidthMode="Fill"
                            Grid.Row="1"
                            ItemsSource="{Binding PagedSource, Source={x:Reference dataPager}, Mode=TwoWay}" />
</Grid>
```

## C#
The below code illustrates how to load pages on OnDemand using async and await in DataGrid.
```
private async void dataPager_OnDemandLoading(object? sender, OnDemandLoadingEventArgs e)
{
    var sourse = await vm.orderData.GetOrdersAsync(); 
    dataPager.LoadDynamicItems(e.StartIndex, sourse.Skip(e.StartIndex).Take(e.PageSize));
    (dataPager.PagedSource as PagedCollectionView).ResetCache();
}
```
**Please remember to change the path according to your device's location when setting the connection string in OrderData class.**

 ![asyncScreenShot.png](https://support.syncfusion.com/kb/agent/attachment/inline?token=eyJhbGciOiJodHRwOi8vd3d3LnczLm9yZy8yMDAxLzA0L3htbGRzaWctbW9yZSNobWFjLXNoYTI1NiIsInR5cCI6IkpXVCJ9.eyJpZCI6IjI4MDA1Iiwib3JnaWQiOiIzIiwiaXNzIjoic3VwcG9ydC5zeW5jZnVzaW9uLmNvbSJ9.ymiNfTUK0BCVsReAr5SgZSzAxckcwCyBRDPuRG-cBQ8)

[View sample in GitHub](https://github.com/SyncfusionExamples/How-to-load-pages-on-OnDemand-using-async-and-await-in-MAUI-DataGrid)

Take a moment to explore this [documentation](https://help.syncfusion.com/maui/datagrid/overview), where you can find more information about Syncfusion .NET MAUI DataGrid (SfDataGrid) with code examples. Please refer to this [link](https://www.syncfusion.com/maui-controls/maui-datagrid) to learn about the essential features of Syncfusion .NET MAUI DataGrid (SfDataGrid).
 
##### Conclusion
 
I hope you enjoyed learning about how to load pages on OnDemand using async and await in .NET MAUI DataGrid (SfDataGrid).
 
You can refer to our [.NET MAUI DataGrid’s feature tour](https://www.syncfusion.com/maui-controls/maui-datagrid) page to learn about its other groundbreaking feature representations. You can also explore our [.NET MAUI DataGrid Documentation](https://help.syncfusion.com/maui/datagrid/getting-started) to understand how to present and manipulate data. 
For current customers, you can check out our .NET MAUI components on the [License and Downloads](https://www.syncfusion.com/sales/teamlicense) page. If you are new to Syncfusion, you can try our 30-day [free trial](https://www.syncfusion.com/downloads/maui) to explore our .NET MAUI DataGrid and other .NET MAUI components.
 
If you have any queries or require clarifications, please let us know in the comments below. You can also contact us through our [support forums](https://www.syncfusion.com/forums), [Direct-Trac](https://support.syncfusion.com/create) or [feedback portal](https://www.syncfusion.com/feedback/maui?control=sfdatagrid), or the feedback portal. We are always happy to assist you!