using JaiVendas.Domain.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Domain.Interfaces.Repository
{
    /// <summary>
    /// Repositório de Clientes
    /// </summary>
    public interface ICustomerRepository
    {
        /// <summary>
        /// Retorna um cliente por meio de seu Id
        /// </summary>
        Customer GetById(Guid id);

        /// <summary>
        /// Retorna todos os Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        IEnumerable<Customer> GetAll(string searchText = default);

        /// <summary>
        /// Inclui um Cliente no sistema
        /// </summary>
        void Add(Customer customer);

        /// <summary>
        /// Altera os dados de um Cliente
        /// </summary>
        void Update(Customer customer);

        /// <summary>
        /// Exclui um Cliente
        /// </summary>
        void Delete(Guid Id);

    }
}
