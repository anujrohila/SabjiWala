//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-22 - 18:46:07
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using OrderWala.Domain;

namespace OrderWala.DAL
{

    /// <summary>
    /// Assembler for <see cref="tblCustomerPayment"/> and <see cref="tblCustomerPaymentDTO"/>.
    /// </summary>
    public static partial class tblCustomerPaymentAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblCustomerPaymentDTO"/> converted from <see cref="tblCustomerPayment"/>.</param>
        static partial void OnDTO(this tblCustomerPayment entity, tblCustomerPaymentDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblCustomerPayment"/> converted from <see cref="tblCustomerPaymentDTO"/>.</param>
        static partial void OnEntity(this tblCustomerPaymentDTO dto, tblCustomerPayment entity);

        /// <summary>
        /// Converts this instance of <see cref="tblCustomerPaymentDTO"/> to an instance of <see cref="tblCustomerPayment"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblCustomerPaymentDTO"/> to convert.</param>
        public static tblCustomerPayment ToEntity(this tblCustomerPaymentDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblCustomerPayment();

            entity.PaymentId = dto.PaymentId;
            entity.CustomerId = dto.CustomerId;
            entity.PaymentDate = dto.PaymentDate;
            entity.Amount = dto.Amount;
            entity.RecievedBy = dto.RecievedBy;
            entity.CreationDateTime = dto.CreationDateTime;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblCustomerPayment"/> to an instance of <see cref="tblCustomerPaymentDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblCustomerPayment"/> to convert.</param>
        public static tblCustomerPaymentDTO ToDTO(this tblCustomerPayment entity)
        {
            if (entity == null) return null;

            var dto = new tblCustomerPaymentDTO();

            dto.PaymentId = entity.PaymentId;
            dto.CustomerId = entity.CustomerId;
            dto.PaymentDate = entity.PaymentDate;
            dto.Amount = entity.Amount;
            dto.RecievedBy = entity.RecievedBy;
            dto.CreationDateTime = entity.CreationDateTime;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblCustomerPaymentDTO"/> to an instance of <see cref="tblCustomerPayment"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblCustomerPayment> ToEntities(this IEnumerable<tblCustomerPaymentDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblCustomerPayment"/> to an instance of <see cref="tblCustomerPaymentDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblCustomerPaymentDTO> ToDTOs(this IEnumerable<tblCustomerPayment> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
