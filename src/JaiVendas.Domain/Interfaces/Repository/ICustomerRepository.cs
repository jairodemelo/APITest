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
    public interface ICustomerRepository : IRepository<Customer>
    {
        /// <summary>
        /// Retorna um cliente por meio de seu Id
        /// </summary>
        Customer GetById(Guid id);

        /// <summary>
        /// Retorna um endereço de cliente pelo seu Id
        /// </summary>
        Task<CustomerAddress> CustomerAddressGetById(Guid id);

        /// <summary>
        /// Retorna um Telefone de cliente pelo seu Id
        /// </summary>
        Task<CustomerPhone> CustomerPhoneGetById(Guid id);

        /// <summary>
        /// Retorna todos os Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<Customer>> GetAll(string searchText = default);

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
        void Delete(Guid id);

        /// <summary>
        /// Realiza a exclusão de um telefone de cliente pelo seu id
        /// </summary>
        /// <param name="id">Id do telefone do cliente</param>
        void CustomerPhoneDelete(Guid id);

        /// <summary>
        /// Exclui um endereço de clientye
        /// </summary>
        /// <param name="id">Id do endereço do cliente</param>
        void CustomerAddressDelete(Guid id);

        /// <summary>
        /// Retorna true se o cliente existir
        /// </summary>
        Task<bool> Exists<TEntity>(Expression<Func<TEntity, bool>> predicate)
            where TEntity : class;

        void CustomerAddressAdd(CustomerAddress customerAddress);

        void CustomerPhoneAdd(CustomerPhone customerPhone);
    }
}
