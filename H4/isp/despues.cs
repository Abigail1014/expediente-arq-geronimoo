// CLASE 5 · ISP, Interface Segregation — EL DESPUÉS
namespace Isp.Despues;

public interface IVendedor { void RegistrarVentaCredito(string producto, decimal monto); }
public interface IAgenteCobranza { void GestionarMora(int idCuota); }

public class Vendedor : IVendedor
{
    public void RegistrarVentaCredito(string producto, decimal monto) => Console.WriteLine($"[VENDEDOR] Venta de {producto}");
}

public class AgenteCobranza : IAgenteCobranza
{
    public void GestionarMora(int idCuota) => Console.WriteLine($"[COBRANZA] Mora cuota #{idCuota}");
}
