
using Autofac;
using Business.Abstract;
using Business.Concrete;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract.Interfaces;
using DataAccess.Concrete; 

namespace Business.DependencyResolvers.Autofac
{
  public  class ServiceModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {

            builder.RegisterType<ContactManager>().As<IContactService>().SingleInstance();
            builder.RegisterType<ContactRepository>().As<IContactRepository>().SingleInstance();


            builder.RegisterType<ContactInformationManager>().As<IContactInformationService>().SingleInstance();
            builder.RegisterType<ContactInformationRepository>().As<IContactInformationRepository>().SingleInstance();

            builder.RegisterType<UserManager>().As<IUserService>().SingleInstance();
            builder.RegisterType<UserRepository>().As<IUserRepository>().SingleInstance();

            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            builder.RegisterType<ReportManager>().As<IReportService>().SingleInstance();
            builder.RegisterType<ReportRepository>().As<IReportRepository>().SingleInstance();
        }
    }
}
