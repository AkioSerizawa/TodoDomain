using Todo.Domain.Commands;
using Todo.Domain.Handlers;
using Todo.Domain.Tests.Repositories;

namespace Todo.Domain.Tests.HandlerTests;

[TestClass]
public class CreateTodoHandlerTests
{
    private readonly CreateTodoCommand _invalidCommand =
        new CreateTodoCommand("", "", DateTime.Now);

    private readonly CreateTodoCommand _validCommand =
        new CreateTodoCommand("Titulo da Tarefa", "Akio Serizawa", DateTime.Now);

    private readonly TodoHandler _handler = new TodoHandler(new FakeTodoRepository());

    private GenericCommandResult _result = new GenericCommandResult();

    [TestMethod]
    public void Dado_um_comando_invalido_deve_interromper_a_execucao()
    {
        _result = (GenericCommandResult)_handler.Handle(_invalidCommand);
        Assert.AreEqual(_result.Success, false);
    }

    [TestMethod]
    public void Dado_um_comando_invalido_deve_criar_a_tarefa()
    {
        _result = (GenericCommandResult)_handler.Handle(_validCommand);
        Assert.AreEqual(_result.Success, true);
    }
}