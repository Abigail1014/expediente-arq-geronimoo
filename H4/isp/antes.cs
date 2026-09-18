// CLASE 5 · ISP, Interface Segregation — EL ANTES
namespace Isp.Antes;

public interface IEmpleadoCredito
{
    void RegistrarVentaCredito(string producto, decimal monto);
    void AprobarCredito(int idCredito);
    void GestionarMora(int idCuota);
    void VerReporteCartera();
}

public class Vendedor : IEmpleadoCredito
{
    public void RegistrarVentaCredito(string producto, decimal monto) => Console.WriteLine($"Venta: {producto}");
    public void AprobarCredito(int id) => throw new NotSupportedException();
    public void GestionarMora(int id) => throw new NotSupportedException();
    public void VerReporteCartera() => throw new NotSupportedException();
}
