using Autofac;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using Vizsga.VizsgaDataLayer;

namespace Vizsga.Vizsga
{
    static class Program
    {
        public static IContainer Container;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            ContainerBuilder builder = new ContainerBuilder();

            builder.RegisterAssemblyModules(
                typeof(StudentService).Assembly);
            builder.RegisterAssemblyModules(
                typeof(AppointmentService).Assembly);
            builder.RegisterType<SampleContext>().As<ISampleContext>().InstancePerLifetimeScope();
            builder.Register(context => new StudentService(context.Resolve<ISampleContext>())).InstancePerLifetimeScope();
            builder.RegisterType<LoginForm>().AsSelf().InstancePerLifetimeScope();
            builder.Register(context => new AppointmentService(context.Resolve<ISampleContext>())).InstancePerLifetimeScope();
            builder.RegisterType<StudentListForm>().AsSelf().InstancePerLifetimeScope();
            builder.RegisterType<AppointmentListForm>().AsSelf().InstancePerLifetimeScope();

            Container = builder.Build();

            var lifestimeScope = Program.Container.BeginLifetimeScope();

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Main(lifestimeScope.Resolve<StudentService>(), lifestimeScope.Resolve<AppointmentService>()));
        }
    }
}
