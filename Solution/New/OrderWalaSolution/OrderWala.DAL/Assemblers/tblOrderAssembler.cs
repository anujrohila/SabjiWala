//-------------------------------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by EntitiesToDTOs.v3.2 (entitiestodtos.codeplex.com).
//     Timestamp: 2015-04-17 - 08:15:07
//
//     Changes to this file may cause incorrect behavior and will be lost if the code is regenerated.
// </auto-generated>
//-------------------------------------------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Linq;
using OrderWala.Domain.DTO;
using OrderWala.DAL;

namespace OrderWala.DAL.Assemblers
{

    /// <summary>
    /// Assembler for <see cref="tblOrder"/> and <see cref="tblOrderDTO"/>.
    /// </summary>
    public static partial class tblOrderAssembler
    {
        /// <summary>
        /// Invoked when <see cref="ToDTO"/> operation is about to return.
        /// </summary>
        /// <param name="dto"><see cref="tblOrderDTO"/> converted from <see cref="tblOrder"/>.</param>
        static partial void OnDTO(this tblOrder entity, tblOrderDTO dto);

        /// <summary>
        /// Invoked when <see cref="ToEntity"/> operation is about to return.
        /// </summary>
        /// <param name="entity"><see cref="tblOrder"/> converted from <see cref="tblOrderDTO"/>.</param>
        static partial void OnEntity(this tblOrderDTO dto, tblOrder entity);

        /// <summary>
        /// Converts this instance of <see cref="tblOrderDTO"/> to an instance of <see cref="tblOrder"/>.
        /// </summary>
        /// <param name="dto"><see cref="tblOrderDTO"/> to convert.</param>
        public static tblOrder ToEntity(this tblOrderDTO dto)
        {
            if (dto == null) return null;

            var entity = new tblOrder();

            entity.OrderId = dto.OrderId;
            entity.OrderDateTime = dto.OrderDateTime;
            entity.OrderStatus = dto.OrderStatus;
            entity.OrderAmount = dto.OrderAmount;
            entity.CustomerId = dto.CustomerId;
            entity.DeliveryCharges = dto.DeliveryCharges;
            entity.OtherCharges = dto.OtherCharges;
            entity.CustomerMessage = dto.CustomerMessage;
            entity.OverMessage = dto.OverMessage;

            dto.OnEntity(entity);

            return entity;
        }

        /// <summary>
        /// Converts this instance of <see cref="tblOrder"/> to an instance of <see cref="tblOrderDTO"/>.
        /// </summary>
        /// <param name="entity"><see cref="tblOrder"/> to convert.</param>
        public static tblOrderDTO ToDTO(this tblOrder entity)
        {
            if (entity == null) return null;

            var dto = new tblOrderDTO();

            dto.OrderId = entity.OrderId;
            dto.OrderDateTime = entity.OrderDateTime;
            dto.OrderStatus = entity.OrderStatus;
            dto.OrderAmount = entity.OrderAmount;
            dto.CustomerId = entity.CustomerId;
            dto.DeliveryCharges = entity.DeliveryCharges;
            dto.OtherCharges = entity.OtherCharges;
            dto.CustomerMessage = entity.CustomerMessage;
            dto.OverMessage = entity.OverMessage;

            entity.OnDTO(dto);

            return dto;
        }

        /// <summary>
        /// Converts each instance of <see cref="tblOrderDTO"/> to an instance of <see cref="tblOrder"/>.
        /// </summary>
        /// <param name="dtos"></param>
        /// <returns></returns>
        public static List<tblOrder> ToEntities(this IEnumerable<tblOrderDTO> dtos)
        {
            if (dtos == null) return null;

            return dtos.Select(e => e.ToEntity()).ToList();
        }

        /// <summary>
        /// Converts each instance of <see cref="tblOrder"/> to an instance of <see cref="tblOrderDTO"/>.
        /// </summary>
        /// <param name="entities"></param>
        /// <returns></returns>
        public static List<tblOrderDTO> ToDTOs(this IEnumerable<tblOrder> entities)
        {
            if (entities == null) return null;

            return entities.Select(e => e.ToDTO()).ToList();
        }

    }
}
