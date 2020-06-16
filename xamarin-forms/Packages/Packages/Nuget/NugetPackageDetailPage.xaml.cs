using System;
using System.Reactive.Disposables;
using System.Reactive.Linq;
using ReactiveUI;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Packages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NuGetPackageDetailPage : ContentPageBase<NuGetPackageDetailViewModel>
    {
        public NuGetPackageDetailPage()
        {
            InitializeComponent();

            this.WhenAnyValue(x => x.ViewModel.PackageSearchMetadata)
                .Where(x => x != null)
                .InvokeCommand(this, x => x.ViewModel.GetVersions)
                .DisposeWith(ViewBindings);

            NuGetVersions
                .Events()
                .ItemSelected
                .Subscribe(_ => NuGetVersions.SelectedItem = null)
                .DisposeWith(ViewBindings);
        }
    }
}