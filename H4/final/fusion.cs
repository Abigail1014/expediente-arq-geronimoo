// FUSIÓN DE PATRONES: Strategy + Observer en Créditos
namespace Creditos.Fusion;

public interface IEstrategiaMora
{
    decimal Calcular(decimal monto, DateTime fechaVencimiento);
}

public class MoraEstandarStrategy : IEstrategiaMora
{
    public decimal Calcular(decimal monto, DateTime fechaVencimiento)
    {
        var dias = (DateTime.Today - fechaVencimiento).Days;
        return dias > 0 ? monto * 0.02m * dias : 0m;
    }
}

public interface IObserverCuotaVencida
{
    void Actualizar(Cuota cuota);
}

public class AgenteCobranzaNotificador : IObserverCuotaVencida
{
    private readonly string _nombre;
    public AgenteCobranzaNotificador(string nombre) => _nombre = nombre;

    public void Actualizar(Cuota cuota)
    {
        Console.WriteLine($"[COBRANZA - {_nombre}] Alerta: Cuota #{cuota.Numero} vencida.");
    }
}

public class Cuota
{
    public int Numero { get; }
    public decimal Monto { get; }
    public DateTime FechaVencimiento { get; }
    private readonly List<IObserverCuotaVencida> _observadores = new();
    private IEstrategiaMora _estrategiaMora;

    public Cuota(int numero, decimal monto, DateTime fechaVencimiento, IEstrategiaMora estrategiaMora)
    {
        Numero = numero;
        Monto = monto;
        FechaVencimiento = fechaVencimiento;
        _estrategiaMora = estrategiaMora;
    }

    public void AgregarObservador(IObserverCuotaVencida obs) => _observadores.Add(obs);
    public void VerificarEstado()
    {
        if (DateTime.Today > FechaVencimiento) NotificarObservadores();
    }
    public decimal CalcularMoraActual() => _estrategiaMora.Calcular(Monto, FechaVencimiento);

    private void NotificarObservadores()
    {
        foreach (var obs in _observadores) obs.Actualizar(this);
    }
}
