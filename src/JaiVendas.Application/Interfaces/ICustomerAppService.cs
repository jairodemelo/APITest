using JaiVendas.Application.ViewModel.Customers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JaiVendas.Application.Interfaces
{
    /// <summary>
    /// Serviço de clientes
    /// </summary>
    interface  ICustomerAppService
    {
        /// <summary>
        /// Retorna um cliente por meio de seu Id
        /// </summary>
        Task<CustomerViewModel> GetById(Guid id);

        /// <summary>
        /// Retorna todos os Clientes cadastrados
        /// </summary>
        /// <returns></returns>
        Task<IEnumerable<CustomerSimplifyedViewModel>> GetAll(string searchText = default);


        /// <summary>
        /// Inclui um Cliente no sistema
        /// </summary>
        Task Add(CustomerAddViewModel customer);

        /// <summary>
        /// Altera os dados de um Cliente
        /// </summary>
        void Update(CustomerUpdateViewModel customer);

        /// <summary>
        /// Exclui um Cliente
        /// </summary>
        void Delete(Guid id);

    }
}
