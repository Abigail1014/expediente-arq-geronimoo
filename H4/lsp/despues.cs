// CLASE 5 · LSP, Liskov Substitution — EL DESPUÉS
namespace Lsp.Despues;

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

    public bool EstaVencida() => DateTime.Today > FechaVencimiento;
}

public interface IConMora { decimal CalcularMora(); }

public class CuotaNormal : Cuota, IConMora
{
    public CuotaNormal(int numero, decimal monto, DateTime fechaVencimiento) : base(numero, monto, fechaVencimiento) { }
    public decimal CalcularMora()
    {
        if (!EstaVencida()) return 0m;
        var dias = (DateTime.Today - FechaVencimiento).Days;
        return Monto * 0.02m * dias;
    }
}

public class CuotaCondonada : Cuota
{
    public CuotaCondonada(int numero, decimal monto, DateTime fechaVencimiento) : base(numero, monto, fechaVencimiento) { }
}
