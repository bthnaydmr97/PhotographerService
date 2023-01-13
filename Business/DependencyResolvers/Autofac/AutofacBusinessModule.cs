using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;
using Core.Utilities.Security.JWT;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.DependencyResolvers.Autofac
{
    public class AutofacBusinessModule : Module
    {
        //Startupda yazılan Singletonları için işe yarar.
        protected override void Load(ContainerBuilder builder)
        {
            //birisi IDailyRecordService isterse DailyRecordManager instance yarat. Bütün instance alacaklarımızı burada registerlıyoruz.
            //Farklı db ler için çalışırsa ve farklı durumlar olursa if(db=="....") gibi registerlama işlemi yapabiliriz.

            #region dailyRecord
            builder.RegisterType<DailyRecordManager>().As<IDailyRecordService>().SingleInstance();
            builder.RegisterType<EFDailyRecordDal>().As<IDailyRecordDal>().SingleInstance();
            #endregion

            #region employee
            builder.RegisterType<EmployeeManager>().As<IEmployeeService>().SingleInstance();
            builder.RegisterType<EFEmployeeDal>().As<IEmployeeDal>().SingleInstance();

            #endregion

            #region workingType
            builder.RegisterType<WorkingTypeManager>().As<IWorkingTypeService>().SingleInstance();
            builder.RegisterType<EFWorkingTypeDal>().As<IWorkingTypeDal>().SingleInstance();
            #endregion

            #region appointmentType
            builder.RegisterType<AppointmentTypeManager>().As<IAppointmentTypeService>().SingleInstance();
            builder.RegisterType<EFAppointmentTypeDal>().As<IAppointmentTypeDal>().SingleInstance();
            #endregion

            #region appointmentDate
            builder.RegisterType<AppointmentDateManager>().As<IAppointmentDateService>().SingleInstance();
            builder.RegisterType<EFAppointmentDateDal>().As<IAppointmentDateDal>().SingleInstance();
            #endregion

            #region employeeWork
            builder.RegisterType<EmployeeWorkManager>().As<IEmployeeWorkService>().SingleInstance();
            builder.RegisterType<EFEmployeeWorkDal>().As<IEmployeeWorkDal>().SingleInstance();
            #endregion

            #region appointment
            builder.RegisterType<AppointmentManager>().As<IAppointmentService>().SingleInstance();
            builder.RegisterType<EFAppointmentDal>().As<IAppointmentDal>().SingleInstance();
            #endregion

            #region User
            builder.RegisterType<UserManager>().As<IUserService>();
            builder.RegisterType<EfUserDal>().As<IUserDal>();
            #endregion

            #region AuthToken
            builder.RegisterType<AuthManager>().As<IAuthService>();
            builder.RegisterType<JwtHelper>().As<ITokenHelper>();
            #endregion

            //Attributeleri Aspect var mı diye bakıyor.
            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();

        }
    }
}
