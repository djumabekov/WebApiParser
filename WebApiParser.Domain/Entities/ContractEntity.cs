using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities.References;
using WebApiParser.Domain.SeedWork;

namespace WebApiParser.Domain.Entities
{
    public class ContractEntity : Entity, IAggregateRoot
    {
        public long ContractId { get; set; }                //id - ИД Договора

        public long ContractNumber { get; set; }            //contract_number - Номер Договора

        public string? ContractNumberSys { get; set; }      //contract_number_sys - Системный номер Договора

        public long? TrdBuyId { get; set; }                 //trd_buy_id - ИД объявления

        public string? TrdBuyNumberAnno { get; set; }       //trd_buy_number_anno - Номер объявления

        public long? RefContractTypeId { get; set; }        //ref_contract_type_id - ИД типа договора

        public RefContractTypeEntity? RefContractType { get; set; }

        public long? RefContractStatusId { get; set; }      //ref_contract_status_id - ИД статуса договра

        public RefContractStatusEntity? RefContractStatus { get; set; }

        public DateTimeOffset? CrDate { get; set; }                //crdate - Дата создания

        public double? ContractSum { get; set; }            //contract_sum - Сумма заключенного договора без НДС

        public double? ContractSumWnds { get; set; }        //contract_sum_wnds - Сумма заключенного договора с НДС

        public long? SupplierId { get; set; }               //supplier_id - ИД Поставщика

        public string? SupplierBin { get; set; }           //supplier_biin - БИН/ИИН Поставщика

        public long? CustomerId { get; set; }                //customer_id - ИД Заказчика

        public string? CustomerBin { get; set; }            //customer_bin - БИН Заказчика

        public DateTimeOffset? IndexDate { get; set; }             //index_date - Дата индексации
    }
}
