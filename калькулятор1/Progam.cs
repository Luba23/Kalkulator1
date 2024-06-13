using CalculatorCsharp;
using Castle.Facilities.Startable;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.Windsor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator1
{
    public class Program
    {
        private static IWindsorContainer _container = new WindsorContainer();

        public static void Main()
        {
            try
            {
                Start();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
            finally
            {
                _container?.Dispose();
            }
        }

        private static void Start()
        {
            _container.Kernel.AddFacility<StartableFacility>(f => f.DeferredStart());
            _container.Kernel.Resolver.AddSubResolver(new CollectionResolver(_container.Kernel));
            _container.Install(new LocalInstaller());
        }
    }
}
