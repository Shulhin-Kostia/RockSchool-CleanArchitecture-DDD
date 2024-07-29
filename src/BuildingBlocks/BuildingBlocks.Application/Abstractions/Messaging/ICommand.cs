namespace BuildingBlocks.Application.Abstractions.Messaging;

public interface IBaseCommand
{
    
}

public interface ICommand
{

}

public interface ICommand<TResponse> : IBaseCommand
{

}

