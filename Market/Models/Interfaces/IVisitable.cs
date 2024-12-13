namespace Models.Interfaces;

public interface IVisitable
{
    void Accept(IVisitor visitor);
}