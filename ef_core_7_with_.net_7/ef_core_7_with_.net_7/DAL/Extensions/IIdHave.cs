namespace ef_core_7_with_.net_7.DAL.Extensions;

public interface IIdHave<TK>
{
    TK Id { get; set; }
}
