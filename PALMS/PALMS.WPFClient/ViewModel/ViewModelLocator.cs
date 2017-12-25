using Autofac;
using Autofac.Extras.CommonServiceLocator;
using CommonServiceLocator;
using GalaSoft.MvvmLight;
using GalaSoft.MvvmLight.Ioc;
using Microsoft.Practices.ServiceLocation;

namespace PALMS.WPFClient.ViewModel
{

    public class ViewModelLocator
    {
        private static IContainer Container { get; set; }

        public MainViewModel Main => Container.Resolve<MainViewModel>();


        public ViewModelLocator()
        {
            var builder = new ContainerBuilder();

            RegisterServices(builder);
            RegisterViewModels(builder);

            Container = builder.Build();

            ServiceLocator.SetLocatorProvider(() => new AutofacServiceLocator(Container));
        }

        public static void Cleanup()
        {
            // TODO Clear the ViewModels
        }

        private void RegisterServices(ContainerBuilder builder)
        {
            builder.RegisterType<ApiHelper>().As<IApiHelper>().SingleInstance();

            builder.RegisterType<Repository>().As<IRepository>().SingleInstance();
            builder.RegisterType<DialogService>().As<IDialogService>().SingleInstance();
        }

        private static void RegisterViewModels(ContainerBuilder builder)
        {
            builder.RegisterType<MainViewModel>().SingleInstance();
            //builder.RegisterType<ReportsViewModel>();
            //builder.RegisterType<ReportEditViewModel>();
            //builder.RegisterType<ReportEditWindowViewModel>();
        }
    }
}