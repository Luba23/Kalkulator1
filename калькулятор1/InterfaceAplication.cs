using Castle.Facilities.Startable;
using Castle.MicroKernel.Registration;
using Castle.MicroKernel.Resolvers.SpecializedResolvers;
using Castle.MicroKernel.SubSystems.Configuration;
using Castle.Windsor;
using Calculator1.Operation;

namespace CalculatorCsharp;

public interface IOperation
{
    public string Name { get; }
}

public interface IOperationProvider
{
    public IEnumerable<Operation> Get();
}

public interface IMenu<out T>
{
    public IMenu<T> Show();
    public IMenuItemSelector<T> ItemSelector { get; }
}

public interface IMenuItemSelector<out T>
{
    public T Select();
}

public interface IOperationMenuItemSelector : IMenuItemSelector<Operation>
{

}

public interface IMenuItemSelectorProvider
{
    public int GetMenuItemId();
}

internal class LocalInstaller : IWindsorInstaller
{
    public void Install(IWindsorContainer container, IConfigurationStore store)
    {
        container.Register(
            Component.For<IWindsorContainer>().Instance(container),
            Component.For<Application>()
                     .StartUsingMethod("Run"),

            Component.For<IOperationMenuItemSelector>()
                     .ImplementedBy<OperationMenuItemSelector>()
                     .LifestyleTransient(),
            Component.For<IMenuItemSelectorProvider>()
                     .ImplementedBy<OperationMenuItemSelectorView>()
                     .LifestyleTransient(),
            Component.For<IOperationProvider>()
                     .ImplementedBy<OperationProvider>(),

            Component.For<IMenu<IOperation>>()
                     .ImplementedBy<OperationMenu>()
                     .LifestyleTransient(),

            Component.For<Operation>()
                     .ImplementedBy<Addition>(),
            Component.For<Operation>()
                     .ImplementedBy<Substraction>(),
            Component.For<Operation>()
                     .ImplementedBy<Multiplacation>(),
            Component.For<Operation>()
                     .ImplementedBy<Division>(),
            Component.For<Operation>()
                     .ImplementedBy<Sqrt>(),
            Component.For<Operation>()
                     .ImplementedBy<Cos>(),
            Component.For<Operation>()
                     .ImplementedBy<Sin>(),
           Component.For<Operation>()
                     .ImplementedBy<Tg>(),
            Component.For<Operation>()
                     .ImplementedBy<Factorial>(),
            Component.For<Operation>()
                     .ImplementedBy<Mod>()
        );
    }
}

public class Application
{
    public Application(
        IMenu<IOperation> menu)
    {
        this.menu = menu;
    }

    private IMenu<IOperation> menu;

    
     public void Run()
    {
        while (true)
        {
            Operation operation = (Operation)menu.Show().ItemSelector.Select();
            double result = operation.Run(10, 5);
            Console.WriteLine($"Результат: {result}");

            Console.WriteLine("Для выхода нажмите Escape, для продолжения нажмите любую клавишу");
            if (Console.ReadKey(true).Key == ConsoleKey.Escape)
            {
                break;
            }
        }
    }
}

public sealed class OperationProvider : IOperationProvider
{
    private IEnumerable<Operation> operations;

    public OperationProvider(IEnumerable<Operation> operations)
    {
        this.operations = operations;
    }

    public IEnumerable<Operation> Get()
    {
        return operations;
    }
}

public sealed class OperationMenu : IMenu<IOperation>
{
    public OperationMenu(IOperationProvider operationProvider,
        IOperationMenuItemSelector menuItemSelector)
    {
        this.operationProvider = operationProvider;
        ItemSelector = menuItemSelector;
    }

    private readonly IOperationProvider operationProvider;

    public IMenuItemSelector<IOperation> ItemSelector { get; }

    public IMenu<IOperation> Show()
    {
        Console.WriteLine("Программа: инженерный калькулятор.");
        int i = 1;
        foreach (IOperation operation in operationProvider.Get())
            Console.WriteLine($"{i++}. Операция {operation.Name};");
        return this;
    }
}

public sealed class OperationMenuItemSelectorView : IMenuItemSelectorProvider
{
    public int GetMenuItemId()
    {
        Console.Write("Выберите действие: ");
        return Convert.ToInt32(Console.ReadLine());
    }
}

public sealed class OperationMenuItemSelector : IOperationMenuItemSelector
{
    public OperationMenuItemSelector(
        IMenuItemSelectorProvider selector,
        IOperationProvider operationProvider)
    {
        this.selector = selector;
        this.operationProvider = operationProvider;
    }

    private readonly IMenuItemSelectorProvider selector;
    private readonly IOperationProvider operationProvider;

    public Operation Select()
    {
        int id = selector.GetMenuItemId();
        return operationProvider.Get().ElementAt(id - 1);
    }
}

public sealed class NewOperationMenu : IMenu<IOperation>
{
    public NewOperationMenu(IOperationProvider operationProvider,
        IOperationMenuItemSelector menuItemSelector)
    {
        this.operationProvider = operationProvider;
        ItemSelector = menuItemSelector;
    }

    private readonly IOperationProvider operationProvider;

    public IMenuItemSelector<IOperation> ItemSelector { get; }

    public IMenu<IOperation> Show()
    {
        Console.WriteLine("... Калькулятор ...");
        int i = 1;
        foreach (Operation operation in operationProvider.Get())
            Console.WriteLine($"{i++}. {operation.Name};");
        return this;
    }
}

