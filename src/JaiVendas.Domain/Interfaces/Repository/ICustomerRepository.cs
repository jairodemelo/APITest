using JaiVendas.Domain.Model.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
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
        Task<Customer> GetById(Guid id);

        /// <summary>
        /// Retorna todos os Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAll(string searchText = default);

        /// <summary>
        /// Inclui um Cliente no sistema
        /// </summary>
        Task Add(Customer customer);

        /// <summary>
        /// Altera os dados de um Cliente
        /// </summary>
        void Update(Customer customer);

        /// <summary>
        /// Exclui um Cliente
        /// </summary>
        void Delete(Guid id);

        /// <summary>
        /// Retorna true se o cliente existir
        /// </summary>
        Task<bool> Exists(Expression<Func<Customer, bool>> predicate);

    }
}
