using System;

public interface IOperation
{
    Guid OperationId { get; }
}

public interface IOperationTransient : IOperation
{
}

public interface IOperationScoped : IOperation
{
}

public interface IOperationSingleton : IOperation
{
}

public interface IOperationInstance : IOperation
{
}

public class Operation: IOperationInstance, IOperationScoped, IOperationSingleton, IOperationTransient
{
    private Guid? empty;

    public Operation() {}

    public Operation(Guid empty)
    {
        this.empty = empty;
    }

    Guid IOperation.OperationId
    {
        get
        {
            if(!this.empty.HasValue)
            {
                this.empty = Guid.NewGuid();
            }

            return empty.Value;
        }
    }
}