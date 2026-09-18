// CLASE 5 · LSP, Liskov Substitution — EL ANTES
namespace Lsp.Antes;

public abstract class Cuota
{
    public int Numero { get; }
    public decimal Monto { get; }
    public DateTime FechaVencimiento { get; }

    protected Cuota(int numero, decimal monto, DateTime fechaVencimiento)
    {
        Numero = numero;
        Monto = monto;
        FechaVencimiento = fechaVencimiento;
    }

    public abstract decimal CalcularMora();
}

public class CuotaNormal : Cuota
{
    public CuotaNormal(int numero, decimal monto, DateTime fechaVencimiento) : base(numero, monto, fechaVencimiento) { }
    public override decimal CalcularMora()
    {
        var dias = (DateTime.Today - FechaVencimiento).Days;
        return dias > 0 ? Monto * 0.02m * dias : 0m;
    }
}

public class CuotaCondonada : Cuota
{
    public CuotaCondonada(int numero, decimal monto, DateTime fechaVencimiento) : base(numero, monto, fechaVencimiento) { }
    public override decimal CalcularMora() => throw new NotSupportedException("Una cuota condonada no calcula mora.");
}
