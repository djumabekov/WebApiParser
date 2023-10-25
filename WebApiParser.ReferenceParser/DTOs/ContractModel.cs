using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApiParser.Domain.Entities.References;

namespace WebApiParser.ReferenceParser.DTOs
{
    public class ContractModel
    {
        public long id { get; set; }                //id - ИД Договора

        public string? contract_number { get; set; }            //contract_number - Номер Договора

        public string? contract_number_sys { get; set; }      //contract_number_sys - Системный номер Договора

        public long? trd_buy_id { get; set; }                 //trd_buy_id - ИД объявления

        public string? trd_buy_number_anno { get; set; }       //trd_buy_number_anno - Номер объявления

        public long? ref_contract_type_id { get; set; }        //ref_contract_type_id - ИД типа договора

        public RefContractTypeEntity? RefContractType { get; set; }

        public long? ref_contract_status_id { get; set; }      //ref_contract_status_id - ИД статуса договра

        public RefContractStatusEntity? RefContractStatus { get; set; }

        public string? crdate { get; set; }                //crdate - Дата создания

        public double? contract_sum { get; set; }            //contract_sum - Сумма заключенного договора без НДС

        public double? contract_sum_wnds { get; set; }        //contract_sum_wnds - Сумма заключенного договора с НДС

        public long? supplier_id { get; set; }               //supplier_id - ИД Поставщика

        public string? supplier_biin { get; set; }           //supplier_biin - БИН/ИИН Поставщика

        public long? customer_id { get; set; }                //customer_id - ИД Заказчика

        public string? customer_bin { get; set; }            //customer_bin - БИН Заказчика

        public string? index_date { get; set; }             //index_date - Дата индексации

        public long? system_id { get; set; }             //index_date - Дата индексации

    }
}
