using Todo.Domain.Entities;

namespace Todo.Domain.Tests.EntityTests;

[TestClass]
public class TodoItemTests
{
    private readonly TodoItem _validtodo = new TodoItem("Título da Tarefa", "akioserizawa", DateTime.Now);

    [TestMethod]
    public void Dado_um_novo_todo_o_mesmo_nao_pode_ser_concluido()
    {
        Assert.AreEqual(_validtodo.Done, false);
    }
}